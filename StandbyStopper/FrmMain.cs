using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandbyStopper
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        Control control;

        WasapiLoopbackCapture capture;

        private DateTime StartTime;

        private MMDevice device;
        WaveOutEvent outputDevice;

        const float SOUND_THRESHOLD = 0.001f;

        static Random rnd = new Random();

        public FrmMain()
        {
            InitializeComponent();

            lblVersion.Text = $"Version {Application.ProductVersion}";

            var enumerator = new MMDeviceEnumerator();
            device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            outputDevice = new WaveOutEvent();

            infoBox.Text = device.DeviceFriendlyName;

            capture = new WasapiLoopbackCapture(device);
            capture.DataAvailable += (s, a) =>
            {
                var device_ = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
                var level = Clamp(device_.AudioMeterInformation.MasterPeakValue * 10, SOUND_THRESHOLD, 5);
                
                volumeMeter.Amplitude = level;
                Console.WriteLine(level);
;
                //Console.WriteLine(level + ", " + device_.AudioMeterInformation.MasterPeakValue);
                isPlayingControl.IsPlaying = (level <= SOUND_THRESHOLD) ? false : true;

                if (isPlayingControl.IsPlaying)
                {
                    StartTimer();
                }
            };
            capture.StartRecording();

            StartTimer();

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            capture.StopRecording();
        }

        private float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        private void StartTimer()
        {
            StartTime = DateTime.Now;
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - StartTime;
            string text = "";
            if (elapsed.Days > 0) text += elapsed.Days.ToString() + ".";

            // Convert milliseconds into tenths of seconds.
            int tenths = elapsed.Milliseconds / 100;

            // Compose the rest of the elapsed time.
            text +=
                elapsed.Hours.ToString("00") + ":" +
                elapsed.Minutes.ToString("00") + ":" +
                elapsed.Seconds.ToString("00") + "." +
                tenths.ToString("0");

            timerUI.Text = text;
        }

        private void btnBeep_Click(object sender, EventArgs e)
        {
            PlaySound("beep");
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            PlaySound("break");
        }

        private void btnSilence_Click(object sender, EventArgs e)
        {
            PlaySound("silence");
        }

        private void PlaySound(string name)
        {
            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                outputDevice.Stop();
            };
            
            
            var audioFile = new AudioFileReader($"./audio/{name}.wav");
            outputDevice.Init(audioFile);
            outputDevice.Play();
        }

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }
    }
}

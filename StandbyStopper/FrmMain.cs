using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using NAudio.Extras;

namespace StandbyStopper
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        Control control;

        //WasapiLoopbackCapture capture;

        private DateTime StartTime;

        //private MMDevice device;
        //WaveOutEvent outputDevice;

        const float SOUND_THRESHOLD = 0.001f;

        static Random rnd = new Random();

        NAudioEngine soundEngine = NAudioEngine.Instance;


        private static int fftLength = 1024;
        //private SampleAggregator sampleAggregator = new SampleAggregator(fftLength);

        public FrmMain()
        {
            InitializeComponent();

            VisControl control = elementHost.Child as VisControl;
            control.Analyzer.RegisterSoundPlayer(soundEngine);

            //Get default output
            infoBox.Text = soundEngine.device.DeviceFriendlyName;

            soundEngine.capture.DataAvailable += OnDataAvailable;
            soundEngine.capture.StartRecording();
            
            //Set version
            lblVersion.Text = $"Version {Application.ProductVersion}";
            
            StartTimer();

        }


        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e);
            }
            else
            {
                //soundEngine.sampleAggregator.Clear();
                //soundEngine.sampleAggregator.Add(rnd.Next(-100,50), 0);
                /*float maxValue = 32767;
                int peakL = 0;
                int peakR = 0;
                int bytesPerSample = 4;
                for (int index = 0; index < e.BytesRecorded; index += bytesPerSample)
                {
                    int valueL = BitConverter.ToInt16(e.Buffer, index);
                    peakL = Math.Max(peakL, valueL);
                    int valueR = BitConverter.ToInt16(e.Buffer, index + 2);
                    peakR = Math.Max(peakR, valueR);
                }
                soundEngine.sampleAggregator.Clear();
                soundEngine.sampleAggregator.Add(peakL/maxValue, peakR/maxValue);
                */

                byte[] buffer = e.Buffer;
                int bytesRecorded = e.BytesRecorded;
                int bufferIncrement = soundEngine.capture.WaveFormat.BlockAlign;
                for (int index = 0; index < bytesRecorded; index += bufferIncrement)
                {
                    float sample32 = BitConverter.ToSingle(buffer, index);
                    soundEngine.sampleAggregator.Add(sample32, sample32);
                }



                var level = Clamp(soundEngine.device.AudioMeterInformation.MasterPeakValue * 10, SOUND_THRESHOLD, 5);

                volumeMeter.Amplitude = level;
                isPlayingControl.IsPlaying = (level <= SOUND_THRESHOLD) ? false : true;
                
                if (isPlayingControl.IsPlaying) StartTimer();

            }

            
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            soundEngine.capture.StopRecording();
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
            if (soundEngine.outputDevice.PlaybackState == PlaybackState.Playing)
            {
                soundEngine.outputDevice.Stop();
            };
            
            
            var audioFile = new AudioFileReader($"./audio/{name}.wav");
            soundEngine.outputDevice.Init(audioFile);
            soundEngine.outputDevice.Play();
        }
        

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }
    }
}

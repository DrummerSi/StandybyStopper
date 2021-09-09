using NAudio.Wave;
using System;
using System.Windows.Forms;
using System.Windows.Media;
using WPFSoundVisualizationLib;

namespace StandbyStopper
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {

        public readonly NAudioEngine SoundEngine = NAudioEngine.Instance;
        const float SoundThreshold = 0.001f;

        private DateTime _startTime;
       

        public FrmMain()
        {
            InitializeComponent();

            //ElementHost should always be a VisControl. This makes sure it's loaded before using
            if (elementHost.Child is VisControl visControl)
            {
                visControl.Analyzer.RegisterSoundPlayer(SoundEngine);
            }
            else
            {
                MessageBox.Show(@"Spectrum Analyser not initialised correctly.", @"Initialising error");
            }


            //Get default output
            infoBox.Text = SoundEngine.Device.DeviceFriendlyName;

            SoundEngine.Capture.DataAvailable += OnDataAvailable;
            SoundEngine.Capture.StartRecording();
            
            //Set version
            lblVersion.Text = $@"Version {Application.ProductVersion}";
            
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

                byte[] buffer = e.Buffer;
                int bytesRecorded = e.BytesRecorded;
                int bufferIncrement = SoundEngine.Capture.WaveFormat.BlockAlign;
                for (int index = 0; index < bytesRecorded; index += bufferIncrement)
                {
                    float sample32 = BitConverter.ToSingle(buffer, index);
                    SoundEngine.SampleAggregator.Add(sample32, sample32);
                }

                var level = Clamp(SoundEngine.Device.AudioMeterInformation.MasterPeakValue * 10, SoundThreshold, 5);

                volumeMeter.Amplitude = level;
                isPlayingControl.IsPlaying = (!(level <= SoundThreshold));
                
                if (isPlayingControl.IsPlaying) StartTimer();

            }

            
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SoundEngine.Capture.StopRecording();
        }

        private float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        private void StartTimer()
        {
            _startTime = DateTime.Now;
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - _startTime;
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
            if (SoundEngine.OutputDevice.PlaybackState == PlaybackState.Playing)
            {
                SoundEngine.OutputDevice.Stop();
            };
            
            
            var audioFile = new AudioFileReader($"./audio/{name}.wav");
            SoundEngine.OutputDevice.Init(audioFile);
            SoundEngine.OutputDevice.Play();
        }
        

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }
    }
}

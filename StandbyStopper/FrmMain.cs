using NAudio.Wave;
using System;
using System.Windows.Forms;

namespace StandbyStopper
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        Control control;

        private DateTime StartTime;

        const float SOUND_THRESHOLD = 0.001f;

        static Random rnd = new Random();

        readonly NAudioEngine SoundEngine = NAudioEngine.Instance;

        public FrmMain()
        {
            InitializeComponent();

            VisControl control = elementHost.Child as VisControl;
            control.Analyzer.RegisterSoundPlayer(SoundEngine);

            //Get default output
            infoBox.Text = SoundEngine.device.DeviceFriendlyName;

            SoundEngine.capture.DataAvailable += OnDataAvailable;
            SoundEngine.capture.StartRecording();
            
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
                int bufferIncrement = SoundEngine.capture.WaveFormat.BlockAlign;
                for (int index = 0; index < bytesRecorded; index += bufferIncrement)
                {
                    float sample32 = BitConverter.ToSingle(buffer, index);
                    SoundEngine.sampleAggregator.Add(sample32, sample32);
                }

                var level = Clamp(SoundEngine.device.AudioMeterInformation.MasterPeakValue * 10, SOUND_THRESHOLD, 5);

                volumeMeter.Amplitude = level;
                isPlayingControl.IsPlaying = (!(level <= SOUND_THRESHOLD));
                
                if (isPlayingControl.IsPlaying) StartTimer();

            }

            
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SoundEngine.capture.StopRecording();
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
            if (SoundEngine.outputDevice.PlaybackState == PlaybackState.Playing)
            {
                SoundEngine.outputDevice.Stop();
            };
            
            
            var audioFile = new AudioFileReader($"./audio/{name}.wav");
            SoundEngine.outputDevice.Init(audioFile);
            SoundEngine.outputDevice.Play();
        }
        

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }
    }
}

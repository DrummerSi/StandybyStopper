using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Threading;

namespace StandbyStopper
{
    class Stopper
    {
        private WasapiLoopbackCapture capture;

        const float SOUND_THRESHOLD = 0.001f;

        public static void Run()
        {
            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            var outputDevice = new WaveOutEvent();

            var capture = new WasapiLoopbackCapture(device);
            capture.DataAvailable += (s, a) =>
            {
                var device_ = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
                var level = Clamp(device_.AudioMeterInformation.MasterPeakValue * 10, SOUND_THRESHOLD, 5);

                //Console.WriteLine(level);
                if(level <= SOUND_THRESHOLD)
                {
                    //There's currently no sound.. Play a sound
                    var audioFile = new AudioFileReader($"./audio/silence.wav");
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                    Thread.Sleep(audioFile.TotalTime);

                }
                capture.StopRecording();

            };
            capture.StartRecording();

        }

        private static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }


    }
}

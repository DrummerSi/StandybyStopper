using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using StandbyStopper;
using WPFSoundVisualizationLib;


namespace StandbyStopper
{
    public class NAudioEngine : ISpectrumPlayer, IDisposable
    {

        #region Fields

        private static NAudioEngine _instance;
        private const int FftDataSize = (int)FFTDataSize.FFT2048;
        private bool _disposed;

        public SampleAggregator SampleAggregator;
        public MMDevice Device;
        public WaveOutEvent OutputDevice;
        public WasapiLoopbackCapture Capture;

        #endregion

        #region Singleton Pattern

        public static NAudioEngine Instance => _instance ?? (_instance = new NAudioEngine());

        #endregion

        #region Constructor

        private NAudioEngine()
        {
            var enumerator = new MMDeviceEnumerator();
            Device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            OutputDevice = new WaveOutEvent();
            Capture = new WasapiLoopbackCapture(Device);

            SampleAggregator = new SampleAggregator(FftDataSize);
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed) _disposed = true;
        }

        #endregion


        #region ISpectrumPlayer

        public bool GetFFTData(float[] fftDataBuffer)
        {
            SampleAggregator.GetFFTResults(fftDataBuffer);
            return true;
        }

        public int GetFFTFrequencyIndex(int frequency)
        {
            double maxFrequency = 22050; // Assume a default 44.1 kHz sample rate.
            return (int)((frequency / maxFrequency) * (FftDataSize / 2));
        }

        public bool IsPlaying => true;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion





    }

}
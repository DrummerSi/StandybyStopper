using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StandbyStopper;
using WPFSoundVisualizationLib;

public class NAudioEngine : /*INotifyPropertyChanged, ISpectrumPlayer,*/ ISpectrumPlayer, IDisposable
{

    #region Fields
    private static NAudioEngine instance;
    private readonly int fftDataSize = (int)FFTDataSize.FFT2048;
    private bool disposed;

    public SampleAggregator sampleAggregator;
    public MMDevice device;
    public WaveOutEvent outputDevice;
    public WasapiLoopbackCapture capture;
    #endregion

    #region Constants
    private const int waveformCompressedPointCount = 2000;
    private const int repeatThreshold = 200;
    #endregion

    #region Singleton Pattern
    public static NAudioEngine Instance
    {
        get
        {
            if (instance == null)
                instance = new NAudioEngine();
            return instance;
        }
    }
    #endregion

    #region Constructor
    private NAudioEngine()
    {
        var enumerator = new MMDeviceEnumerator();
        device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        outputDevice = new WaveOutEvent();
        capture = new WasapiLoopbackCapture(device);

        sampleAggregator = new SampleAggregator(fftDataSize);
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
        if (!disposed)
        {
            if (disposing)
            {
                //StopAndCloseStream();
            }

            disposed = true;
        }
    }
    #endregion


    #region ISpectrumPlayer
    public bool GetFFTData(float[] fftDataBuffer)
    {
        sampleAggregator.GetFFTResults(fftDataBuffer);
        return true;
    }

    public int GetFFTFrequencyIndex(int frequency)
    {
        double maxFrequency = 22050; // Assume a default 44.1 kHz sample rate.
        return (int)((frequency / maxFrequency) * (fftDataSize / 2));
    }

    public bool IsPlaying => true;

    public event PropertyChangedEventHandler PropertyChanged;
    #endregion





}

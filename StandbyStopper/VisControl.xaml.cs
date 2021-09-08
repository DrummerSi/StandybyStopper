using System;
using System.Windows;
using System.Windows.Controls;
using WPFSoundVisualizationLib;

namespace StandbyStopper
{
    /// <summary>
    /// Interaction logic for VisControl.xaml
    /// </summary>
    public partial class VisControl : UserControl
    {

        public SpectrumAnalyzer Analyzer => spectrumAnalyzer;
        public VisControl()
        {
            InitializeComponent();

            Resources.MergedDictionaries.Clear();
            ResourceDictionary themeResources = Application.LoadComponent(new Uri("ExpressionDark.xaml", UriKind.Relative)) as ResourceDictionary;
            Resources.MergedDictionaries.Add(themeResources);
        }
    }
}

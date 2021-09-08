using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

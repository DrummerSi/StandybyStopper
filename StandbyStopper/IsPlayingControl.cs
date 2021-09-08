using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandbyStopper
{
    public partial class IsPlayingControl : UserControl
    {
        readonly Control _control;

        private Boolean isPlaying_ { get; set; }

        public Boolean IsPlaying {
            get => isPlaying_;
            set
            {
                try
                {
                    _control.BeginInvoke((MethodInvoker)delegate ()
                    {
                        isPlaying_ = value;
                        if (value)
                        {
                            icon.Image = Properties.Resources.green;
                            label.Text = @"Audio detected";
                        }
                        else
                        {
                            icon.Image = Properties.Resources.red;
                            label.Text = @"No audio";
                        }
                    });
                } catch (Exception e)
                {
                    //Do nothing
                    Console.WriteLine($@"Something fucked up! {e.Message}");
                }
            }
        }
        public IsPlayingControl()
        {
            InitializeComponent();
            _control = icon;
        }
    }
}

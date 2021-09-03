using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandbyStopper
{
    public partial class IsPlayingControl : UserControl
    {

        Control control;

        private Boolean isPlaying_ { get; set; }

        public Boolean IsPlaying {
            get { return isPlaying_; }
            set
            {
                try
                {
                    control.BeginInvoke((MethodInvoker)delegate ()
                    {
                        isPlaying_ = value;
                        if (value)
                        {
                            icon.Image = Properties.Resources.green;
                            label.Text = "Audio detected";
                        }
                        else
                        {
                            icon.Image = Properties.Resources.red;
                            label.Text = "No audio";
                        }
                    });
                } catch (Exception e)
                {
                    //Do nothing
                }
            }
        }
        public IsPlayingControl()
        {
            InitializeComponent();
            control = icon;
        }
    }
}

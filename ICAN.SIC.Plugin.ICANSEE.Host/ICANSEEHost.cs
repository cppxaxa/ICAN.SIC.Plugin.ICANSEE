using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICAN.SIC.Plugin.ICANSEE.Host
{
    public partial class ICANSEEHost : Form
    {
        ICANSEE controller = new ICANSEE();

        public ICANSEEHost()
        {
            InitializeComponent();
        }

        private void ICANSEEHost_Load(object sender, EventArgs e)
        {
            TxtFbpPath.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleFBP", "Population5.fbp");
        }

        private void BtnReadFBP_Click(object sender, EventArgs e)
        {
            controller.ReadFBPConfiguration(TxtFbpPath.Text);
        }
    }
}

﻿using System;
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
            TxtFbpPath.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleFBP", "Population5.drw");
        }

        private void BtnReadFBP_Click(object sender, EventArgs e)
        {
            controller.ReadFBPConfiguration(TxtFbpPath.Text);

            
        }

        private void BtnDfs_Click(object sender, EventArgs e)
        {
            var result = controller.GenerateFBPGraph(TxtFbpPath.Text);

            foreach (var node in result.GetDFSEnumerator())
            {
                Console.WriteLine("{0} {1}", node.id, node.description.Replace("\n", " "));
            }
        }

        private void BtnDummyCall_Click(object sender, EventArgs e)
        {
            //controller.MakeDummyGetCall();
            //controller.MakeDummyPostCall();

            //Console.WriteLine(controller.ExecuteScalar(new List<string> { "Start", "", "result = tfnet.return_predict(imageSrc)\noutput = str(result)" }));
            //controller.Execute(new List<string> { "Start", "", "result = tfnet.return_predict(imageSrc)\noutput = str(result)" });
        }
    }
}

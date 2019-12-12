using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonverSywul
{
    public partial class RepForm : Form
    {
        public RepForm()
        {
            InitializeComponent();
            CenterToScreen();

        }

        public object cReportOutputBindingSource { get; internal set; }

        public void RepForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }


    }
}

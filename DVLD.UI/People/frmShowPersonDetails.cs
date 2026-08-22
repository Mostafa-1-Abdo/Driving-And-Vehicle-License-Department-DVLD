using System;
using System.Windows.Forms;

namespace DVLD.UI.People
{
    public partial class frmShowPersonDetails : Form
    {
        private int _ID;

        public frmShowPersonDetails(int ID)
        {
            InitializeComponent();

            _ID = ID;
        } 
       
        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
            if(!ctrlPersonCard1.LoadPersonInfo(_ID))
                Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
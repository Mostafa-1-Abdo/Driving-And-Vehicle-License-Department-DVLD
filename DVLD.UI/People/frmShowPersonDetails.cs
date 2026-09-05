using DVLD.UI.Util;
using System;
using System.Windows.Forms;

namespace DVLD.UI.People
{
    public partial class frmShowPersonDetails : Form
    {
        private int _ID;

        public frmShowPersonDetails(int id)
        {
            InitializeComponent();

            _ID = id;
        }

        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
            if (!ctrlPersonCard1.LoadPersonInfo(_ID))
            {
                clUIMessages.ShowNotFound("Person", _ID);
                Close();
                return;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e) => Close();
    }
}
using DVLD.UI.Util;
using System;
using System.Windows.Forms;

namespace DVLD.UI.Users
{
    public partial class frmShowUserDetails : Form
    {
        private int _ID;

        public frmShowUserDetails(int id)
        {
            InitializeComponent();

            _ID = id;
        }

        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {
            if (!ctrlUserCard1.LoadUserInfo(_ID))
            {
                clUIMessages.ShowNotFound("User", _ID);
                Close();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e) => Close();
    }
}
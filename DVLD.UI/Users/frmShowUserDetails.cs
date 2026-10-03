using DVLD.UI.Util;
using System;
using System.Windows.Forms;

namespace DVLD.UI.Users
{
    public partial class frmShowUserDetails : Form
    {
        private int _id;

        public frmShowUserDetails(int id)
        {
            InitializeComponent();

            _id = id;
        }

        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {
            if (!ctrlUserCard1.LoadUserInfo(_id))
            {
                UIMessages.ShowNotFound("User", _id);
                Close();
                return;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e) => Close();
    }
}
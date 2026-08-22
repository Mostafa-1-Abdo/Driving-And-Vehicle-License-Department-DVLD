using DVLD.UI.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.UI.Users
{
    public partial class frmShowUserDetails : Form
    {
        private int _ID;

        public frmShowUserDetails(int ID)
        {
            InitializeComponent();

            _ID = ID;
        }

        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_ID);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

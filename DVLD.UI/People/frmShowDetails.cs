using System;
using System.Windows.Forms;

namespace DVLD.UI.People
{
    public partial class frmShowDetails : Form
    {
        private int _ID;

        public frmShowDetails(int ID)
        {
            InitializeComponent();

            _ID = ID;
        } 
       
        private void frmShowDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonInfo(_ID);
        }
    }
}
using DVLD.Logic;
using System.Windows.Forms;

namespace DVLD.UI.UserControls
{
    public partial class ctrlUserCard : UserControl
    {
        private clUser _User;

        public clUser User { get => _User; }

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void _FillCardWithPeronInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.Person);
            lb_ID.Text = _User.ID.ToString();
            lb_Username.Text = _User.Username;
            lb_IsActive.Text = _User.IsActive ? "Acitve" : "Inactive";
        }

        public bool LoadUserInfo(int ID)
        {
            _User = clUser.Find(ID);

            if (_User == null)
            {
                MessageBox.Show($"No user with ID = {ID} was found in the system.", "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            _FillCardWithPeronInfo();

            return true;
        }
    }
}

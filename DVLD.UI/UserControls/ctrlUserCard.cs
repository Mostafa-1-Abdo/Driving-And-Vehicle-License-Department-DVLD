using DVLD.Logic;
using System.Windows.Forms;

namespace DVLD.UI.UserControls
{
    public partial class ctrlUserCard : UserControl
    {
        private clUser _User;

        public clUser User { get => _User; }

        public ctrlUserCard() => InitializeComponent();

        public void ResetUserCard()
        {
            ctrlPersonCard1.ResetPersonCard();
            lb_ID.Text = "[???]";
            lb_Username.Text = "[???]";
            lb_IsActive.Text = "[???]";
        }

        private void _FillCardWithPersonInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.Person);
            lb_ID.Text = _User.ID.ToString();
            lb_Username.Text = _User.Username;
            lb_IsActive.Text = _User.IsActive ? "Active" : "Inactive";
        }

        public bool LoadUserInfo(int ID)
        {
            _User = clUser.Find(ID);

            if (_User == null)
            {
                ResetUserCard();
                return false;
            }

            _FillCardWithPersonInfo();

            return true;
        }
    }
}
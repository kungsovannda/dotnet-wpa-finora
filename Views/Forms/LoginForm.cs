using PersonalExpenseTracker.Views.Forms;
using PersonalExpenseTracker.Views.UI;
namespace PersonalExpenseTracker.Views.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Typography.Apply(this);
            txtUsername.Focus();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

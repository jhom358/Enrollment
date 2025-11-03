namespace EnrollmentGUI
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
            tb_password.PasswordChar = '*';
        }

        private void btn_Login_Check(object sender, EventArgs e)
        {
            string username = tb_username.Text.Trim();
            string password = tb_password.Text.Trim();
            if (username != "admin")
            {
                MessageBox.Show("Invalid Username, Please try again.", "Log in Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_username.Focus();
                return;
            }
            if (password != "123")
            {
                MessageBox.Show("Incorrect Password Please try again.", "Log in Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_password.Focus();
                return;
            }
            MessageBox.Show("Login Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AdminDuty adminForm = new AdminDuty();
            adminForm.StartPosition = FormStartPosition.CenterScreen;
            adminForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Hide();
        }
    }
}
    
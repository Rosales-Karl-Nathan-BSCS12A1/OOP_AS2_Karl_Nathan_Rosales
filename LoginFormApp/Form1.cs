
namespace LoginFormApp
{
    public partial class Form1 : Form
    {
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblMessage;

        public Form1()
        {
            InitializeComponent();
            InitializeForm();
            this.Load += new EventHandler(Form1_Load);
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
        }

        private void InitializeForm()
        {
            // form 
            this.Text = "Login Form";
            this.ClientSize = new Size(400, 300);

            // username label
            lblUsername = new Label() { Text = "Username" };
            lblUsername.AutoSize = true;
            this.Controls.Add(lblUsername);

            // password label
            lblPassword = new Label() { Text = "Password" };
            lblPassword.AutoSize = true;
            this.Controls.Add(lblPassword);

            // username textbox
            txtUsername = new TextBox();
            this.Controls.Add(txtUsername);

            // password textbox asteris
            txtPassword = new TextBox() { PasswordChar = '*' };
            this.Controls.Add(txtPassword);

            // login button
            btnLogin = new Button() { Text = "Login" };
            btnLogin.Click += BtnLogin_Click;
            this.Controls.Add(btnLogin);

            // message label
            lblMessage = new Label() { AutoSize = true };
            this.Controls.Add(lblMessage);

            CenterControls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            // center form
            lblUsername.Location = new Point((this.ClientSize.Width - lblUsername.Width) / 2, 50);
            txtUsername.Location = new Point((this.ClientSize.Width - txtUsername.Width) / 2, lblUsername.Bottom + 10);
            txtUsername.Width = 200;

            lblPassword.Location = new Point((this.ClientSize.Width - lblPassword.Width) / 2, txtUsername.Bottom + 20);
            txtPassword.Location = new Point((this.ClientSize.Width - txtPassword.Width) / 2, lblPassword.Bottom + 10);
            txtPassword.Width = 200;

            btnLogin.Location = new Point((this.ClientSize.Width - btnLogin.Width) / 2, txtPassword.Bottom + 20);

            lblMessage.Location = new Point((this.ClientSize.Width - lblMessage.Width) / 2, btnLogin.Bottom + 20);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // create user manager and load users from json
            User userManager = new User();
            userManager.LoadUsersFromJson("users.json");

            // get username and password 
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // to check if valid
            if (userManager.IsValid(username, password))
            {
                lblMessage.Text = "Login successful!";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
                lblMessage.ForeColor = Color.Red;
            }

            // recenter message
            lblMessage.Location = new Point((this.ClientSize.Width - lblMessage.Width) / 2, btnLogin.Bottom + 20);
        }
    }
}

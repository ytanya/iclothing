using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace iClothing
{
    public partial class Login : UserControl
    {
        public string conn = DBAccess.ConnectionString;
        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar= '\u2022'; 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            CheckUserPassword(username, password);
        }
        void CheckUserPassword(string username, string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    string query = "SELECT * FROM Staff Join Roles on Staff.RoleID = Roles.RoleID WHERE Tendangnhap ='" + username + "' and Matkhau='" + password + "';";
                    if (DBAccess.IsServerConnected())
                    {
                        using (SqlCeConnection connection = new SqlCeConnection(conn))
                        {
                            using (SqlCeCommand command = new SqlCeCommand(query, connection))
                            {
                                SqlCeDataAdapter sda = new SqlCeDataAdapter(command);
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                if (dt.Rows.Count >= 1)
                                {
                                    string currentUser = dt.Rows[0].Field<string>("Tendangnhap").ToString();
                                    string currentRole = dt.Rows[0].Field<string>("RoleID").ToString();


                                    LoginForm childForm = (LoginForm)this.ParentForm;
                                    Form1 parentForm = (Form1)childForm.ParentForm;
                                    Panel pnMenu = parentForm.Controls["pnMenu"] as Panel;
                                    pnMenu.Visible = true;
                                    Panel pnLeft = parentForm.Controls["pnLeft"] as Panel;
                                    pnLeft.Visible = true;
                                    pnLeft.Width = 238;
                                    Panel pnStuff = pnLeft.Controls["pnStuff"] as Panel;
                                    Panel pnSystem = pnLeft.Controls["pnSystem"] as Panel;
                                    Panel pnInOutStock = pnLeft.Controls["pnInOutStock"] as Panel;
                                    if (currentRole == "0000001")
                                    {

                                        pnStuff.Visible = true;
                                        pnSystem.Visible = true;
                                        Button btnStaff = pnSystem.Controls["btnStaff"] as Button;
                                        btnStaff.Visible = true;
                                        pnInOutStock.Visible = false;
                                        
                                    }
                                    else if(currentRole == "0000003")
                                    {
                                        pnStuff.Visible = false;
                                        pnSystem.Visible = false;                                       
                                        pnInOutStock.Visible = true;
                                    }
                                    
                                    Button btnMini = pnLeft.Controls["btnMini"] as Button;
                                    btnMini.Visible = true;
                                    
                                    Label lblCurrentUser = pnMenu.Controls["lblCurrentUser"] as Label;
                                    lblCurrentUser.Text = username;
                                    lblCurrentUser.Visible = true;
                                    Button btnMinimize = pnMenu.Controls["btnMinimize"] as Button;
                                    btnMinimize.Visible = true;
                                    Button btnMaximize = pnMenu.Controls["btnMaximize"] as Button;
                                    btnMaximize.Visible = true;
                                    Panel SidePanelLeft = pnLeft.Controls["SidePanelLeft"] as Panel;
                                    SidePanelLeft.Visible = true;
                                    Button btnSignout = pnMenu.Controls["btnSignout"] as Button;
                                    btnSignout.Visible = true;
                                    this.Visible = false;
                                    ClearField();
                                }
                                else
                                {
                                    CommonHelper.showDialog("Sai tên đăng nhập hoặc mật khẩu.", Color.FromArgb(255, 53, 71));
                                }
                            }
                        }
                    }

                }
                else
                {
                    CommonHelper.showDialog("Mời tên đăng nhập và mật khẩu.", Color.FromArgb(255, 187, 51));
                }
            }
            catch(SqlCeException Ceex)
            {
                MessageBox.Show(Ceex.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            

        }

        protected void ClearField()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                CheckUserPassword(username, password);
            }
        }
    }
}

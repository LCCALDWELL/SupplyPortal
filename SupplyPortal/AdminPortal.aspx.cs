using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupplyPortal
{
    public partial class AdminPortal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AddUserTable.Visible = false;
                DeleteUserTable.Visible = false;
                EditUserTable.Visible = false;
            }


        }

        protected void addUserButton_Click(object sender, EventArgs e)
        {
            User newUser = new User();

            string username = UsernameTextBox.Text.ToUpper();
            string role = RoleTextBox.Text.ToUpper();
            string email = EmailTextBox.Text.ToUpper();
            bool duplicateUser = newUser.duplicateUsername(username);

            if (duplicateUser == false)
            {

                string addUserQuery = "INSERT into Users(UserName, Password, Role, Email)  VALUES (@username, @password, @role, @email);";



                newUser.addUserToDB(addUserQuery, username, role, email);

                ResultLabel.Text = "User added";
            }
            else
            {
                ResultLabel.Text = "User already exists with this Username";
            }

            UsernameTextBox.Text = "";
            RoleTextBox.Text = "";
            EmailTextBox.Text = "";

            cmdRefresh();
        }

        protected void cmdRefresh()
        {
            SqlDataSource1.EnableCaching = false;
            GridView1.DataBind();
            SqlDataSource1.EnableCaching = true;
        }


        protected void deleteButton_Click(object sender, EventArgs e)
        {
            string username = UserToDelTextBox.Text.ToUpper();
            string deleteUser = "delete top(1) from Users where UserName='" + username + "'";

            try
            {
                runQuery(deleteUser);
                ResultLabel.Text = "User Deleted Successfully";
            }
            catch
            {
                // Error message
            }

            UserToDelTextBox.Text = "";

        }

        private void runQuery(string queryString)
        {
            using (SqlConnection openCon = new System.Data.SqlClient.SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\UserDB.mdf;Integrated Security=True"))
            {
                using (SqlCommand query = new SqlCommand(queryString))
                {
                    query.Connection = openCon;
                    query.CommandType = CommandType.Text;

                    try
                    {
                        openCon.Open();
                        query.ExecuteNonQuery();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        openCon.Close();
                    }
                    cmdRefresh();

                }
            }
        }

        protected void AddUserTab_Click(object sender, EventArgs e)
        {
            TableName.Text = "Add User";
            AddUserTable.Visible = true;
            DeleteUserTable.Visible = false;
            EditUserTable.Visible = false;
            ResultLabel.Text = "";
        }

        protected void DeleteUserTab_Click(object sender, EventArgs e)
        {
            TableName.Text = "Delete User";
            AddUserTable.Visible = false;
            DeleteUserTable.Visible = true;
            EditUserTable.Visible = false;
            ResultLabel.Text = "";
        }
        protected void EditUserTab_Click(object sender, EventArgs e)
        {
            TableName.Text = "Edit User";
            AddUserTable.Visible = false;
            DeleteUserTable.Visible = false;
            EditUserTable.Visible = true;
            ResultLabel.Text = "";

            if (EditUserTable.Visible == true && EditUserTextBox.Text == "")
            {
                ResultLabel.Text = "Enter the Username you wish to edit and click Edit Button";
            }

        }

        protected void editUserButton_Click(object sender, EventArgs e)
        {
            User editUser = new User();

            try
            {
                string[] userDetails = editUser.getUserDetails(EditUserTextBox.Text.ToUpper());

                if (userDetails[0] != null)
                {
                    EditRoleTextBox.Enabled = true;
                    EditEmailTextBox.Enabled = true;

                    EditUserTextBox.Text = userDetails[0];
                    EditRoleTextBox.Text = userDetails[2];
                    EditEmailTextBox.Text = userDetails[3];

                    editButton.Visible = false;
                    saveEditButton.Visible = true;
                }

                else
                {
                    ResultLabel.Text = "Username does not exist. Please re-enter Username and click edit";
                    EditUserTextBox.Text = "";
                }
            }

            catch {
            }
        }

        protected void saveEditUserButton_Click(object sender, EventArgs e)
        {

        }
    }
}
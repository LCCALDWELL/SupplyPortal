using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SupplyPortal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            User user = new User();
            string username = usernameTextBox.Text.ToUpper();
            string password = passwordTextBox.Text;
            
            string[] userDetails = user.getUserDetails(username);
            string passwordFromDb = userDetails[1];

            if (passwordFromDb == password)
            {
                string urlPath = user.navigatePerRole(userDetails);

                Server.Transfer(urlPath);
            }
            else
            {
                resultLabel.Text = "Username or Password is incorrect";
            }
        }

        
        
    }
}
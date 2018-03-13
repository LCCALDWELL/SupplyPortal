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
    public class User
    {

        public void addUserToDB(string addUserQuery, string username, string role, string email)
        {
            // Add user to DB through Admin Portal

                using (SqlConnection openCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\UserDB.mdf;Integrated Security=True"))
                {
                    using (SqlCommand queryAddUser = new SqlCommand(addUserQuery))
                    {
                        queryAddUser.Connection = openCon;
                        queryAddUser.CommandType = CommandType.Text;
                        queryAddUser.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = username;
                        queryAddUser.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = "PASSWORD";
                        queryAddUser.Parameters.Add("@role", SqlDbType.VarChar, 20).Value = role;
                        queryAddUser.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;

                        try
                        {
                            openCon.Open();
                            queryAddUser.ExecuteNonQuery();
                        }
                        catch
                        {

                        }
                        finally
                        {
                            openCon.Close();
                        }

                    }
                }
            }

        public string[] getUserDetails(string username)
        {
            // Get user details for purposes such as Login
            int x = 0;

            string[] userDetailsNames = { "UserName", "Password", "Role", "Email" };

            string[] userDetails = new string[4];

            using (SqlConnection openCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\UserDB.mdf;Integrated Security=True"))
            {
                for (int i = 0; i <= 3; i++)
                {

                    string dbQuery = "select " + userDetailsNames[i] + " from Users where UserName='" + username + "';";

                    using (SqlCommand query = new SqlCommand(dbQuery))
                    {
                        query.Connection = openCon;
                        query.CommandType = CommandType.Text;

                        try
                        {
                            openCon.Open();
                            userDetails[x] = (string)query.ExecuteScalar();
                            x++;
                        }
                        catch
                        {

                        }
                        finally
                        {
                            openCon.Close();
                        }
                    }
                }
            }

            return userDetails;
        }

        public string navigatePerRole(string[] userDetails)
        {
            // Set Portal Page based on User Role
            string urlPath = "";

            if (userDetails[2] == "ADMIN")
            {
                urlPath = "AdminPortal.aspx";
            }


            return urlPath;
        }

        public bool duplicateUsername(string username)
        {
            bool duplicateUser = false;
            string usernameQuery = "select UserName from Users where UserName='" + username + "';";

            using (SqlConnection openCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\UserDB.mdf;Integrated Security=True"))
            {
                using (SqlCommand query = new SqlCommand(usernameQuery))
                {
                    query.Connection = openCon;
                    query.CommandType = CommandType.Text;


                    try
                    {
                        openCon.Open();
                        string duplicateUsername = (string)query.ExecuteScalar();
                        if (duplicateUsername == username)
                        {
                            duplicateUser = true;
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        openCon.Close();
                    }


                }
                return duplicateUser;
            }

        }

    }
}
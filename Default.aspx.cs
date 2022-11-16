using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP_WCF_DB.DBServiceReference;

namespace ASP_WCF_DB
{
    public partial class _Default : Page
    {
        DBServiceReference.Service1Client client = new DBServiceReference.Service1Client();
        string userName = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            UserDetails user = new UserDetails();
            user.UserName = txbxName.Text;
            user.Password = txbxPswrd.Text;
            user.Country = txbxCountry.Text;
            user.Email = txbxEmail.Text;
            string result = client.InsertUserDetails(user);
            lblSuccess.Visible = true;
            lblSuccess.Text = result.ToString();
        }

        protected void btnFindAll_Click(object sender, EventArgs e)
        {
            List<UserDetails> users = new List<UserDetails>();
            users = client.GetUserDetails().ToList();
            gvAllUsers.DataSource = users;
            gvAllUsers.DataBind();
        }

        protected void btnFindUser_Click(object sender, EventArgs e)
        {
            List<UserDetails> users = new List<UserDetails>();
            userName = txbxName.Text.Trim();
            UserDetails user = client.GetUser(userName);
            users.Add(user);
            txbxName.Text = user.UserName;
            txbxPswrd.Text = user.Password;
            txbxEmail.Text = user.Email;
            txbxCountry.Text = user.Country;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            userName = txbxName.Text.Trim();
            string result = client.DeleteUser(userName);
            lblSuccess.Visible = true;
            lblSuccess.ForeColor = Color.Red;
            lblSuccess.Text = result.ToString();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UserDetails user = new UserDetails
            {
                UserName = txbxName.Text.Trim(),
                Password = txbxPswrd.Text.Trim(),
                Email = txbxEmail.Text.Trim(),
                Country = txbxCountry.Text.Trim()
            };
            string result = client.UpdateUser(user, userName);
            lblSuccess.Visible = true;
            lblSuccess.Text = result.ToString();
        }

    }
}
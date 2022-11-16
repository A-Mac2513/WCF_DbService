using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfDbService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Service1 : IService1
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-S68UFCF;Initial Catalog=WCF;User ID=sa;Password=Secret55");

        // CREATE
        public string InsertUserDetails(UserDetails userInfo)
        {
            string Message;
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into RegistrationTable(UserName,Password,Country,Email) values(@UserName,@Password,@Country,@Email)", con);
            cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
            cmd.Parameters.AddWithValue("@Password", userInfo.Password);
            cmd.Parameters.AddWithValue("@Country", userInfo.Country);
            cmd.Parameters.AddWithValue("@Email", userInfo.Email);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = userInfo.UserName + " Details inserted successfully";
            }
            else
            {
                Message = userInfo.UserName + " Details not inserted successfully";
            }
            con.Close();
            return Message;
        }

        // READ
        public List<UserDetails> GetUserDetails()
        {
            List<UserDetails> allUsers = new List<UserDetails>();
            DataSet userData = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand("select UserName, Password, Email, Country from  RegistrationTable", con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(userData);
            cmd.ExecuteNonQuery();
            con.Close();
            for (int row = 0; row < userData.Tables[0].Rows.Count; row++)
            {
                UserDetails user = new UserDetails();
                user.UserName = userData.Tables[0].Rows[row][0].ToString();
                user.Password = userData.Tables[0].Rows[row][1].ToString();
                user.Email = userData.Tables[0].Rows[row][3].ToString();
                user.Country = userData.Tables[0].Rows[row][2].ToString();
                allUsers.Add(user);
            }
            return allUsers;
        }

        // READ
        public UserDetails GetUser(string username)
        {
            DataSet userData = new DataSet();
            UserDetails user = new UserDetails();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from  RegistrationTable where UserName = @UserName", con);
            cmd.Parameters.AddWithValue("@UserName", username);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(userData);
            cmd.ExecuteNonQuery();
            con.Close();
            user.UserName = userData.Tables[0].Rows[0][0].ToString();
            user.Password = userData.Tables[0].Rows[0][1].ToString();
            user.Email = userData.Tables[0].Rows[0][3].ToString();
            user.Country = userData.Tables[0].Rows[0][2].ToString();
            return user;
        }

        // UPDATE
        public string UpdateUser(UserDetails user, string username)
        {
            string Message;

            // Update info into DB
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE RegistrationTable SET " +
                "UserName=@NewUserName, " +
                "Password=@NewPassword, " +
                "Email=@NewEmail, " +
                "Country=@NewCountry " +
                "where UserName = @UserName", con);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@NewUserName", user.UserName);
            cmd.Parameters.AddWithValue("@NewPassword", user.Password);
            cmd.Parameters.AddWithValue("@NewEmail", user.Email);
            cmd.Parameters.AddWithValue("@NewCountry", user.Country);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = user.UserName + " Details inserted successfully";
            }
            else
            {
                Message = user.UserName + " Details not inserted successfully";
            }
            con.Close();
            return Message;
        }

        // DELETE
        public string DeleteUser(string username)
        {
            string Message;
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE from RegistrationTable where UserName = @UserName", con);
            cmd.Parameters.AddWithValue("@UserName", username);
            int result = cmd.ExecuteNonQuery();
            if (result >= 1)
            {
                Message = username + " deleted successfully -" + result;
            }
            else
            {
                Message = username + " not deleted successfully -" + result;
            }
            con.Close();
            return Message;
        }
    }
}

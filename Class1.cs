using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm.DAL
{
    class Class1
    {
        SqlConnection con = new SqlConnection(@"Data Source=SYSLP355;Initial Catalog=Registration;Integrated Security=True");

        /*public string FirstName;
        public string LastName;
        public string Address;
        public string District;
        public string State;
        public int Pin;
        public string Phone;
        public string Email;
        public string Gender;
        public string AadharId;
        public string DeletionId;*/

       /* public Class1(string FirstName, string LastName, string Address, string District, string State, int Pin, string Phone, string Email, string Gender, string AadharId)
        {
            this.First_Name = FirstName;
            this.Last_Name = LastName;
            this.Address = Address;
            this.District = District;
            this.State = State;
            this.Pin = Pin;
            this.Phone = Phone;
            this.Email = Email;
            this.Gender = Gender;
            this.Aadhar_Id = AadharId;

        }*/
        public void Insertion(string FirstName, string LastName, string Address, string District, string State, int Pin, string Phone, string Email, string Gender, string AadharId)

        {
            con.Open();
            string sql = "insert into NewRegistration(First_Name,Last_Name,Address,District,State,Pin,Phone,Email,Gender,Aadhar_ID) values('" + FirstName + "','" + LastName + "','" + Address + "','" + District + "','" + State + "','" + Pin + "','" + Phone + "','" + Email + "','" + Gender + "','" + AadharId + "')";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            adapter.SelectCommand.ExecuteNonQuery();
            con.Close();
        }public void Updation(string FirstName, string LastName, string Address, string District, string State, int Pin, string Phone, string Email, string Gender, string AadharId,string updationId)
        {
           con.Open();
            String sql = "Update NewRegistration set First_Name='"+FirstName +"',Last_Name='" + LastName + "',Address='" + Address + "',District='" + District + "',State='" + State + "',Pin='" + Pin + "',Phone='" + Phone + "',Email='" + Email + "',Gender='" + Gender + "',Aadhar_ID='" + AadharId + "' where Aadhar_Id='"+updationId+"'";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader dReader;
            dReader = command.ExecuteReader();
            con.Close();
        }
        public void Deletion(string Deletion_Id)
        {
            con.Open();
            String sql = "Delete From NewRegistration where Aadhar_ID = '" + Deletion_Id + "'";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader dReader;
            dReader = command.ExecuteReader();
            con.Close();
        }




    }
}

using RegistrationForm.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.DAL.Class1;
namespace RegistrationForm
{
    public partial class Registration : Form
    {
       SqlConnection con =new SqlConnection(@"Data Source=SYSLP355;Initial Catalog=Registration;Integrated Security=True");

        public String First_Name;
        public String Last_Name;
        public String Address;
        public String District;
        public String State;
        public int Pin;
        public String Phone;
        public String Email;
        public String Gender;
        public String Aadhar_Id;
        public String Deletion_Id;
        public String Updation_Id;

        Class1 obj1 = new Class1();

        public Registration()
        {
            InitializeComponent();
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        //Registration
        private void button1_Click(object sender, EventArgs e)
        {

          getValue();
          
            obj1.Insertion( First_Name,Last_Name,Address,District, State, Pin,Phone, Email,Gender,Aadhar_Id);
            MessageBox.Show("Registration compleated successfully");
            //obj.Insertion();

            clearField();
      
            view();
            
        }
       
        //clear
        private void button2_Click(object sender, EventArgs e)
        {

            clearField();


        }
        //Exit
        private void button3_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
        //View
        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            String sql = "Select * From NewRegistration";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

       //update
        private void button5_Click(object sender, EventArgs e)
        {


              getValue();
              obj1.Updation(First_Name,Last_Name,Address,District, State,Pin, Phone, Email,Gender,Aadhar_Id,Updation_Id);
         
             MessageBox.Show("Updated Successfully");
               
            clearField();
            view();
            
        }

        //Delete
        private void button6_Click(object sender, EventArgs e)
        {
             Deletion_Id = textBox9.Text;
           // getValue();
            obj1.Deletion(Deletion_Id); 
            MessageBox.Show("Deleted Successfully");
           
            view();
        }
        //viewfunction
        public void view()
        {
            con.Open();
            String sql = "Select * From NewRegistration";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }//clearmethod
        public void clearField()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox textBox = ctrl as TextBox;
                    textBox.Clear();
                }
                if (ctrl is ComboBox)
                {
                    ComboBox combo = ctrl as ComboBox;
                    combo.SelectedIndex = -1;
                }
                if (ctrl is RadioButton)
                {
                    RadioButton rb = ctrl as RadioButton;
                    rb.Checked = false;
                }
                if (ctrl is RichTextBox)
                {
                    RichTextBox rtb = ctrl as RichTextBox;
                    rtb.Clear();
                }
            }

        }//getvalue
        public void getValue()
        {
                First_Name = textBox1.Text;
                Last_Name = textBox2.Text;
                Address = richTextBox1.Text;
                District = comboBox1.Text;
                State = textBox3.Text;
                Pin = int.Parse(textBox4.Text);
                Phone = textBox5.Text;
                Email = textBox6.Text;
                Aadhar_Id = textBox7.Text;
                Updation_Id = textBox8.Text;
               // Deletion_Id =textBox9.Text;
                Gender = " ";


                if (radioButton1.Checked == true)

                {

                    Gender = "Male";

                }

                else if (radioButton2.Checked == true)

                {

                    Gender = "Female";

                }
                else
                {
                    Gender = "other";
                }

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            String sql = "Select * From NewRegistration where Aadhar_ID='"+textBox8.Text+"'";
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataReader dReader;
            dReader = cmd.ExecuteReader();
            if (dReader.Read())
            {
                textBox1.Text = dReader.GetString(0);
                textBox2.Text = dReader.GetString(1);
                richTextBox1.Text = dReader.GetString(2);
                comboBox1.Text = dReader.GetString(3);
                textBox3.Text = dReader.GetString(4);
                textBox4.Text = dReader.GetInt32(5).ToString();
                textBox5.Text = dReader.GetString(6);
                textBox6.Text = dReader.GetString(7);
                if (dReader.GetString(8)=="Male")
                {
                    radioButton1.Checked=true;
                }
                 else if(dReader.GetString(8)=="Female")
                {               
                    radioButton2.Checked = true;

                }
                else if(dReader.GetString(8) == "Others")
                {
                 radioButton3.Checked = true;

                }
                
                textBox7.Text = dReader.GetString(9);
            }
            con.Close();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}

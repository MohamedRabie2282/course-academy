using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Course_Academy
{
    public partial class Form2 : Form
    {
        int PanelWidth;
        bool isCollapsed;
        public Form2()
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panel1.Width;
            isCollapsed = false;
        }
        private void slidePanel(Button btn)
        {
            panelSide.Height = btn.Height;
            panelSide.Top = btn.Top;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panel1.Width = panel1.Width + 10;
                if (panel1.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panel1.Width = panel1.Width - 10;
                if (panel1.Width <= 55)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }
        private void btnMax_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timerTime_Tick_1(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblTime.Text = dt.ToString(" HH:mm:ss ");

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            slidePanel(btnSearch);
            panel5.Visible = false;
            panel5.Enabled = false;
            panel6.Visible = false; 
            panel6.Enabled = false;
           

        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            slidePanel(btninsert);
            panel5.Enabled = true;
            panel5.Visible = true;
        }        

        private void btnedit_Click(object sender, EventArgs e)
        {
            slidePanel(btnedit);
            panel6.Visible = true; 
            panel6.Enabled = true;
            

            int id = Convert.ToInt32(textBox1.Text);
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
           Form3 form = new Form3();
            form.Show();

        }



        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Control;
            button1.ForeColor = SystemColors.ControlText;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0, 26, 59);
            button1.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int phone;
            string city;
            string address;
            int coId;
            string name;

            string connectionString = "Data Source = LAPTOP-EMVCIH7G;Initial Catalog=CourseAcademyDB;Integrated Security=true";
            int stu_id = Convert.ToInt32(textBox1.Text);
            using (SqlConnection con = new SqlConnection(connectionString))
            { 
                con.Open();
                string query = "SELECT * FROM Student WHERE st_Pid = @stu_id";

                using (SqlCommand command = new SqlCommand(query, con))
                {

                    command.Parameters.AddWithValue("@stu_id", stu_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                             coId = reader.GetInt32(0); 
                             address = reader.GetString(2);
                             phone = reader.GetInt32(3);
                            name = reader.GetString(5);
                             textBox2.Text = address;
                            textBox3.Text = name.ToString();
                            textBox4.Text = phone.ToString();
                            textBox5.Text = coId.ToString();
                        }
                        else
                        {
                           MessageBox.Show("Student not found.");
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int co_id = 201;
            int id = Convert.ToInt32(textBox13.Text);
            string city = textBox12.Text;
            double number = Convert.ToDouble(textBox14.Text);
            int age = Convert.ToInt32(textBox7.Text);
            string name = textBox6.Text;
            string mail = textBox9.Text;
            double ssn = Convert.ToDouble(textBox8.Text);
            string connectionString = "Data Source = LAPTOP-EMVCIH7G;Initial Catalog=CourseAcademyDB;Integrated Security=true";

            // SQL insert statement
            string query = "INSERT INTO Student (CO_id, st_Pid, st_address, st_number, st_age, st_name, st_mail, st_ssn) " +
                           "VALUES (@co_id, @id, @city, @number, @age, @name, @mail, @ssn)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@co_id", co_id);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@number", number);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@mail", mail);
                    command.Parameters.AddWithValue("@ssn", ssn);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student inserted successfully.");
                        // Clear the text boxes after successful insertion
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert student.");
                    }
                }
            }
        
        }
        private void ClearTextBoxes()
        {
            // Clear all text boxes
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int studentId = Convert.ToInt32(textBox20.Text);
            int st_pid = Convert.ToInt32(textBox17.Text); // Ensure this is the correct text box for st_pid
            string phone = textBox16.Text; // Use string for phone
            string address = textBox11.Text;
            string name = textBox10.Text;
            int age = Convert.ToInt32(textBox15.Text);
            string mail = textBox19.Text; // Use the correct text box for mail
            double ssn = Convert.ToDouble(textBox18.Text);

            string connectionString = "Data Source=LAPTOP-EMVCIH7G;Initial Catalog=CourseAcademyDB;Integrated Security=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Student SET st_number = @phone, st_address = @address, st_age = @age, st_name = @name, st_Pid = @st_pid, st_mail = @mail, st_ssn = @ssn WHERE st_Pid = @studentId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@st_pid", st_pid);
                    command.Parameters.AddWithValue("@mail", mail);
                    command.Parameters.AddWithValue("@ssn", ssn);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@studentId", studentId); // Add this parameter

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student data updated successfully.");
                    }
                }
            }
        }

       
        private void button3_MouseHover(object sender, EventArgs e)
        {
            
        }

       

        private void button5_Click_1(object sender, EventArgs e)
        {
        
            }

       

        private void button6_Click_1(object sender, EventArgs e)
        {
            slidePanel(button6);
            panel6.Visible = true;
            panel6.Enabled = true;
        }
    }
}

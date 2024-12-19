using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Course_Academy
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

       

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int student = Convert.ToInt32(textBox1.Text);

            string connectionString = "Data Source=LAPTOP-EMVCIH7G;Initial Catalog=CourseAcademyDB;Integrated Security=true";

            string query = "DELETE FROM Student WHERE st_Pid = @studentId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentId", student);

                    int rowsAffected = command.ExecuteNonQuery();
                    Form3 form = new Form3();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student deleted successfully.");
                        foreach (Control control in form.Controls) // Replace panel1 with the name of your container
                        {
                            if (control is TextBox)
                            {
                                ((TextBox)control).Clear();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No student found with the specified ID.");
                    }
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True");
            InitializeComponent();
            for (int i = 1; i <= 4; i++)
            {
                try
                {
                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }
                    string query = $"SELECT news FROM News Where id= '" + i + "'";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                    sqlCmd.ExecuteNonQuery();
                    //sqlCmd.CommandType = CommandType.Text;
                    //sqlCmd.Parameters.AddWithValue("@Username", Username.Text);
                    //sqlCmd.Parameters.AddWithValue("@Password", Password.Password);
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    reader.Read();


                    if (i == 1)
                    {
                        n1.Text = reader["news"].ToString(); 
                    }
                    else if (i == 2)
                    {
                        n2.Text = reader["news"].ToString();
                    }
                    else if (i == 3)
                    {
                        n3.Text = reader["news"].ToString();
                    }
                    else if (i == 4)
                    {
                        n4.Text = reader["news"].ToString();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlcon.Close();
                }
            }

            }
           
       
        

        private void Athletes_Click(object sender, RoutedEventArgs e)
        {
            AthletesSearch s = new AthletesSearch();
            s.Show();
            s.text.Text = "Which athlete do you want to know about?";
            this.Close();
        }
    }

}

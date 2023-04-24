using System;
using System.Collections.Generic;
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
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True"); // needs a path


            if (Email.Text.Contains('@') && Password.Password.Length >= 8)
            {

                try
                {
                    sqlcon.Open();

                    string query = "INSERT INTO Sign_Up(Username,Email,Password) values ('" + this.Username.Text + "','" + this.Email.Text + "','" + this.Password.Password + "') ";

                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved");

                    Login li = new Login();
                    li.Show();
                    this.Close();

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
            else
            {
                MessageBox.Show("Either the password is less than 8 characters or your email does not contain '@'");
            }
        }
        private void Goback(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}

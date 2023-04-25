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
    /// Interaction logic for Events.xaml
    /// </summary>
    public partial class Events : Window
    {
        public Events()
        {
            InitializeComponent();
            fillcombobox();
        }

        public void fillcombobox()
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True");
            string query = "select * from Events";
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader myreader;

            try
            {
                sqlcon.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string sname = myreader.GetString(1);
                    Combobox.Items.Add(sname);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu();
            m.Username1.Text = UsernameE.Text;
            m.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True");
            Eventinfo p = new Eventinfo();
            try
            {

                sqlcon.Open();
                string query = $"Select * from Events where Venue = '" + Combobox.Text + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                p.Venue.Text = reader["Venue"].ToString();
                p.Date.Text = reader["Date"].ToString();
                p.Discipline.Text = reader["Discipline"].ToString();
                p.Winner.Text = reader["Winner"].ToString();

                p.name.Text = Combobox.Text;
                p.UsernameEI.Text = UsernameE.Text;
                p.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { sqlcon.Close(); }

            this.Close();
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

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
    /// Interaction logic for AthletesSearch.xaml
    /// </summary>
    public partial class AthletesSearch : Window
    {
        public AthletesSearch()
        {
            InitializeComponent();
        }
        //private void OnKeyDownHandler(object sender, KeyEventArgs e)
        //{
        //    SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True");
        //    Athletes p = new Athletes();
        //    try
        //    {

        //        sqlcon.Open();
        //        string query = $"Select * from Athletes where Name = '" + athlete.Text +"'";
        //        SqlCommand cmd = new SqlCommand(query, sqlcon);
        //        cmd.ExecuteNonQuery();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        reader.Read(); p.Show();

        //        p.Age.Text = reader["Age"].ToString();
        //        p.Nationality.Text = reader["Nationality"].ToString();
        //        p.Wins.Text = reader["Wins"].ToString();
        //        p.Podiums.Text = reader["Podiums"].ToString();

        //        p.name.Text = athlete.Text;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        MessageBox.Show("Check if you entered correctly the name");
        //    }
        //    finally { sqlcon.Close(); }

        //    this.Close();
        //}

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True");
            Athletes p = new Athletes();
            try
            {

                sqlcon.Open();
                string query = $"Select * from Athletes where Name = '" + athlete.Text + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read(); p.Show();

                p.Age.Text = reader["Age"].ToString();
                p.Nationality.Text = reader["Nationality"].ToString();
                p.Wins.Text = reader["Wins"].ToString();
                p.Podiums.Text = reader["Podiums"].ToString();

                p.name.Text = athlete.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Check if you entered correctly the name");
            }
            finally { sqlcon.Close(); }

            this.Close();
        }
    }
}

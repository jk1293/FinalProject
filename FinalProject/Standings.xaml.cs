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
    /// Interaction logic for Standings.xaml
    /// </summary>
    public partial class Standings : Window
    {
        public Standings()
        {
            InitializeComponent();
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True");
            //sqlcon.Open();
            //if (Combobox.Text == "Men Overall")
            //{
            //    try
            //    {
            //        string query = "Select * from MOStandings";
            //        SqlCommand cmd = new SqlCommand(query, sqlcon);
            //        cmd.ExecuteNonQuery();
            //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable();
            //        adapter.Fill(dt);
            //        data.ItemsSource = dt.DefaultView;
            //        adapter.Update(dt);
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message);
            //    }
            //    finally { sqlcon.Close(); }
            //}
            //else if (Combobox.Text == "Women Overall")
            //{
            //    try
            //    {
            //        string query = "Select * from WOStandings";
            //        SqlCommand cmd = new SqlCommand(query, sqlcon);
            //        cmd.ExecuteNonQuery();
            //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable();
            //        adapter.Fill(dt);
            //        data.ItemsSource = dt.DefaultView;
            //        adapter.Update(dt);
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message);
            //    }
            //    finally { sqlcon.Close(); }
            //}
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu();
            m.Username1.Text = UsernamR.Text;
            m.Show();
            this.Close();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True");
            sqlcon.Open();
            if (Combobox.Text == "Men Overall")
            {
                try
                {
                    string query = "Select * from MOStandings";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    data.ItemsSource = dt.DefaultView;
                    adapter.Update(dt);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally { sqlcon.Close(); }
            }
            else if (Combobox.Text == "Women Overall")
            {
                try
                {
                    string query = "Select * from WOStandings";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    data.ItemsSource = dt.DefaultView;
                    adapter.Update(dt);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally { sqlcon.Close(); }
            }
        }
    }
}

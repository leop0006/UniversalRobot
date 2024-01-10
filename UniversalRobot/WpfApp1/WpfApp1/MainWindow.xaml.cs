using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Btt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leopold\Desktop\UniversalRobot\WpfApp1\WpfApp1\Database1.mdf;Integrated Security=True");
                con.Open();
                //User is in the table of the database Users
                string add_data = "SELECT * FROm [dbo].[Users] where username=@Username and password=@Password";
                SqlCommand cmd = new SqlCommand(add_data, con);

                cmd.Parameters.AddWithValue("@Username", Username.Text); 
                cmd.Parameters.AddWithValue("@Password", Password.Text);
                cmd.ExecuteNonQuery();
                int Count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                Username.Text = "";
                Password.Text = "";

                if (Count > 0)
                {

                MainWindow w1 = new MainWindow();
                this.Close();
                w1.Show();
                }
                else
                {
                    MessageBox.Show("Password or Username is not correct");
                }
            }
            catch
            {

            }

        }


    }
}
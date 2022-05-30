
using CinemaTickets.Classes;
using CinemaTickets.view.AuthPages;
using System.Windows;
using System.Windows.Controls;

namespace CinemaTickets
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public MainWindow mainWindow;

        public AdminPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }


        private void button_LoginAdmin_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_LoginAdmin.Text.Length > 0)
            {
                if(passwordBox_Admin.Password.Length > 0)
                {
                    DataUsers.dt_user = DatabaseConnection.Select($"SELECT * FROM cinema.users WHERE login = '{textBox_LoginAdmin.Text}' AND pass = '{passwordBox_Admin.Password}' AND status = 'admin'");
                    if(DataUsers.dt_user.Rows.Count > 0)
                    {
                        DataUsers.status = DataUsers.dt_user.Rows[0]["status"].ToString() == "admin";

                        //CinemaWindow cinemaWindow = new CinemaWindow();
                        //cinemaWindow.ShowDialog();
                        mainWindow.Hide();
                        CinemaWindow cinemaWindow = new CinemaWindow(mainWindow);
                        cinemaWindow.ShowDialog();
                    }

                    else
                        MessageBox.Show("Login not found");
                }
                else
                    MessageBox.Show("Enter password");
            }
            else
                MessageBox.Show("Enter login");
            textBox_LoginAdmin.Text = string.Empty;
            passwordBox_Admin.Password = string.Empty;
        }
    }
}

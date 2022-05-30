using CinemaTickets.Classes;
using CinemaTickets.view.AuthPages;
using System.Windows;
using System.Windows.Controls;

namespace CinemaTickets
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public MainWindow mainWindow;

        public UserPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void button_LoginUser_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_LoginUser.Text.Length > 0)
            {
                if(passwordBox_User.Password.Length > 0)
                {
                    DataUsers.dt_user = DatabaseConnection.Select($"SELECT * FROM cinema.users WHERE login = '{textBox_LoginUser.Text}' AND pass = '{passwordBox_User.Password}' AND status = 'user'");
                    if(DataUsers.dt_user.Rows.Count > 0)
                    {
                        DataUsers.status = DataUsers.dt_user.Rows[0]["status"].ToString() == "admin";
                        textBox_LoginUser.Text = string.Empty;
                        passwordBox_User.Password = string.Empty;
                        mainWindow.Hide();
                        CinemaWindow cinemaWindow = new CinemaWindow(mainWindow);
                        cinemaWindow.ShowDialog();
                    }

                    else
                        MessageBox.Show($"Login not found");
                }
                else
                    MessageBox.Show("Enter password");
            }
            else
                MessageBox.Show("Enter login");
            textBox_LoginUser.Text = string.Empty;
            passwordBox_User.Password = string.Empty;
        }

        private void button_RegistrationUser_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPageStart(MainWindow.PagesStart.registration);
        }
    }
}
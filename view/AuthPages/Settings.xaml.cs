using CinemaTickets.Classes;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CinemaTickets.view.AuthPages
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public CinemaWindow cinemaWindow;
        public Settings(CinemaWindow _cinemaWindow)
        {
            InitializeComponent();
            cinemaWindow = _cinemaWindow;

        }

        private void button_NewUsername_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_OldUsername.Text.Length > 0)
            {
                if(textBox_OldUsername.Text == DataUsers.dt_user.Rows[0][1].ToString())
                {
                    DataTable dt_newUser = DatabaseConnection.Select($"SELECT login FROM cinema.users WHERE login = '{textBox_NewUsername.Text}'");
                    if(dt_newUser.Rows.Count == 0)
                    {
                        DatabaseConnection.Select($"UPDATE users,orders " +
                            $"SET users.login = REPLACE(users.login,'{DataUsers.dt_user.Rows[0]["login"]}','{textBox_NewUsername.Text}') , orders.login = REPLACE(orders.login,'{DataUsers.dt_user.Rows[0]["login"]}','{textBox_NewUsername.Text}') " +
                            $"WHERE users.login IS NOT NULL and orders.login IS NOT NULL;");
                        DataUsers.dt_user.Rows[0]["login"] = textBox_NewUsername.Text;
                        MessageBox.Show("Login changed");

                        //MessageBox.Show("Login changed");
                    }
                    else
                        MessageBox.Show("Login already used.Try another login");
                }
                else
                    MessageBox.Show("Wrong old username");
            }
            else
                MessageBox.Show("Enter old username");
            textBox_OldUsername.Text = "";
            textBox_NewUsername.Text = "";
        }

        private void button_passwordBox_settings_Click(object sender, RoutedEventArgs e)
        {
            if(passwordBox_old_password.Password.Length > 0)
            {
                if(passwordBox_old_password.Password == DataUsers.dt_user.Rows[0][2].ToString())
                {
                    if(passwordBox_settings.Password.Length > 0)
                    {
                        if(passwordBox_again_settings.Password.Length > 0)
                        {
                            if(passwordBox_settings.Password == passwordBox_again_settings.Password)
                            {
                                DatabaseConnection.Select($"UPDATE users " +
                                    $"SET pass = REPLACE(pass, '{DataUsers.dt_user.Rows[0]["pass"]}','{passwordBox_settings.Password}') " +
                                    $"WHERE users.login = '{DataUsers.dt_user.Rows[0]["login"]}'");
                                DataUsers.dt_user.Rows[0]["pass"] = passwordBox_settings.Password;

                                MessageBox.Show("Password changed");
                            }
                            else
                                MessageBox.Show("Passwords are not equal");
                        }
                        else
                            MessageBox.Show("Enter new password again");
                    }
                    else
                        MessageBox.Show("Enter new password");
                }
                else
                    MessageBox.Show("Wrong old password");
            }
            else
                MessageBox.Show("Enter old password");
            passwordBox_old_password.Password = "";
            passwordBox_settings.Password = "";
            passwordBox_again_settings.Password = "";
        }

        private void button_toAdmin_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_toAdmin.Text.Length > 0)
            {
                DatabaseConnection.Select($"INSERT INTO cinema.asks (user, question) VALUES ('{DataUsers.dt_user.Rows[0]["login"]}', '{textBox_toAdmin.Text}');");
                textBox_toAdmin.Text = "";
                MessageBox.Show("Question sended");
            }
            else
                MessageBox.Show("Ask your question");
        }

        private void button_delete_account_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure that you want to delete account?", "Delete account", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(result == MessageBoxResult.Yes)
            {
                DatabaseConnection.Select($"DELETE FROM cinema.users WHERE login = '{DataUsers.dt_user.Rows[0]["login"]}';" +
                                          $"DELETE FROM cinema.orders WHERE login = '{DataUsers.dt_user.Rows[0]["login"]}'");
                MessageBox.Show("Logout");
                cinemaWindow.Close();
            }
        }
    }
}

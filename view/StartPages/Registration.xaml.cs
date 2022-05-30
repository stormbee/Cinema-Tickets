using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CinemaTickets
{
    ///TODO: добавить проверку пароля на длину
    ///      добавить проверку имени на длину
    ///      добавить ввод эмейла или вместо логина сделать мейл и проверку на него и на длину
    ///      В АДМИНКУ:
    ///      удаление, редактирование и добавление фильмов. в xaml поставить атрибуты на редактирование
    ///      назначение новых пользователей админами. под вопросом
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public MainWindow mainWindow;

        public Registration(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void button_RegistrationUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(textBox_LoginUser.Text.Length > 0)
                {
                    if(passwordBox_User.Password.Length > 0)
                    {
                        if(passwordBox_User.Password == passwordBox_User_Again.Password)
                        {
                            DataTable dt_newUser = DatabaseConnection.Select($"SELECT login FROM cinema.users WHERE login = '{textBox_LoginUser.Text}'");
                            if(dt_newUser.Rows.Count == 0)
                            {
                                DatabaseConnection.Select("INSERT INTO cinema.users (login,pass, status)" +
                                                         $"VALUES ('{textBox_LoginUser.Text}','{passwordBox_User.Password}' , 'user')");
                                MessageBox.Show("Registration successfull");
                                mainWindow.OpenPageStart(MainWindow.PagesStart.login);
                            }
                            else
                                MessageBox.Show("Try anoter login");
                        }
                        else
                            MessageBox.Show("Again password is wrong");
                    }
                    else
                        MessageBox.Show("Enter Password");
                }
                else
                    MessageBox.Show("Enter login");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button_CancelRegistration_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPageStart(MainWindow.PagesStart.login);
        }
    }
}
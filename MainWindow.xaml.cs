using System.Windows;

namespace CinemaTickets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            Main.Content = new UserPage(this);

        }
        public enum PagesStart
        {
            login,
            registration
        }


        public void OpenPageStart(PagesStart pages)
        {
            if(pages == PagesStart.login)
                Main.Navigate(new UserPage(this));
            else if(pages == PagesStart.registration)
                Main.Navigate(new Registration(this));


        }
        private void Button_ClickPage1(object sender, RoutedEventArgs e)
        {
            Main.Content = new AdminPage(this);
        }

        private void Button_ClickPage2(object sender, RoutedEventArgs e)
        {
            Main.Content = new UserPage(this);
        }

    }
}

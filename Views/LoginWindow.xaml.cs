using System.Windows;

namespace Painel240hz
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ValidateKey_Click(object sender, RoutedEventArgs e)
        {
            string key = txtKey.Text;

            if (key == "240HZ-ACCESS")
            {
                MainWindow main = new MainWindow();
                main.Show();

                this.Close();
            }
            else
            {
                txtStatus.Text = "Licença inválida";
            }
        }
    }
}
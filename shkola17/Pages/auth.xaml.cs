using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace shkola17.Pages
{
    /// <summary>
    /// Логика взаимодействия для auth.xaml
    /// </summary>
    public partial class auth : Page
    {
        public auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var CurentUser = App.Context.user
                .FirstOrDefault(p => p.Login == TBox.Text && p.Pass == PBox.Password);
            if (CurentUser != null)
            {
                App.CurentUser = CurentUser;
                NavigationService.Navigate(new Pages.Admin());
                //Manager.fframe.Navigate(new Pages.Page2(null));
            }
            else
            {
                MessageBox.Show("Пользователь не найдет", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.fframe.Navigate(new Pages.Reg());
        }
    }
}

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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
       
        public Reg()
        {
            InitializeComponent();
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {  
            var Client = new Entities.user
            {
                FIO_upravl = FIO.Text,
                Login = Log.Text,
                Pass = Pass.Text,

            };
            App.Context.user.Add(Client);
            App.Context.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно");
            Manager.fframe.GoBack();

        }

        private void Page_Is_Visible_Changed(object sender, DependencyPropertyChangedEventArgs e)
        {
            Entities.invent_tehnikaEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
        }
    }
}

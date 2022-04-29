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
    /// Логика взаимодействия для addeditsotr.xaml
    /// </summary>
    public partial class addeditsotr : Page
    {
        private Entities.sotr _currentcar = new Entities.sotr();
        public addeditsotr(Entities.sotr selectedinv)
        {
            InitializeComponent();
            if (selectedinv != null)
                _currentcar = selectedinv;
            DataContext = _currentcar;
           
        }

        private void add(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentcar.FIO_sotr))
                errors.AppendLine("Добавьте ФИО");
            if (string.IsNullOrWhiteSpace(_currentcar.teleph))
                errors.AppendLine("Добавьте телефон");
            if (string.IsNullOrWhiteSpace(_currentcar.Doljnost))
                errors.AppendLine("Добавьте Должность");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_currentcar.ID_sotr == 0)
            {
                Entities.invent_tehnikaEntities1.GetContext().sotr.Add(_currentcar);
                MessageBox.Show("Добавление выполнено");
                Manager.fframe.GoBack();
            }
            try
            {
                Entities.invent_tehnikaEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация изменена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void isvisible(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.invent_tehnikaEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

            }
        }
    }
}

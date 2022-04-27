using Microsoft.Win32;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace shkola17.Pages
{
    /// <summary>
    /// Логика взаимодействия для redact.xaml
    /// </summary>
    public partial class redact : Page
    {
        private Entities.Invent _currentcar = new Entities.Invent();
        //private Entities.Invent _currentcar = null;
        public redact(Entities.Invent selectedinv)
        {
            InitializeComponent();
            if (selectedinv != null)
                _currentcar = selectedinv;
            DataContext = _currentcar;
            UpdatateCar();
        }
        private void UpdatateCar()
        {
            var _currentcar = Entities.invent_tehnikaEntities1.GetContext().Invent.ToList();



        }
        private void add(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentcar.cabinet))
                errors.AppendLine("Добавьте кабинет");
            if (string.IsNullOrWhiteSpace(_currentcar.Tehnika))
                errors.AppendLine("Добавьте информацию о технике");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_currentcar.ID_invent == 0)
            {
                Entities.invent_tehnikaEntities1.GetContext().Invent.Add(_currentcar);
                MessageBox.Show("Добавление выполнено");
                Manager.fframe.GoBack();
            }
            try
            {
                Entities.invent_tehnikaEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация изменена");
            }
            catch(Exception ex)
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

        private void Addimage(object sender, RoutedEventArgs e)
        {

        }
    }
}

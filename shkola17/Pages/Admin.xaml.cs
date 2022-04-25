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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        private Entities.Invent _currentcar = new Entities.Invent();
        public Admin(Entities.Invent Selectinvent)
        {
            InitializeComponent();
            if (Selectinvent != null)
                _currentcar = Selectinvent;
            DataContext = _currentcar;
            Updatate();
        }

        private void Add_Color(object sender, RoutedEventArgs e)
        {
            Manager.fframe.Navigate(new Pages.redact(null));
        }

        private void buttondel_Click(object sender, RoutedEventArgs e)
        {
            var CarsForRemoving = LView.SelectedItems.Cast<Entities.Invent>().ToList();


            if (MessageBox.Show($"Вы уверены, что хотите удалить данные о " + $"{CarsForRemoving.Count}столбце", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.invent_tehnikaEntities1.GetContext().Invent.RemoveRange(CarsForRemoving);
                    Entities.invent_tehnikaEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Удаление завершено");
                    LView.ItemsSource = Entities.invent_tehnikaEntities1.GetContext().Invent.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


            }
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Updatate();
        }
        private void Updatate()
        {
            var _currentcar = Entities.invent_tehnikaEntities1.GetContext().Invent.ToList();
            _currentcar = _currentcar.Where(p => p.cabinet.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
            LView.ItemsSource = _currentcar.OrderBy(p => p.cabinet).ToList();
        }
        private void zakazbutton(object sender, RoutedEventArgs e)
        {
            Manager.fframe.Navigate(new Pages.redact((sender as Button).DataContext as Entities.Invent));
        }

        private void Page_Is_Visible_Changed(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.invent_tehnikaEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LView.ItemsSource = Entities.invent_tehnikaEntities1.GetContext().Invent.ToList();
            }
        }

        private void info_Color(object sender, RoutedEventArgs e)
        {
            Manager.fframe.Navigate(new Pages.info());
        }
    }
}

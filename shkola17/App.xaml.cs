using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace shkola17
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entities.invent_tehnikaEntities Context
        { get; set; } = new Entities.invent_tehnikaEntities();

        public static Entities.user CurentUser = null;

        public Entities.Invent _currentinvent = new Entities.Invent();

      
    }
}

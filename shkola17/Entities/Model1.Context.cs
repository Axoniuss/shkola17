﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace shkola17.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class invent_tehnikaEntities1 : DbContext
    {
        private static Entities.invent_tehnikaEntities1 _context;
        public invent_tehnikaEntities1()
            : base("name=invent_tehnikaEntities1")
        {
        }
        public static Entities.invent_tehnikaEntities1 GetContext()
        {
            if (_context == null)
                _context = new Entities.invent_tehnikaEntities1();
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Invent> Invent { get; set; }
        public virtual DbSet<model> model { get; set; }
        public virtual DbSet<sotr> sotr { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<user> user { get; set; }
    }
}

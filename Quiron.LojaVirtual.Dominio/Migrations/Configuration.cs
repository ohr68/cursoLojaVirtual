namespace Quiron.LojaVirtual.Dominio.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Quiron.LojaVirtual.Dominio.Repositorio.EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Quiron.LojaVirtual.Dominio.Repositorio.EfDbContext";
        }

        protected override void Seed(Quiron.LojaVirtual.Dominio.Repositorio.EfDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

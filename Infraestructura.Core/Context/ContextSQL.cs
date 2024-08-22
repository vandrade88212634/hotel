namespace Infraestructura.Core.Context.SQLServer
{
    using Infraestructura.Entity.Entities;
    using Microsoft.EntityFrameworkCore;

    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class ContextSql : DbContext
    {
        public ContextSql(DbContextOptions dbContextOptions)
           : base(dbContextOptions)
        {
        }

        #region DbSet Entities





    
       
        
        public DbSet<CiudadesEntity> CiudadesEntity { get; set; }
        public DbSet<TipoDocumentoEntity> TipoDocumentoEntity { get; set; }

        public DbSet<DetalleReservaEntity> DetalleReservaEntity { get; set; }
        public DbSet<GenerosEntity> GenerosEntity { get; set; }
        public DbSet<HabitacionesEntity> HabitacionesEntity { get; set; }
        public DbSet<OcupacionEntity> OcupacionEntity { get; set; }
        public DbSet<ReservasEntity> ReservasEntity { get; set; }
        public DbSet<HotelEntity> HotelEntity { get; set; }
        public DbSet<TipoHabitacionEntity> TipoHabitacionEntity { get; set; }




        #endregion DbSet Entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);





        }
    }
}
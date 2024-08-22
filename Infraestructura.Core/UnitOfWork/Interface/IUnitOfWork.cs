namespace Infraestructura.Core.UnitOfWork.Interface
{
    using Infraestructura.Core.Repository;
    using Infraestructura.Entity.Entities;

    public interface IUnitOfWork
    {
        #region Repository


         Repository<CiudadesEntity> CiudadesRepository { get; }
         Repository<TipoDocumentoEntity> TipoDocumentoRepository { get; }
         Repository<TipoHabitacionEntity> TipoHabitacionRepository { get; }
        Repository<GenerosEntity> GenerosRepository { get; }
         Repository<HabitacionesEntity> HabitacionesRepository { get; }
        Repository<HotelEntity> HotelRepository { get; }
        Repository<OcupacionEntity> OcupacionRepository { get; }
        Repository<ReservasEntity> ReservasRepository { get; }
        Repository<DetalleReservaEntity> DetalleReservaRepository { get; }


        #endregion Repository

        int Save();

        //IEnumerable<T> ExecuteSqlStoreProcedure<T>(string storeProcedureName, Dictionary<string, object> parameters);

    }

}
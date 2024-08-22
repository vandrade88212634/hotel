using Dominio.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.Servicios.Interfaces
{
    public interface IReservasServices
    {
        List<HabitacionesDto> BuscaHabitacion(BuscaHabitacionDto Busqueda);
        List<ReservasDto> GetAllReservas();
        DetalleReservaTotalDto GetDetalleReservas(int idReserva);
        ReservasDto insertReserva(ReservasDto reserva);

    }
}

using Dominio.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.Servicios.Interfaces
{
    public interface IHotelServices
    {
        List<HotelDto> GetAllHotelsbyCity(int idCity);
        HotelDto GetAllHotelsbyId(int idHotel);
        HotelDto InsertHotel(HotelDto hotel);
        HotelDto EditHotel(HotelDto hotel);
        HotelDto ActivaDesactivaHotel(HotelDto hotel, int ActivaDesactiva);
        List<HabitacionesDto> GetAllHabitacionesbyHotel(int idHotel);
        List<HabitacionesDto> GetAllHabitacionesbyTipo(int idTipo);
        HabitacionesDto InsertHabitacion(HabitacionesDto habitacion);
        HabitacionesDto EditHabitacion(HabitacionesDto habitacion);
        HabitacionesDto ActivaDesactivaHabitacion(HabitacionesDto habitacion, int ActivaDesactiva);
    }
}

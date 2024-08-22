using Common.Utils.Utils.Interface;
using Dominio.Servicio.DTO;
using Dominio.Servicio.Servicios.Interfaces;
using Infraestructura.Core.UnitOfWork.Interface;
using Infraestructura.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.Servicios
{
    public class HotelServices : IHotelServices
    {
        #region Attributes
        public readonly IUnitOfWork unitOfWork;
        private readonly IUtils utils;
        #endregion Attributes
        #region Constructor
        public HotelServices( IUnitOfWork UnitOfWork, IUtils utils)
        {

            this.unitOfWork = UnitOfWork;
            this.utils = utils;
        }

        #endregion Constructor

        #region methods

        public List<HotelDto> GetAllHotelsbyCity(int idCity)
        {

            List<HotelDto> hotels = (from h in this.unitOfWork.HotelRepository.AsQueryable() 
                                     join c in this.unitOfWork.CiudadesRepository.AsQueryable() on h.IdCiudades equals c.IdCiudades
                                     where h.IdCiudades == idCity && h.Activo == 1
                                     select new HotelDto
                                     {
                                         IdHotel = h.IdHotel,
                                         RazonSocial = h.RazonSocial,
                                         Direccion = h.Direccion,
                                         TelReservas = h.TelReservas,
                                         NombreCiudades = c.Nombre,
                                         IdCiudades = h.IdCiudades,
                                         IsSuccess = true,
                                         Message = "Proceso Exitoso"

                                     }
                                     ).ToList();
            return hotels;

        }

        public HotelDto GetAllHotelsbyId(int idHotel)
        {

            HotelDto hotel = (from h in this.unitOfWork.HotelRepository.AsQueryable()
                              join c in this.unitOfWork.CiudadesRepository.AsQueryable() on h.IdCiudades equals c.IdCiudades
                              where h.IdHotel == idHotel
                              select new HotelDto
                              {
                                  IdHotel = h.IdHotel,
                                  RazonSocial = h.RazonSocial,
                                  Direccion = h.Direccion,
                                  TelReservas = h.TelReservas,
                                  NombreCiudades = c.Nombre,
                                  IdCiudades = h.IdCiudades,
                                  IsSuccess = true,
                                  Message = "Proceso Exitoso"

                              }
                                     ).FirstOrDefault();
            return hotel;

        }


        public HotelDto InsertHotel(HotelDto hotel)
        {

            HotelEntity hotelData = new HotelEntity();

            hotelData.TelReservas = hotel.TelReservas;
            hotelData.IdCiudades = hotel.IdCiudades;
            hotelData.RazonSocial = hotel.RazonSocial;
            hotelData.Direccion = hotel.Direccion;
            hotelData.Activo = hotel.Activo;
            this.unitOfWork.HotelRepository.Insert( hotelData );
            this.unitOfWork.Save();

            hotel.IsSuccess = true;
            hotel.Message = "Proceso Exitoso";
            return hotel;

        }

        public HotelDto EditHotel(HotelDto hotel)
        {

            HotelEntity hotelData = this.unitOfWork.HotelRepository.Find(x=> x.IdHotel == hotel.IdHotel);
            if (hotelData != null)
            {
                hotelData.TelReservas = hotel.TelReservas;
                hotelData.IdCiudades = hotel.IdCiudades;
                hotelData.RazonSocial = hotel.RazonSocial;
                hotelData.Direccion = hotel.Direccion;
                this.unitOfWork.HotelRepository.Update(hotelData);
                this.unitOfWork.Save();

                hotel.IsSuccess = true;
                hotel.Message = "Proceso Exitoso";
            }
            else
            {
                hotel.IsSuccess= false;
                hotel.Message = "Hotel No encontrado";


            }
            return hotel;

        }

        public HotelDto ActivaDesactivaHotel(HotelDto hotel, int ActivaDesactiva)
        {
            HotelEntity hotelData = this.unitOfWork.HotelRepository.Find(x => x.IdHotel == hotel.IdHotel);
            if (hotelData != null)
            {
                hotelData.Activo = ActivaDesactiva;
                this.unitOfWork.HotelRepository.Update(hotelData);
                this.unitOfWork.Save();
                hotel.IsSuccess = true;
                hotel.Message = "Proceso realizado con Exito";


            }
            else
            {
                hotel.IsSuccess = false;
                hotel.Message = "Hotel No encontrado";


            }
            return hotel;
        }

        public List<HabitacionesDto> GetAllHabitacionesbyHotel(int idHotel)
        {
            List<HabitacionesDto> habitaciones= (from hb in this.unitOfWork.HabitacionesRepository.AsQueryable()
                                                 join t in this.unitOfWork.TipoHabitacionRepository.AsQueryable() on hb.IdTipo equals t.IdTipoHabitacion
                                                 where hb.IdHotel == idHotel && hb.Activo == 1
                                                 select new HabitacionesDto
                                                 {
                                                     IdHotel = hb.IdHotel,
                                                     Activo = hb.Activo,
                                                     IdHabitaciones = hb.IdHabitaciones,
                                                     IdTipo = hb.IdTipo,
                                                     NombreTipo = t.Nombre,
                                                     Numero = hb.Numero,
                                                     Piso = hb.Piso,
                                                     Ubicacion = hb.Ubicacion,
                                                     PrecioNoche= hb.PrecioNoche,
                                                     ValorImpuestos= hb.ValorImpuestos

                                                 }).ToList();
          return habitaciones;
        }

       

        public List<HabitacionesDto> GetAllHabitacionesbyTipo(int idTipo)
        {
            List<HabitacionesDto> habitaciones = (from hb in this.unitOfWork.HabitacionesRepository.AsQueryable()
                                                  join t in this.unitOfWork.TipoHabitacionRepository.AsQueryable() on hb.IdTipo equals t.IdTipoHabitacion
                                                  where hb.IdTipo == idTipo && hb.Activo == 1
                                                  select new HabitacionesDto
                                                  {
                                                      IdHotel = hb.IdHotel,
                                                      Activo = hb.Activo,
                                                      IdHabitaciones = hb.IdHabitaciones,
                                                      IdTipo = hb.IdTipo,
                                                      NombreTipo = t.Nombre,
                                                      Numero = hb.Numero,
                                                      Piso = hb.Piso,
                                                      Ubicacion = hb.Ubicacion,
                                                      PrecioNoche = hb.PrecioNoche,
                                                      ValorImpuestos = hb.ValorImpuestos

                                                  }).ToList();
            return habitaciones;
        }

        public HabitacionesDto InsertHabitacion(HabitacionesDto habitacion)
        {
            HabitacionesEntity habitacionData = new HabitacionesEntity();
            habitacionData.Activo = 1;
            habitacionData.PrecioNoche = habitacion.PrecioNoche;
            habitacionData.Ubicacion = habitacion.Ubicacion;
            habitacionData.IdTipo = habitacion.IdTipo;
            habitacionData.IdHotel = habitacion.IdHotel;
            habitacionData.Numero = habitacion.Numero;
            habitacionData.Piso = habitacion.Piso;
            habitacionData.ValorImpuestos = habitacion.ValorImpuestos;
            this.unitOfWork.HabitacionesRepository.Insert(habitacionData);
            this.unitOfWork.Save();
            habitacion.IsSuccess = true;
            habitacion.Message = "Proceso realizado con Exito";
            return habitacion;
        }

        public HabitacionesDto EditHabitacion(HabitacionesDto habitacion)
        {
            HabitacionesEntity habitacionData = this.unitOfWork.HabitacionesRepository.Find(x => x.IdHabitaciones == habitacion.IdHabitaciones);
           if (habitacionData != null) {
                habitacionData.Activo = 1;
                habitacionData.PrecioNoche = habitacion.PrecioNoche;
                habitacionData.Ubicacion = habitacion.Ubicacion;
                habitacionData.IdTipo = habitacion.IdTipo;
                habitacionData.IdHotel = habitacion.IdHotel;
                habitacionData.Numero = habitacion.Numero;
                habitacionData.Piso = habitacion.Piso;
                habitacionData.ValorImpuestos = habitacion.ValorImpuestos;
                this.unitOfWork.HabitacionesRepository.Update(habitacionData);
                this.unitOfWork.Save();
                habitacion.IsSuccess = true;
                habitacion.Message = "Proceso realizado con Exito";
            }
             else
            {
                habitacion.IsSuccess = false;
                habitacion.Message = "habitación No encontrada";

            }
            return habitacion;
        }

        public HabitacionesDto ActivaDesactivaHabitacion(HabitacionesDto habitacion, int ActivaDesactiva)
        {
            HabitacionesEntity habitacionData = this.unitOfWork.HabitacionesRepository.Find(x => x.IdHabitaciones == habitacion.IdHabitaciones);
            if (habitacionData != null)
            {
                habitacionData.Activo = ActivaDesactiva;
                this.unitOfWork.HabitacionesRepository.Update(habitacionData);
                this.unitOfWork.Save();
                habitacion.IsSuccess = true;
                habitacion.Message = "Proceso realizado con Exito";


            }
            else
            {
                habitacion.IsSuccess = false;
                habitacion.Message = "Hotel No encontrado";


            }
            return habitacion;
        }




        #endregion methods

    }
}

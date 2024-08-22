using Common.Utils.Utils.Interface;
using Dominio.Servicio.DTO;
using Dominio.Servicio.Servicios.Interfaces;
using Infraestructura.Core.UnitOfWork.Interface;
using Infraestructura.Entity.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.Servicios
{
    public class ReservasServices : IReservasServices
    {
        #region Attributes
        public readonly IUnitOfWork unitOfWork;
        private readonly IUtils utils;
        #endregion Attributes
        #region Constructor
        public ReservasServices(IUnitOfWork UnitOfWork, IUtils utils)
        {

            this.unitOfWork = UnitOfWork;
            this.utils = utils;
        }

        #endregion Constructor

        #region Methods

        public List<HabitacionesDto> BuscaHabitacion(BuscaHabitacionDto Busqueda)
        {


            List<HabitacionesDto> habitaciones = (from hb in this.unitOfWork.HabitacionesRepository.AsQueryable()
                                                join h in this.unitOfWork.HotelRepository.AsQueryable() on hb.IdHotel equals h.IdHotel
                                                join t in this.unitOfWork.TipoHabitacionRepository.AsQueryable() on hb.IdTipo equals t.IdTipoHabitacion
                                                where hb.Activo == 1 && (Busqueda.IdHotel == 0 || (Busqueda.IdHotel == hb.IdHotel)) &&
                                                       (Busqueda.IdTipo == 0 || Busqueda.IdTipo== hb.IdTipo)  &&
                                                      (Busqueda.IdCiudades == 0 || Busqueda.IdCiudades == h.IdCiudades)
                                                select new HabitacionesDto
                                                {
                                                    IdHabitaciones = hb.IdHabitaciones,
                                                    IdHotel = hb.IdHotel,
                                                    IdTipo = hb.IdTipo,
                                                    IsSuccess = true,
                                                    Message = "Proceso realizado con Exito",
                                                    NombreTipo = t.Nombre,
                                                    Numero = hb.Numero,
                                                    Piso = hb.Piso,
                                                    PrecioNoche = hb.PrecioNoche,
                                                    Ubicacion = hb.Ubicacion,
                                                    ValorImpuestos = hb.ValorImpuestos
                                                }).ToList();

            //Verificando disponibilidad

            foreach(var ihabitacion in habitaciones)
            {
                List<disponibleDto> disponibilidad = (from o in this.unitOfWork.OcupacionRepository.AsQueryable()
                                                      join hb in this.unitOfWork.HabitacionesRepository.AsQueryable() on o.IdHabitacion equals hb.IdHabitaciones
                                                      where o.IdHabitacion == ihabitacion.IdHabitaciones &&
                                                      (Busqueda.FecEntrada == null || o.Fecha >= Busqueda.FecEntrada) &&
                                                      (Busqueda.FecSalida == null || o.Fecha <=  Busqueda.FecSalida)
                                                      select new disponibleDto
                                                      {
                                                          Fecha = o.Fecha,
                                                          IdHabitacion = o.IdHabitacion,
                                                          Numero = hb.Numero,
                                                          PrecioNoche = hb.PrecioNoche

                                                      }).ToList();
                if (disponibilidad.Any())
                {
                    ihabitacion.Activo = 0;
                }

            }


            List<HabitacionesDto> habitacionesDisponibles = habitaciones.FindAll(x => x.Activo == 1);


            return habitacionesDisponibles;

        }

        public List<ReservasDto> GetAllReservas()
        {
            List<ReservasDto> reservas = (from r in this.unitOfWork.ReservasRepository.AsQueryable()
                                          join h in this.unitOfWork.HotelRepository.AsQueryable() on r.IdHotel equals h.IdHotel
                                          join c in this.unitOfWork.CiudadesRepository.AsQueryable() on h.IdCiudades equals c.IdCiudades
                                          select new ReservasDto
                                          {
                                              CantidadHuespedes = r.CantidadHuespedes,
                                              FecEntrada = r.FecEntrada,
                                              FecSalida = r.FecSalida,
                                              IdHotel = r.IdHotel,
                                              NombreHotel = h.RazonSocial,
                                              IdCiudad = r.IdCiudad,
                                              NombreCiudad = h.RazonSocial,
                                              IdReservas = r.IdReservas,


                                          }).ToList();
            return reservas;

        }

        public DetalleReservaTotalDto GetDetalleReservas(int idReserva)
        {
            List<DetalleReservaDto> detalleReserva = (from d in this.unitOfWork.DetalleReservaRepository.AsQueryable()
                                          join g in this.unitOfWork.GenerosRepository.AsQueryable() on d.IdGenero equals g.IdGeneros
                                          join t in this.unitOfWork.TipoDocumentoRepository.AsQueryable() on d.IdTipoDocumento equals t.IdTipoDocumento
                                          where d.IdReserva == idReserva
                                          select new DetalleReservaDto
                                          {
                                              Apellidos = d.Apellidos,
                                              Email = d.Email,
                                              IdGenero = d.IdGenero,
                                              IdTipoDocumento = d.IdTipoDocumento,
                                              NombreContacto = d.NombreContacto,
                                              nombreTipo = t.Nombre,
                                              NombreGenero = g.Nombre,
                                              Nombres = d.Nombres,
                                              numerodocumento = d.numerodocumento,
                                              Telefono = d.Telefono,
                                              TelefonoContacto = d.TelefonoContacto
                                              


                                          }).ToList();

            List<HabitacionesReservaDto> habitacionesReserva = (from o in this.unitOfWork.OcupacionRepository.AsQueryable()
                                                                join hb in this.unitOfWork.HabitacionesRepository.AsQueryable() on o.IdHabitacion equals hb.IdHabitaciones
                                                                where o.IdReserva == idReserva
                                                                select new HabitacionesReservaDto
                                                                {
                                                                    IdHabitacion = o.IdHabitacion,
                                                                    Numero = hb.Numero,
                                                                    Piso = hb.Piso,
                                                                    Ubicacion = hb.Ubicacion

                                                                }).ToList();
             
            DetalleReservaTotalDto detalleReservaTotal = new DetalleReservaTotalDto();
            detalleReservaTotal.detalleReservaDtos = detalleReserva;
            detalleReservaTotal.habitacionesReserva = habitacionesReserva;


            return detalleReservaTotal;

        }

        public ReservasDto insertReserva (ReservasDto reserva)
        {
            ReservasEntity reservaData = new ReservasEntity();
            
            
            reservaData.IdCiudad = reserva.IdCiudad;
            reservaData.CantidadHuespedes = reserva.CantidadHuespedes;
            reservaData.FecEntrada = reserva.FecEntrada;
            reservaData.FecSalida = reserva.FecSalida;
            reservaData.IdHotel = reserva.IdHotel;
            this.unitOfWork.ReservasRepository.Insert(reservaData);
            this.unitOfWork.Save();
            int idReservas = this.unitOfWork.ReservasRepository.AsQueryable().LastOrDefault().IdReservas;
            
            foreach (var idetalle in reserva.detalleReserva)
            {
                DetalleReservaEntity detallereservaData = new DetalleReservaEntity();
                detallereservaData.IdReserva = idReservas;
                detallereservaData.IdGenero = idetalle.IdGenero;
                detallereservaData.IdTipoDocumento =    idetalle.IdTipoDocumento;
                detallereservaData.Email = idetalle.Email;
                detallereservaData.Apellidos = idetalle.Apellidos;
                detallereservaData.NombreContacto = idetalle.NombreContacto;
                detallereservaData.Nombres = idetalle.Nombres;
                detallereservaData.numerodocumento = idetalle.numerodocumento;  
                detallereservaData.Telefono = idetalle.Telefono;
                detallereservaData.TelefonoContacto = idetalle.TelefonoContacto;
                
                this.unitOfWork.DetalleReservaRepository.Insert(detallereservaData);
                this.unitOfWork.Save();

            }

            foreach (var iHabitacion in reserva.habitacionesReserva)
            {
                OcupacionEntity ocupacionData = new OcupacionEntity();
                ocupacionData.IdHabitacion = iHabitacion.IdHabitacion;
                ocupacionData.Fecha = iHabitacion.fecha;
                ocupacionData.IdReserva = idReservas;
                this.unitOfWork.OcupacionRepository.Insert(ocupacionData);
                this.unitOfWork.Save();


            }
            reserva.IsSuccess = true;
            reserva.Message = "Proceso realizado con éxito";
            return reserva;
        }



        #endregion Methods

    }
}

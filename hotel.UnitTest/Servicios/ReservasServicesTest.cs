using Xunit;
using Moq;
using Dominio.Servicio.Servicios;
using Infraestructura.Core.UnitOfWork.Interface;
using Common.Utils.Utils.Interface;
using Infraestructura.Entity.Entities;
using Dominio.Servicio.DTO;
using System.Collections.Generic;
using System.Linq;

namespace hotel.UnitTest.Servicios
{
    public class ReservasServicesTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IUtils> _mockUtils;
        private readonly ReservasServices _reservasServices;

        public ReservasServicesTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUtils = new Mock<IUtils>();
            _reservasServices = new ReservasServices(_mockUnitOfWork.Object, _mockUtils.Object);
        }

        [Fact]
        public void BuscaHabitacion_ShouldReturnAvailableRooms_WhenRoomsAreAvailable()
        {
            // Arrange
            var busqueda = new BuscaHabitacionDto { IdHotel = 1, IdTipo = 2, IdCiudades = 3, FecEntrada = DateTime.Now, FecSalida = DateTime.Now.AddDays(2) };
            var habitaciones = new List<HabitacionesEntity>
            {
                new HabitacionesEntity { IdHabitaciones = 1, IdHotel = 1, IdTipo = 2, Activo = 1, Numero = "101", Piso = "1", Ubicacion = "Norte", PrecioNoche = 100, ValorImpuestos = 10 },
                new HabitacionesEntity { IdHabitaciones = 2, IdHotel = 1, IdTipo = 2, Activo = 1, Numero = "102", Piso = "1", Ubicacion = "Norte", PrecioNoche = 100, ValorImpuestos = 10 }
            };

            _mockUnitOfWork.Setup(uow => uow.HabitacionesRepository.AsQueryable()).Returns(habitaciones.AsQueryable());

            var ocupaciones = new List<OcupacionEntity>
            {
                new OcupacionEntity { IdHabitacion = 1, Fecha = DateTime.Now.AddDays(1) }
            };

            _mockUnitOfWork.Setup(uow => uow.OcupacionRepository.AsQueryable()).Returns(ocupaciones.AsQueryable());

            // Act
            var result = _reservasServices.BuscaHabitacion(busqueda);

            // Xunit.Assert
            Xunit.Assert.Single(result);  // Only one room should be available
            Xunit.Assert.Equal(2, result.First().IdHabitaciones);  // Room with Id 2 should be available
        }

        [Fact]
        public void GetAllReservas_ShouldReturnAllReservations()
        {
            // Arrange
            var reservas = new List<ReservasEntity>
            {
                new ReservasEntity { IdReservas = 1, CantidadHuespedes = 2, FecEntrada = DateTime.Now, FecSalida = DateTime.Now.AddDays(2), IdHotel = 1, IdCiudad = 1 },
                new ReservasEntity { IdReservas = 2, CantidadHuespedes = 4, FecEntrada = DateTime.Now, FecSalida = DateTime.Now.AddDays(3), IdHotel = 2, IdCiudad = 2 }
            };

            _mockUnitOfWork.Setup(uow => uow.ReservasRepository.AsQueryable()).Returns(reservas.AsQueryable());

            // Act
            var result = _reservasServices.GetAllReservas();

            // Xunit.Assert
            Xunit.Assert.Equal(2, result.Count);  // Should return 2 reservations
            Xunit.Assert.Equal(1, result.First().IdReservas);  // First reservation should have Id 1
        }

        [Fact]
        public void InsertReserva_ShouldInsertAndReturnReservation()
        {
            // Arrange
            var reservaDto = new ReservasDto
            {
                IdCiudad = 1,
                CantidadHuespedes = 2,
                FecEntrada = DateTime.Now,
                FecSalida = DateTime.Now.AddDays(2),
                IdHotel = 1,
                detalleReserva = new List<DetalleReservaDto>
                {
                    new DetalleReservaDto { IdGenero = 1, IdTipoDocumento = 1, Email = "test@test.com", Apellidos = "Doe", Nombres = "John" }
                },
                habitacionesReserva = new List<HabitacionesReservaDto>
                {
                    new HabitacionesReservaDto { IdHabitacion = 1, fecha = DateTime.Now.AddDays(1) }
                }
            };

            _mockUnitOfWork.Setup(uow => uow.ReservasRepository.AsQueryable()).Returns(new List<ReservasEntity>().AsQueryable());

            // Act
            var result = _reservasServices.insertReserva(reservaDto);

            // Xunit.Assert
            Xunit.Assert.True(result.IsSuccess);
            Xunit.Assert.Equal("Proceso realizado con éxito", result.Message);
            _mockUnitOfWork.Verify(uow => uow.ReservasRepository.Insert(It.IsAny<ReservasEntity>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.Save(), Times.AtLeast(3));  // Once for each insert operation (reservas, detalles, ocupaciones)
        }
    }
}


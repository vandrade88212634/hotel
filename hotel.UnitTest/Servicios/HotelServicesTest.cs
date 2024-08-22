using Common.Utils.Utils.Interface;
using Dominio.Servicio.DTO;
using Dominio.Servicio.Servicios;
using HtmlAgilityPack;
using Infraestructura.Core.UnitOfWork.Interface;
using Infraestructura.Entity.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace hotel.UnitTest.Servicios
{
    public class HotelServicesTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IUtils> _utilsMock;
        private readonly HotelServices _hotelServices;

        public HotelServicesTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _utilsMock = new Mock<IUtils>();
            _hotelServices = new HotelServices(_unitOfWorkMock.Object, _utilsMock.Object);
        }

        [Fact]
        public void GetAllHotelsbyCity_ReturnsHotelsList()
        {
            // Arrange
            var hotelList = new List<HotelEntity>
            {
                new HotelEntity { IdHotel = 1, IdCiudades = 1, RazonSocial = "Hotel A", Direccion = "Address A", TelReservas = "123456", Activo = 1 },
                new HotelEntity { IdHotel = 2, IdCiudades = 1, RazonSocial = "Hotel B", Direccion = "Address B", TelReservas = "654321", Activo = 1 }
            };

            var ciudadesList = new List<CiudadesEntity>
            {
                new CiudadesEntity { IdCiudades = 1, Nombre = "City A" }
            };

            _unitOfWorkMock.Setup(u => u.HotelRepository.AsQueryable()).Returns(hotelList.AsQueryable());
            _unitOfWorkMock.Setup(u => u.CiudadesRepository.AsQueryable()).Returns(ciudadesList.AsQueryable());

            // Act
            var result = _hotelServices.GetAllHotelsbyCity(1);

            // Xunit.Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(2, result.Count);
            Xunit.Assert.Equal("Hotel A", result[0].RazonSocial);
        }

        [Fact]
        public void GetAllHotelsbyId_ReturnsHotel()
        {
            // Arrange
            var hotelEntity = new HotelEntity { IdHotel = 1, IdCiudades = 1, RazonSocial = "Hotel A", Direccion = "Address A", TelReservas = "123456" };
            var ciudadEntity = new CiudadesEntity { IdCiudades = 1, Nombre = "City A" };

            _unitOfWorkMock.Setup(u => u.HotelRepository.AsQueryable()).Returns(new List<HotelEntity> { hotelEntity }.AsQueryable());
            _unitOfWorkMock.Setup(u => u.CiudadesRepository.AsQueryable()).Returns(new List<CiudadesEntity> { ciudadEntity }.AsQueryable());

            // Act
            var result = _hotelServices.GetAllHotelsbyId(1);

            // Xunit.Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal("Hotel A", result.RazonSocial);
        }

        [Fact]
        public void InsertHotel_ShouldInsertHotel()
        {
            // Arrange
            var hotelDto = new HotelDto { RazonSocial = "Hotel A", Direccion = "Address A", TelReservas = "123456", IdCiudades = 1 };

            _unitOfWorkMock.Setup(u => u.HotelRepository.Insert(It.IsAny<HotelEntity>()));
            _unitOfWorkMock.Setup(u => u.Save());

            // Act
            var result = _hotelServices.InsertHotel(hotelDto);

            // Xunit.Assert
            _unitOfWorkMock.Verify(u => u.HotelRepository.Insert(It.IsAny<HotelEntity>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.Save(), Times.Once);
            Xunit.Assert.True(result.IsSuccess);
            Xunit.Assert.Equal("Proceso Exitoso", result.Message);
        }

        [Fact]
        public void EditHotel_ShouldEditExistingHotel()
        {
            // Arrange
            var hotelEntity = new HotelEntity { IdHotel = 1, IdCiudades = 1, RazonSocial = "Hotel A", Direccion = "Address A", TelReservas = "123456" };
            var hotelDto = new HotelDto { IdHotel = 1, RazonSocial = "Hotel A Edited", Direccion = "Address A", TelReservas = "123456", IdCiudades = 1 };

            _unitOfWorkMock.Setup(u => u.HotelRepository.Find(It.IsAny<System.Linq.Expressions.Expression<Func<HotelEntity, bool>>>()))
                           .Returns(hotelEntity);
            _unitOfWorkMock.Setup(u => u.HotelRepository.Update(hotelEntity));
            _unitOfWorkMock.Setup(u => u.Save());

            // Act
            var result = _hotelServices.EditHotel(hotelDto);

            // Xunit.Assert
            _unitOfWorkMock.Verify(u => u.HotelRepository.Update(hotelEntity), Times.Once);
            _unitOfWorkMock.Verify(u => u.Save(), Times.Once);
            Xunit.Assert.True(result.IsSuccess);
            Xunit.Assert.Equal("Proceso Exitoso", result.Message);
        }

        [Fact]
        public void EditHotel_ShouldReturnHotelNotFound()
        {
            // Arrange
            var hotelDto = new HotelDto { IdHotel = 1, RazonSocial = "Hotel A Edited", Direccion = "Address A", TelReservas = "123456", IdCiudades = 1 };

            _unitOfWorkMock.Setup(u => u.HotelRepository.Find(It.IsAny<System.Linq.Expressions.Expression<Func<HotelEntity, bool>>>()))
                           .Returns((HotelEntity)null);

            // Act
            var result = _hotelServices.EditHotel(hotelDto);

            // Xunit.Assert
            Xunit.Assert.False(result.IsSuccess);
            Xunit.Assert.Equal("Hotel No encontrado", result.Message);
        }

        // Similar tests can be created for other methods like ActivaDesactivaHotel, GetAllHabitacionesbyHotel, etc.
    }
}


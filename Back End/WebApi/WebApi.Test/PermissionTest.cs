using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Infraestructure.Domain;
using WebApi.Models.Dto;
using WebApi.Models.Enum;
using WebApi.Models.Interfaces;
using WebApi.Repository;
using WebApi.Services;

namespace WebApi.Test
{
    [TestClass]
    public class PermissionTest
    {
        private readonly Mock<IPermissionRepository> _permissionRepository;
        private readonly Mock<IPermissionServices> _permissionServices;
        private readonly Mock<IUnitOfWork> _unitOfWorck;

        public PermissionTest()
        {
            _permissionRepository = new Mock<IPermissionRepository>();
            _permissionServices = new Mock<IPermissionServices>();
            _unitOfWorck = new Mock<IUnitOfWork>();
        }

        [TestMethod]
        public void GetAllPermissionsOk()
        {
            // Arrange
            Permiso permiso = new Permiso() {NombreEmpleado = "testOk",ApellidoEmpleado= "testOk", FechaPermiso = new DateTime(), TipoPermiso = 1 };

            List<Permiso> permisos= new List<Permiso>();
            permisos.Add(permiso);

            _unitOfWorck.SetupGet(uw => uw.PermissionRepository).Returns(_permissionRepository.Object);
            _permissionRepository.Setup(a => a.GetPermissionsRepository()).ReturnsAsync(permisos);
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = getPermissionsServices.GetPermissionsServices().Result;

            // Assert
            Assert.IsTrue(result.IsOk);
            Assert.IsTrue(result.Results.Count > 0);
            Assert.IsTrue(result.Results.FirstOrDefault().NombreEmpleado.Equals("testOk"));
            Assert.IsTrue(result.Results.FirstOrDefault().NombreEmpleado.Equals("testOk"));
            Assert.IsTrue(result.Message == "successful Get all permissions");
        }

        [TestMethod]
        public void GetAllPermissionsFaill()
        {
            // Arrange
            _unitOfWorck.SetupGet(uw => uw.PermissionRepository).Returns(_permissionRepository.Object);
            _permissionRepository.Setup(a => a.GetPermissionsRepository()).ReturnsAsync(new List<Permiso>());
            var getPermissionsServices = GetPermissionsServices();
            // Act
            var result = getPermissionsServices.GetPermissionsServices().Result;

            // Assert
            Assert.IsFalse(result.Results.Any());
            Assert.IsFalse(result.IsOk);
            Assert.IsTrue(result.Message == "an error occurred while Get all the permission");
            
        }

        [TestMethod]
        public void PostPermissionsOk()
        {
            // Arrange
            AddPermisionsDTO newPermission = new AddPermisionsDTO()
            {
                NombreEmpleado = "testOk",
                ApellidoEmpleado = "testOk",
                FechaPermiso = "2023-08-04",
                TipoPermiso = TypePermision.Get
            };

            _unitOfWorck.SetupGet(uw => uw.PermissionRepository).Returns(_permissionRepository.Object);
            _permissionRepository.Setup(a => a.RequestPermissionRepository((It.IsAny<Permiso>()))).Returns(Task.FromResult(true));
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = getPermissionsServices.RequestPermissionServices(newPermission).Result;

            // Assert
            Assert.IsTrue(result.IsOk);
            Assert.IsTrue(result.Message == "successful create permission");
        }
        

        [TestMethod]
        public void PostPermissionsFaill()
        {
            // Arrange
            AddPermisionsDTO newPermission = new AddPermisionsDTO()
            {
                NombreEmpleado = "testOk",
                ApellidoEmpleado = "testOk",
                FechaPermiso = "2023-08-04",
                TipoPermiso = TypePermision.Get
            };
            _unitOfWorck.SetupGet(uw => uw.PermissionRepository).Returns(_permissionRepository.Object);
            _permissionRepository.Setup(a => a.RequestPermissionRepository((It.IsAny<Permiso>()))).Returns(Task.FromResult(It.IsAny<bool>()));
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = getPermissionsServices.RequestPermissionServices(newPermission).Result;

            // Assert
            Assert.IsFalse(result.IsOk);
            Assert.IsTrue(result.Message == "an error occurred while create the permission");
        }

        [TestMethod]
        public void PutPermissionsOk()
        {
            // Arrange
            int id = 1;
            PermisionsDTO newPermissionDTO = new PermisionsDTO()
            {
                NombreEmpleado = "testOk",
                ApellidoEmpleado = "testOk",
                FechaPermiso = "2023-08-04",
                TipoPermiso = 1
            };

            Permiso newPermission = new Permiso()
            {
                NombreEmpleado = "testOk",
                ApellidoEmpleado = "testOk",
                FechaPermiso = DateTime.Parse("2023-08-04"),
                TipoPermiso = 1
            };

            _unitOfWorck.SetupGet(uw => uw.PermissionRepository).Returns(_permissionRepository.Object);
            _permissionRepository.Setup(a => a.ModifyPermissionRepository(It.IsAny<int>(), It.IsAny<Permiso>())).Returns(Task.FromResult(true));
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = getPermissionsServices.ModifyPermissionServices(id, newPermissionDTO).Result;

            // Assert
            Assert.IsTrue(result.IsOk);
            Assert.IsTrue(result.Message == "successful edit permission");
        }

        [TestMethod]
        public void PutPermissionsFaill()
        {
            // Arrange
            int id = 1;
            PermisionsDTO newPermissionDTO = new PermisionsDTO()
            {
                NombreEmpleado = "testOk",
                ApellidoEmpleado = "testOk",
                FechaPermiso = "2023-08-04",
                TipoPermiso = 1
            };

            Permiso newPermission = new Permiso()
            {
                NombreEmpleado = "testOk",
                ApellidoEmpleado = "testOk",
                FechaPermiso = DateTime.Parse("2023-08-04"),
                TipoPermiso = 1
            };

            _unitOfWorck.SetupGet(uw => uw.PermissionRepository).Returns(_permissionRepository.Object);
            _permissionRepository.Setup(a => a.ModifyPermissionRepository(It.IsAny<int>(), It.IsAny<Permiso>())).Returns(Task.FromResult(It.IsAny<bool>()));
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = getPermissionsServices.ModifyPermissionServices(id, newPermissionDTO);

            // Assert
            Assert.IsFalse(result.Result.IsOk);
            Assert.IsTrue(result.Result.Message == "an error occurred while edit the permission");
        }

        #region private Methods
        private IPermissionServices GetPermissionsServices()
        {
            return new PermissionServices(_unitOfWorck.Object);
        }

        #endregion
    }
}
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

        public PermissionTest()
        {
            _permissionRepository = new Mock<IPermissionRepository>();
            _permissionServices = new Mock<IPermissionServices>();
        }

        [TestMethod]
        public void GetAllPermissionsOk()
        {
            // Arrange
            Permiso permiso = new Permiso() {NombreEmpleado = "testOk",ApellidoEmpleado= "testOk", FechaPermiso = new DateTime(), TipoPermiso = 1 };

            List<Permiso> permisos= new List<Permiso>();
            permisos.Add(permiso);

            _permissionRepository.Setup(a => a.GetPermissionsServices()).Returns(permisos);
            var getPermissionsServices = GetPermissionsServices();
            // Act
            var result = getPermissionsServices.GetPermissionsServices();
            // Assert
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.FirstOrDefault().NombreEmpleado.Equals("testOk"));
            Assert.IsTrue(result.FirstOrDefault().NombreEmpleado.Equals("testOk"));
        }

        [TestMethod]
        public void GetAllPermissionsFaill()
        {
            // Arrange
            _permissionRepository.Setup(a => a.GetPermissionsServices()).Returns(new List<Permiso>());
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = getPermissionsServices.GetPermissionsServices();
            // Assert
            Assert.IsFalse(result.Any());
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

            _permissionRepository.Setup(a => a.RequestPermissionServices((It.IsAny<Permiso>()))).Returns(true);
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = getPermissionsServices.RequestPermissionServices(newPermission);
            // Assert
            Assert.IsTrue(result);
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

            _permissionRepository.Setup(a => a.RequestPermissionServices((It.IsAny<Permiso>()))).Returns(false);
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = getPermissionsServices.RequestPermissionServices(newPermission);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PutPermissionsOk()
        {
            // Arrange
            int id = 1;
            PermisionsDTO newPermission = new PermisionsDTO()
            {
                NombreEmpleado = "testOk",
                ApellidoEmpleado = "testOk",
                FechaPermiso = "2023-08-04",
                TipoPermiso = 1
            };

            _permissionRepository.Setup(a => a.ModifyPermissionServices(It.IsAny<int>(), It.IsAny<Permiso>())).Returns(Task.FromResult(true));
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = getPermissionsServices.ModifyPermissionServices(id,newPermission);
            // Assert
            Assert.IsTrue(result.Result);
        }

        [TestMethod]
        public void PutPermissionsFaill()
        {
            // Arrange
            int id = 1;
            PermisionsDTO newPermission = new PermisionsDTO()
            {
                NombreEmpleado = "testOk",
                ApellidoEmpleado = "testOk",
                FechaPermiso = "2023-08-04",
                TipoPermiso = 1
            };

            _permissionRepository.Setup(a => a.ModifyPermissionServices(It.IsAny<int>(), It.IsAny<Permiso>())).Returns(Task.FromResult(false));
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = getPermissionsServices.ModifyPermissionServices(id, newPermission);
            // Assert
            Assert.IsFalse(result.Result);
        }

        #region private Methods
        private IPermissionServices GetPermissionsServices()
        {
            return new PermissionServices(_permissionRepository.Object);
        }

        #endregion
    }
}
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
        }

        [TestMethod]
        public async void GetAllPermissionsOk()
        {
            // Arrange
            Permiso permiso = new Permiso() {NombreEmpleado = "testOk",ApellidoEmpleado= "testOk", FechaPermiso = new DateTime(), TipoPermiso = 1 };

            List<Permiso> permisos= new List<Permiso>();
            permisos.Add(permiso);

            _permissionRepository.Setup(a => a.GetPermissionsRepository()).ReturnsAsync(permisos);
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = await getPermissionsServices.GetPermissionsServices();

            // Assert
            Assert.IsTrue(result.IsOk);
            Assert.IsTrue(result.Results.Count > 0);
            Assert.IsTrue(result.Results.FirstOrDefault().NombreEmpleado.Equals("testOk"));
            Assert.IsTrue(result.Results.FirstOrDefault().NombreEmpleado.Equals("testOk"));
        }

        [TestMethod]
        public async void GetAllPermissionsFaill()
        {
            // Arrange
            _permissionRepository.Setup(a => a.GetPermissionsRepository()).ReturnsAsync(new List<Permiso>());
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = await getPermissionsServices.GetPermissionsServices();

            // Assert
            Assert.IsFalse(result.Results.Any());
            Assert.IsFalse(result.IsOk);
        }

        [TestMethod]
        public async void PostPermissionsOk()
        {
            // Arrange
            AddPermisionsDTO newPermission = new AddPermisionsDTO()
            {
                NombreEmpleado = "testOk",
                ApellidoEmpleado = "testOk",
                FechaPermiso = "2023-08-04",
                TipoPermiso = TypePermision.Get
            };

            _permissionRepository.Setup(a => a.RequestPermissionRepository((It.IsAny<Permiso>()))).Returns(Task.FromResult(It.IsAny<Permiso>()));
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = await getPermissionsServices.RequestPermissionServices(newPermission);

            // Assert
            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public async void PostPermissionsFaill()
        {
            // Arrange
            AddPermisionsDTO newPermission = new AddPermisionsDTO()
            {
                NombreEmpleado = "testOk",
                ApellidoEmpleado = "testOk",
                FechaPermiso = "2023-08-04",
                TipoPermiso = TypePermision.Get
            };

            _permissionRepository.Setup(a => a.RequestPermissionRepository((It.IsAny<Permiso>()))).Returns(Task.FromResult(It.IsAny<Permiso>()));
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = await getPermissionsServices.RequestPermissionServices(newPermission);

            // Assert
            Assert.IsFalse(result.IsOk);
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

            _permissionRepository.Setup(a => a.ModifyPermissionRepository(It.IsAny<int>(), It.IsAny<Permiso>())).Returns(Task.FromResult(It.IsAny<Permiso>()));
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = getPermissionsServices.ModifyPermissionServices(id,newPermission);

            // Assert
            Assert.IsTrue(result.Result.IsOk);
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

            _permissionRepository.Setup(a => a.ModifyPermissionRepository(It.IsAny<int>(), It.IsAny<Permiso>())).Returns(Task.FromResult(It.IsAny<Permiso>()));
            var getPermissionsServices = GetPermissionsServices();

            // Act
            var result = getPermissionsServices.ModifyPermissionServices(id, newPermission);

            // Assert
            Assert.IsFalse(result.Result.IsOk);
        }

        #region private Methods
        private IPermissionServices GetPermissionsServices()
        {
            return new PermissionServices(_unitOfWorck.Object);
        }

        #endregion
    }
}
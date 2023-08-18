using Moq;
using WebApi.Models.Interfaces;

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
        }

        [TestMethod]
        public void GetAllPermissionsFaill()
        {
        }

        [TestMethod]
        public void PostPermissionsOk()
        {
        }

        [TestMethod]
        public void PostPermissionsFaill()
        {
        }

        [TestMethod]
        public void PutPermissionsOk()
        {
        }

        [TestMethod]
        public void PutPermissionsFaill()
        {
        }
    }
}
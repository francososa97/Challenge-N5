using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Infraestructure;
using WebApi.Models.Interfaces;

namespace WebApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IPermissionRepository _permissionRepository;
        public IPermissionRepository PermissionRepository => _permissionRepository ?? (_permissionRepository = new PermissionRepository());
    }
}

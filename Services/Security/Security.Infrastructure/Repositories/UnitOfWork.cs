
using AutoMapper;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Security.Application.Contracts.Persistence;
using Security.Core.Repositories.Command;
using Security.Infrastructure.Data;
using Security.Core.Repositories.Query;
using Security.Infrastructure.Repository.Query;
using Security.Infrastructure.Repository.Command;
using Microsoft.Extensions.Configuration;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SecurityContext _context;
        private readonly IConfiguration _configuration;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        private IPermissionsQueryRepository _permissionQueryRepository;
        private IPermissionsCommandRepository _permissionCommandRepository;


        public UnitOfWork(SecurityContext context, IConfiguration configuration/*, IHttpContextAccessor httpContextAccessor*/)
        {
            _context = context;
            _configuration = configuration;
            //this._httpContextAccessor = httpContextAccessor;
        }

        public IPermissionsQueryRepository PermissionsQueryRepository => 
            _permissionQueryRepository ??= new PermissionsQueryRepository(_configuration, _context);

        public IPermissionsCommandRepository PermissionsCommandRepository => 
            _permissionCommandRepository ??= new PermissionsCommandRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save() 
        {
            //var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;
            await _context.SaveChangesAsync();
        }
    }
}

using AutoMapper;
using Moq;
using Security.Application.Commands;
using Security.Application.Contracts.Persistence;
using Security.Application.Handlers.CommandHandler;
using Security.Application.Mapper;
using Security.Application.Response;
using Security.Core.Entities;
using Security.Test.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Security.Test.Handlers
{
    public class ModifyPermissionHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Permissions _leaveTypeDto;
        private readonly ModifyPermissionHandler _handler;

        public ModifyPermissionHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<SecurityMappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new ModifyPermissionHandler(_mockUow.Object);

            _leaveTypeDto = new Permissions
            {
                Id = 1,
                NombreEmpleado = "Samael",
                ApellidoEmpleado = "Fierro",
            };
        }

        [Fact]
        public async Task Valid_LeaveType_Added()
        {
            var result = await _handler.Handle(new ModifyPermissionCommand() { 
                
            }, CancellationToken.None);

            var leaveTypes = await _mockUow.Object.PermissionsQueryRepository.GetPermissionsAsync();

            result.ShouldBeOfType<PermissionResponse>();

            leaveTypes.Count.ShouldBe(3);
        }
    }
}

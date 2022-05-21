using Moq;
using Security.Core.Entities;
using Security.Core.Repositories.Command;
using Security.Core.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Test.Mocks
{
    public static class MockPermissionsRepository
    {
        public static Mock<IPermissionsQueryRepository> PermissionsQueryRepository()
        {
            var leaveTypes = new List<Permissions>
            {
                new Permissions
                {
                    Id = 1,
                    NombreEmpleado = "Samael",
                    ApellidoEmpleado = "Fierro",
                },
                new Permissions
                {
                    Id = 2,
                    NombreEmpleado = "Kelly",
                    ApellidoEmpleado = "Barrera",
                },
                new Permissions
                {
                    Id = 3,
                    NombreEmpleado = "Jonás",
                    ApellidoEmpleado = "Mendez",
                }
            };

            var mockRepo = new Mock<IPermissionsQueryRepository>();

            mockRepo.Setup(r => r.GetPermissionsAsync()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(r => r.GetPermissionAsync(It.IsAny<long>())).ReturnsAsync(leaveTypes.First());
            return mockRepo;
        }
        public static Mock<IPermissionsCommandRepository> PermissionsCommandRepository()
        {
            var leaveType = new Permissions
            {
                Id = 1,
                NombreEmpleado = "Samael",
                ApellidoEmpleado = "Fierro",
            };

            var mockRepo = new Mock<IPermissionsCommandRepository>();

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Permissions>()));
            /*.ReturnsAsync((IPermissionsCommandRepository leaveType) => 
            {
                return leaveType;
            });*/
            return mockRepo;
        }
    }
}

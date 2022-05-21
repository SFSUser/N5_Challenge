﻿using AutoMapper;
using Moq;
using Security.Application.Contracts.Persistence;
using Security.Application.Handlers.CommandHandler;
using Security.Application.Handlers.QueryHandlers;
using Security.Application.Mapper;
using Security.Application.CQRS.Queries;
using Security.Core.Entities;
using Security.Core.Repositories.Query;
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
    public class GetPermissionHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        public GetPermissionHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<SecurityMappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetPermission()
        {
            var handler = new GetPermissionHandler(_mockUow.Object);

            var result = await handler.Handle(new GetPermissionQuery(1), CancellationToken.None);

            result.ShouldBeOfType<Permissions>();

            result.Id.ShouldBe(1);
        }
    }
}

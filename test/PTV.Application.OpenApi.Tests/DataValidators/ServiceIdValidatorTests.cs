﻿/**
 * The MIT License
 * Copyright (c) 2016 Population Register Centre (VRK)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using FluentAssertions;
using Moq;
using PTV.Application.OpenApi.DataValidators;
using Xunit;
using System;
using PTV.Database.DataAccess.Interfaces.Services;
using PTV.Domain.Model.Models.OpenApi;
using System.Collections.Generic;

namespace PTV.Application.OpenApi.Tests.DataValidators
{
    public class ServiceIdValidatorTests : ValidatorTestBase
    {
        public ServiceIdValidatorTests() { }

        [Fact]
        public void ModelIsEmpty()
        {
            // Arrange
            var validator = new ServiceIdValidator(Guid.Empty, serviceService);

            // Act
            validator.Validate(controller.ModelState);

            // Assert
            controller.ModelState.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ModelSetAndChannelDoesNotExist()
        {
            // Arrange
            serviceServiceMockSetup.Setup(c => c.GetServiceByIdSimple(It.IsAny<Guid>(), true))
                .Returns((VmOpenApiServiceVersionBase)null);
            var validator = new ServiceIdValidator(Guid.NewGuid(), serviceService);

            // Act
            validator.Validate(controller.ModelState);

            // Assert
            controller.ModelState.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ModelSetAndChannelExists()
        {
            // Arrange
            serviceServiceMockSetup.Setup(c => c.GetServiceByIdSimple(It.IsAny<Guid>(), true))
                .Returns(new VmOpenApiServiceVersionBase() { Id = Guid.NewGuid() });
            var validator = new ServiceIdValidator(Guid.NewGuid(), serviceService);

            // Act
            validator.Validate(controller.ModelState);

            // Assert
            controller.ModelState.IsValid.Should().BeTrue();
        }

    }
}

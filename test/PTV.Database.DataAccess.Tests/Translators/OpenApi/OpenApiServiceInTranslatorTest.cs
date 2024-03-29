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
using PTV.Database.DataAccess.Interfaces.Translators;
using PTV.Database.DataAccess.Translators.OpenApi.Services;
using PTV.Database.Model.Models;
using PTV.Domain.Model.Models.OpenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using PTV.Database.DataAccess.Interfaces.DbContext;
using PTV.Domain.Model.Models.Interfaces.OpenApi;

namespace PTV.Database.DataAccess.Tests.Translators.OpenApi
{
    public class OpenApiServiceInTranslatorTest : TranslatorTestBase
    {
        private List<object> translators;
        private IUnitOfWork unitOfWorkMock;

        public OpenApiServiceInTranslatorTest()
        {
            unitOfWorkMock = unitOfWorkMockSetup.Object;

            SetupTypesCacheMock<PhoneNumberType>();
            SetupTypesCacheMock<ServiceChargeType>();

            translators = new List<object>
            {
                new OpenApiServiceInTranslator(ResolveManager, TranslationPrimitives, CacheManager),
                RegisterTranslatorMock(new Mock<ITranslator<ServiceVersioned, IVmOpenApiServiceInVersionBase>>(), unitOfWorkMock)
            };
        }

        [Fact]
        public void TranslateServiceVmToEntity()
        {
            var vm = new VmOpenApiServiceInVersionBase();
            var toTranslate = new List<IVmOpenApiServiceInVersionBase>() { vm };
            var translations = RunTranslationModelToEntityTest<IVmOpenApiServiceInVersionBase, ServiceVersioned>(translators, toTranslate);
            var translation = translations.First();

            Assert.Equal(1, translations.Count);
        }
    }
}
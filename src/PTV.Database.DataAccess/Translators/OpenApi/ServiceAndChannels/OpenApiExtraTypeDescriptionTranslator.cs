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

using PTV.Database.DataAccess.Caches;
using PTV.Database.DataAccess.Interfaces.Translators;
using PTV.Database.DataAccess.Translators.OpenApi.Common;
using PTV.Database.Model.Models;
using PTV.Domain.Model.Models.OpenApi;
using PTV.Framework;
using PTV.Framework.Interfaces;
using System;

namespace PTV.Database.DataAccess.Translators.OpenApi.ServiceAndChannels
{
    [RegisterService(typeof(ITranslator<ServiceServiceChannelExtraTypeDescription, VmOpenApiLanguageItem>), RegisterType.Transient)]
    internal class OpenApiExtraTypeDescriptionTranslator : OpenApiDescriptionBaseTranslator<ServiceServiceChannelExtraTypeDescription>
    {
        private readonly ILanguageCache languageCache;

        public OpenApiExtraTypeDescriptionTranslator(IResolveManager resolveManager, ITranslationPrimitives translationPrimitives, ICacheManager cacheManager)
            : base(resolveManager, translationPrimitives, cacheManager)
        {
            languageCache = cacheManager.LanguageCache;
        }

        public override VmOpenApiLanguageItem TranslateEntityToVm(ServiceServiceChannelExtraTypeDescription entity)
        {
            return base.TranslateEntityToVm(entity);
        }

        public override ServiceServiceChannelExtraTypeDescription TranslateVmToEntity(VmOpenApiLanguageItem vModel)
        {
            var languageId = languageCache.Get(vModel.Language);
            return CreateViewModelEntityDefinition<ServiceServiceChannelExtraTypeDescription>(vModel)
                .UseDataContextUpdate(i => true, i => o => (i.OwnerReferenceId == o.ServiceServiceChannelExtraTypeId) && languageId == o.LocalizationId,
                    def => def.UseDataContextCreate(i => true))
                .AddNavigation(i => i.Value, o => o.Description)
                .AddSimple(i => languageId, o => o.LocalizationId)
                .GetFinal();
        }
    }
}

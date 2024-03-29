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
using PTV.Database.Model.Models;
using PTV.Domain.Model.Models.Interfaces.OpenApi;
using PTV.Domain.Model.Models.OpenApi;
using PTV.Framework;
using PTV.Framework.Interfaces;
using System;

namespace PTV.Database.DataAccess.Translators.OpenApi.Channels
{
    [RegisterService(typeof(ITranslator<ElectronicChannel, VmOpenApiElectronicChannelInVersionBase>), RegisterType.Transient)]
    internal class OpenApiEChannelInTranslator : Translator<ElectronicChannel, VmOpenApiElectronicChannelInVersionBase>
    {
        public OpenApiEChannelInTranslator(IResolveManager resolveManager, ITranslationPrimitives translationPrimitives) : base(resolveManager, translationPrimitives)
        {
        }
        public override VmOpenApiElectronicChannelInVersionBase TranslateEntityToVm(ElectronicChannel entity)
        {
            throw new NotImplementedException("ElectronicChannel -> IVmOpenApiElectronicChannelInBase translator is not implemented");
        }
        public override ElectronicChannel TranslateVmToEntity(VmOpenApiElectronicChannelInVersionBase vModel)
        {
            var definitions = CreateViewModelEntityDefinition<ElectronicChannel>(vModel)
                .DisableAutoTranslation()
                .UseDataContextCreate(i => !i.Id.IsAssigned())
                .UseDataContextUpdate(i => i.Id.IsAssigned(), i => o => i.Id == o.ServiceChannelVersionedId, def => def.UseDataContextCreate(i => true))
                .AddSimple(i => i.RequiresSignature, o => o.RequiresSignature)
                .AddSimple(i => i.RequiresAuthentication, o => o.RequiresAuthentication);

            if (vModel.ChannelId.IsAssigned())
            {
                vModel.Urls.ForEach(u => u.OwnerReferenceId = vModel.ChannelId);
            }

            if (vModel.Urls != null && vModel.Urls.Count > 0)
            {
                definitions.AddCollection(i => i.Urls, o => o.LocalizedUrls, false);
            }

            if (!string.IsNullOrEmpty(vModel.SignatureQuantity))
            {
                var signatureQuantity = int.Parse(vModel.SignatureQuantity);
                definitions = definitions.AddSimple(i => signatureQuantity, o => o.SignatureQuantity);
            }

            return definitions.GetFinal();
        }
    }
}

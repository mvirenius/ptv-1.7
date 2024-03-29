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
using PTV.Framework;

namespace PTV.ExternalSources.Resources.Types
{
    [RegisterService(typeof(TypeItemImportDefinition), RegisterType.Transient)]
    public class TypeItemImportDefinition : IImportDefinition
    {
        public enum Resources
        {
            AddressType,
            AddressCharacter,
            AppEnvironmentDataType,
            AreaInformationType,
            AreaType,
            AttachmentType,
            DescriptionType,
            ExceptionHoursStatus,
            NameType,
            OrganizationType,
            PhoneNumberType,
            PrintableFormChannelUrlType,
            ProvisionType,
            PublishingStatus,
            RoleType,            
            ServiceHours,
            ServiceChannelType,
            ServiceChargeType,
            StreetAddressType,
            WebPageType,
            PhoneDescriptionType,
            ServiceType,
            CoordinateType,
            ServiceChannelConnectionType,
            AccessRightType,
            ServiceFundingType,
            ExtraType,
            ExtraSubType
        }

        public ImportFileType FileType
        {
            get { return ImportFileType.Json; }
        }

        public Resources Resource { get; set; }

        public string ResourceName { get { return Resource.ToString(); } }

        public string ResourcePath { get { return "Types"; } }
    }
}

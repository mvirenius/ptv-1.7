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

using Newtonsoft.Json;
using PTV.Domain.Model.Models.Interfaces.OpenApi;
using PTV.Domain.Model.Models.Interfaces.OpenApi.V4;
using PTV.Framework.Attributes;
using System.Collections.Generic;

namespace PTV.Domain.Model.Models.OpenApi.V4
{
    /// <summary>
    /// OPEN API V4 - View Model of printable form channel for IN api - base
    /// </summary>
    /// <seealso cref="PTV.Domain.Model.Models.OpenApi.VmOpenApiPrintableFormChannelInVersionBase" />
    /// <seealso cref="PTV.Domain.Model.Models.Interfaces.OpenApi.V4.IV4VmOpenApiPrintableFormChannelInBase" />
    public class V4VmOpenApiPrintableFormChannelInBase : VmOpenApiPrintableFormChannelInVersionBase, IV4VmOpenApiPrintableFormChannelInBase
    {
        /// <summary>
        /// Area type (WholeCountry, WholeCountryExceptAlandIslands, AreaType). 
        /// </summary>
        [JsonIgnore]
        public override string AreaType { get => base.AreaType; set => base.AreaType = value; }

        /// <summary>
        /// List of areas. List can contain different types of areas.
        /// </summary>
        [JsonIgnore]
        public override IList<VmOpenApiAreaIn> Areas { get => base.Areas; set => base.Areas = value; }

        /// <summary>
        /// Form delivery address.
        /// </summary>
        [JsonProperty(Order = 12)]
        public new virtual V4VmOpenApiAddressIn DeliveryAddress { get; set; }

        /// <summary>
        /// Indicates if channel can be used (referenced within services) by other users from other organizations.
        /// </summary>
        [JsonIgnore]
        public override bool IsVisibleForAll { get => base.IsVisibleForAll; set => base.IsVisibleForAll = value; }

        /// <summary>
        /// Service channel publishing status. Values: Draft, Published, Deleted or Modified.
        /// </summary>
        [AllowedValues("PublishingStatus", new[] { "Draft", "Published", "Deleted", "Modified" })]
        [ValidEnum(null)] // PTV-1792: suppress base ValidEnum validation
        public override string PublishingStatus
        {
            get => base.PublishingStatus;
            set => base.PublishingStatus = value;
        }

        #region methods
        /// <summary>
        /// Gets the version number.
        /// </summary>
        /// <returns>version number</returns>
        public override int VersionNumber()
        {
            return 4;
        }

        /// <summary>
        /// Gets the base version.
        /// </summary>
        /// <returns>base version</returns>
        public override IVmOpenApiServiceChannelIn VersionBase()
        {
            var vm = base.GetVersionBaseModel<VmOpenApiPrintableFormChannelInVersionBase>();
            vm.DeliveryAddress = DeliveryAddress != null ? DeliveryAddress.LatestVersionDeliveryAddress() : null;
            return vm;
        }
        #endregion
    }
}

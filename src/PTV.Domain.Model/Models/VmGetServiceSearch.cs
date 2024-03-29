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
using System;
using System.Collections.Generic;
using PTV.Domain.Model.Models.Interfaces;

namespace PTV.Domain.Model.Models
{
    /// <summary>
    /// View model for view search services
    /// </summary>
    /// <seealso cref="PTV.Domain.Model.Models.VmEnumBase" />
    /// <seealso cref="PTV.Domain.Model.Models.Interfaces.IVmGetServiceSearch" />
    public class VmGetServiceSearch : VmEnumBase, IVmGetServiceSearch
    {
        /// <summary>
        /// Gets or sets the organization identifier.
        /// </summary>
        /// <value>
        /// The organization identifier.
        /// </value>
        public Guid? OrganizationId { get; set; }
        /// <summary>
        /// Gets or sets the selected publishing statuses.
        /// </summary>
        /// <value>
        /// The selected publishing statuses.
        /// </value>
        public List<Guid> SelectedPublishingStatuses { get; set; }
    }


    /// <summary>
    /// View model for view search services
    /// </summary>
    /// <seealso cref="PTV.Domain.Model.Models.VmEnumBase" />
    /// <seealso cref="PTV.Domain.Model.Models.Interfaces.IVmGetFrontPageSearch" />
    public class VmGetFrontPageSearch : VmEnumBase, IVmGetFrontPageSearch
    {
        /// <summary>
        /// Gets or sets the organization identifier.
        /// </summary>
        /// <value>
        /// The organization identifier.
        /// </value>
        public Guid? OrganizationId { get; set; }
        /// <summary>
        /// Gets or sets the selected publishing statuses.
        /// </summary>
        /// <value>
        /// The selected publishing statuses.
        /// </value>
        public List<Guid> SelectedPublishingStatuses { get; set; }
    }
}

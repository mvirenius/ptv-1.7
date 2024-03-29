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
using PTV.Domain.Model.Models.Interfaces;
using System.Collections.Generic;
using Newtonsoft.Json;
using PTV.Domain.Model.Enums;

namespace PTV.Domain.Model.Models
{
    /// <summary>
    /// View model of opening hours
    /// </summary>
    /// <seealso cref="PTV.Domain.Model.Models.VmEnumEntityBase" />
    /// <seealso cref="PTV.Domain.Model.Models.Interfaces.IVmOpeningHours" />
    public class VmOpeningHoursStep : VmEnumEntityBase, IVmOpeningHours
    {
        /// <summary>
        /// Gets or sets the exception hours.
        /// </summary>
        /// <value>
        /// The exception hours.
        /// </value>
        [JsonProperty(PropertyName = "openingHoursExceptional")]
        public List<VmExceptionalHours> ExceptionHours { get; set; }
        /// <summary>
        /// Gets or sets the standard hours.
        /// </summary>
        /// <value>
        /// The standard hours.
        /// </value>
        [JsonProperty(PropertyName = "openingHoursNormal")]
        public List<VmNormalHours> StandardHours { get; set; }
        /// <summary>
        /// Gets or sets the special hours.
        /// </summary>
        /// <value>
        /// The special hours.
        /// </value>
        [JsonProperty(PropertyName = "openingHoursSpecial")]
        public List<VmSpecialHours> SpecialHours { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VmOpeningHoursStep"/> class.
        /// </summary>
        public VmOpeningHoursStep()
        {
            ExceptionHours = new List<VmExceptionalHours>();
            StandardHours = new List<VmNormalHours>();
            SpecialHours = new List<VmSpecialHours>();
        }

        /// <summary>
        /// Gets or sets the language code.
        /// </summary>
        /// <value>
        /// The language code.
        /// </value>
        public LanguageCode Language { get; set; }
    }
}

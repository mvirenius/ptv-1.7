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
using Newtonsoft.Json;
using PTV.Domain.Model.Models.Interfaces;

namespace PTV.Domain.Model.Models.Import
{
    /// <summary>
    /// Law from finto
    /// </summary>
    /// <seealso cref="PTV.Domain.Model.Models.VmEntityBase" />
    /// <seealso cref="PTV.Domain.Model.Models.Interfaces.IVmOwnerReference" />
    public class ImportLaw : VmEntityBase, IVmOwnerReference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportLaw"/> class.
        /// </summary>
        public ImportLaw()
        {
            Links = new List<JsonLanguageLabel>();
            Names = new List<JsonLanguageLabel>();
        }

        /// <summary>
        /// Gets or sets the law reference.
        /// </summary>
        /// <value>
        /// The law reference.
        /// </value>
        public string LawReference { get; set; }
        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        /// <value>
        /// The links.
        /// </value>
        public List<JsonLanguageLabel> Links { get; set; }
        /// <summary>
        /// Gets or sets the names.
        /// </summary>
        /// <value>
        /// The names.
        /// </value>
        public List<JsonLanguageLabel> Names { get; set; }

        /// <summary>
        /// Id of owner entity
        /// </summary>
        [JsonIgnore]
        public Guid? OwnerReferenceId { get; set; }
    }
}
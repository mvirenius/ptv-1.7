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
using PTV.Domain.Model.Enums;
using PTV.Domain.Model.Models.Interfaces;

namespace PTV.Domain.Model.Models
{
    /// <summary>
    /// View model of web channel
    /// </summary>
    /// <seealso cref="PTV.Domain.Model.Models.VmEntityStatusBase" />
    /// <seealso cref="PTV.Domain.Model.Models.Interfaces.IVmWebPageChannel" />
    public class VmWebPageChannel : VmEntityStatusBase, IVmWebPageChannel
    {
        /// <summary>
        /// Gets or sets the step1 form.
        /// </summary>
        /// <value>
        /// The step1 form.
        /// </value>
        public VmWebPageChannelStep1 Step1Form { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VmWebPageChannel"/> class.
        /// </summary>
        public VmWebPageChannel()
        {
            Step1Form = new VmWebPageChannelStep1();
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

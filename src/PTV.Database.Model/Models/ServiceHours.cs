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
using PTV.Database.Model.Interfaces;
using PTV.Database.Model.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTV.Database.Model.Models
{
    internal class ServiceHours : EntityIdentifierBase
    {
        public ServiceHours()
        {
            AdditionalInformations = new HashSet<ServiceHoursAdditionalInformation>();
            DailyOpeningTimes = new HashSet<DailyOpeningTime>();
            ServiceChannelServiceHours = new HashSet<ServiceChannelServiceHours>();
            ServiceServiceChannelServiceHours = new HashSet<ServiceServiceChannelServiceHours>();
        }

        public Guid ServiceHourTypeId { get; set; }
        public ServiceHourType ServiceHourType { get; set; }

        public bool IsClosed { get; set; }

        public DateTime? OpeningHoursFrom { get; set; }
        public DateTime? OpeningHoursTo { get; set; }

        public virtual ICollection<ServiceHoursAdditionalInformation> AdditionalInformations { get; set; }
        public virtual ICollection<DailyOpeningTime> DailyOpeningTimes { get; set; }

        public int? OrderNumber { get; set; }

        public virtual ICollection<ServiceChannelServiceHours> ServiceChannelServiceHours { get; set; }

        public virtual ICollection<ServiceServiceChannelServiceHours> ServiceServiceChannelServiceHours { get; set; }
    }
}

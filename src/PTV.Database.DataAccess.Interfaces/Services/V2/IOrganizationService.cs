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
using PTV.Database.DataAccess.Interfaces.DbContext;
using PTV.Database.Model.ServiceDataHolders;
using PTV.Domain.Model.Models.Interfaces;
using PTV.Domain.Model.Models.Interfaces.V2;
using PTV.Domain.Model.Models.V2.Common;
using PTV.Domain.Model.Models.V2.Service;
using PTV.Domain.Model.Models.V2.Organization;
using PTV.Domain.Model.Models;

namespace PTV.Database.DataAccess.Interfaces.Services.V2
{
    public interface IOrganizationService
    {
        /// <summary>
        /// Get model for organization 
        /// </summary>
        /// <param name="model">input model</param>
        /// <returns></returns>
        VmOrganizationOutput GetOrganization(VmOrganizationBasic model);
        /// <summary>
        /// Saves organization 
        /// </summary>
        /// <param name="model">input model</param>
        /// <returns>service</returns>
        VmOrganizationOutput SaveOrganization(VmOrganizationInput model);
        /// <summary>
        /// Publish organization.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        VmEntityHeaderBase PublishOrganization(IVmPublishingModel model);
        /// <summary>
        /// Gets the organization header.
        /// </summary>
        /// <param name="organizationId">The organization identifier.</param>
        /// <returns></returns>
        VmOrganizationHeader GetOrganizationHeader(Guid? organizationId);
        /// <summary>
        /// Delete Organization
        /// </summary>
        /// <param name="organizationId">id of Organization to delete</param>       
        /// <returns>base entity containing entityId and publishing status</returns>
        VmOrganizationHeader DeleteOrganization(Guid? organizationId);
        /// <summary>
        /// return counts of related entities of organization to delete</param>
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        VmArchiveResult CheckDeleteOrganization(Guid? organizationId);
        /// <summary>
        /// Lock organization by Id
        /// </summary>
        /// <param name="id">Organization Id</param>
        /// <param name="isLockDisAllowedForArchived">indicates whether organization can be locked for archived entity</param>
        /// <returns></returns>
        IVmEntityBase LockOrganization(Guid id, bool isLockDisAllowedForArchived = false);
        /// <summary>
        /// UnLock organization by Id
        /// </summary>
        /// <param name="id">Organization Id</param>
        /// <returns></returns>
        IVmEntityBase UnLockOrganization(Guid id);
        /// <summary>
        /// Restore Organization
        /// </summary>
        /// <param name="organizationId">id</param>
        /// <returns></returns>
        VmOrganizationHeader RestoreOrganization(Guid organizationId);
        /// <summary>
        /// Withdraw Organization
        /// </summary>
        /// <param name="organizationId">id</param>
        /// <returns></returns>
        VmOrganizationHeader WithdrawOrganization(Guid organizationId);
        /// <summary>
        /// Archive language of organization
        /// </summary>
        /// <param name="model">model with id of organization and language id</param>
        /// <returns></returns>
        VmOrganizationHeader ArchiveLanguage(VmEntityBasic model);
        /// <summary>
        /// Restore language of organization
        /// </summary>
        /// <param name="model">model with id of organization and language id</param>
        /// <returns></returns>
        VmOrganizationHeader RestoreLanguage(VmEntityBasic model);
        /// <summary>
        /// Withdraw language of organization
        /// </summary>
        /// <param name="model">model with id of organization and language id</param>
        /// <returns></returns>
        VmOrganizationHeader WithdrawLanguage(VmEntityBasic model);
        /// <summary>
        /// Get validated Entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        VmOrganizationHeader GetValidatedEntity(VmEntityBasic model);
        /// <summary>
        /// Save and validate organization.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        VmOrganizationOutput SaveAndValidateOrganization(VmOrganizationInput model);
    }
}
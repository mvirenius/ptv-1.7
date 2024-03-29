/**
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
import { createSelector } from 'reselect'
import * as CommonSelectors from '../../Common/Selectors'
import { getLanguageParameter } from '../../../Common/Selectors'

export const getSaveStep1Model = createSelector(
  [
    CommonSelectors.getChannelId,
    CommonSelectors.getChannelName,
    CommonSelectors.getDescription,
    CommonSelectors.getShortDescription,
    CommonSelectors.getOrganizationId,
    CommonSelectors.getSelectedLanguages,
    CommonSelectors.getSelectedVisitingAdressesEntities,
    CommonSelectors.getSelectedEmailEntity,
    CommonSelectors.getChannelEmailEntities,
    CommonSelectors.getChannelFaxNumberEntities,
    CommonSelectors.getPhoneNumberEntity,
    CommonSelectors.getChannelPhoneNumberEntities,
    CommonSelectors.getSelectedWebPagesEntities,
    CommonSelectors.getSelectedPostalAdressesEntities,
    CommonSelectors.getAreaInformationTypeId,
    CommonSelectors.getSelectedAreaMunicipality,
    CommonSelectors.getSelectedAreaBusinessRegions,
    CommonSelectors.getSelectedAreaHospitalRegions,
    CommonSelectors.getSelectedAreaProvince,
    CommonSelectors.getConnectionTypeId,
    getLanguageParameter
  ],
  (
    id,
    name,
    description,
    shortDescription,
    organizationId,
    languages,
    visitingAddresses,
    email,
    emails,
    faxNumbers,
    phoneNumber,
    phoneNumbers,
    webPages,
    postalAddresses,
    areaInformationTypeId,
    areaMunicipality,
    areaBusinessRegions,
    areaHospitalRegions,
    areaProvince,
    connectionTypeId,
    language
  ) => ({
    id,
    name,
    description,
    shortDescription,
    organizationId,
    languages,
    visitingAddresses,
    email,
    emails,
    faxNumbers,
    phoneNumber,
    phoneNumbers,
    webPages,
    postalAddresses,
    areaInformationTypeId,
    areaMunicipality,
    areaBusinessRegions,
    areaHospitalRegions,
    areaProvince,
    connectionTypeId,
    language
  })
)

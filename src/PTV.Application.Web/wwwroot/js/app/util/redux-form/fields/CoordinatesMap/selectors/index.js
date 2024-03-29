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
import { Map } from 'immutable'
import {
  getFormValueWithPath,
  getParameterFromProps
} from 'selectors/base'
import { getContentLanguageCode, getSelectedComparisionLanguageCode } from 'selectors/selections'
import { EnumsSelectors, EntitySelectors } from 'selectors'

const getAddressPath = props => `${props.addressUseCase}Addresses`
// form selectors
const getFormAddressesByType = createSelector(
  getFormValueWithPath(getAddressPath),
  values => values || Map()
)

export const getAddressPostalCode = createSelector(
  [
    getFormAddressesByType,
    getParameterFromProps('index', 0)
  ],
  (addresses, index) => Number.isNaN(index)
      ? addresses.get('postalCode')
      : addresses.getIn([index, 'postalCode']) || null
)

export const getAddressPostalCodeEntity = createSelector(
  [getAddressPostalCode, EntitySelectors.postalCodes.getEntities],
  (postalCode, postalCodes) => postalCodes.get(postalCode) || Map()
)

export const getAddressStreet = createSelector(
  [
    getFormAddressesByType,
    getParameterFromProps('index', 0),
    getContentLanguageCode,
    getSelectedComparisionLanguageCode,
    getParameterFromProps('compare', false)
  ],
  (addresses, index, language, comparisionLanguage, isCompare) => Number.isNaN(index)
      ? addresses.get('street')
      : (addresses.getIn([index, 'street']) || Map()).get(isCompare && comparisionLanguage || language) || null
)

export const getMunicipality = createSelector(
  [
    getFormAddressesByType,
    getParameterFromProps('index', 0)
  ],
  (addresses, index) => Number.isNaN(index)
      ? addresses.get('municipality')
      : addresses.getIn([index, 'municipality']) || null
)

export const getMunicipalityEntity = createSelector(
  [getMunicipality, EnumsSelectors.municipalities.getEntitiesMap],
  (municipality, municipalities) => municipalities.get(municipality) || Map()
)

export const getMunicipalityCode = createSelector(
  getMunicipalityEntity,
  municipality => municipality.get('code') || null
)

export const getAddressStreetNumber = createSelector(
  [
    getFormAddressesByType,
    getParameterFromProps('index', 0)
  ],
  (addresses, index) => Number.isNaN(index)
      ? addresses.get('streetNumber')
      : addresses.getIn([index, 'streetNumber']) || null
)

export const getAddressId = createSelector(
  [
    getFormAddressesByType,
    getParameterFromProps('index', 0)
  ],
  (addresses, index) => Number.isNaN(index)
      ? addresses.get('id')
      : addresses.getIn([index, 'id']) || null
)

export const getIsAddressValid = createSelector(
  [
    getMunicipalityCode,
    getAddressStreet
  ],
  (municipalityCode, street) => municipalityCode && street
)

export const getAddressInfo = createSelector(
  [
    getAddressStreetNumber,
    getMunicipalityEntity,
    getAddressStreet,
    getAddressPostalCodeEntity
  ],
  (streetNumber, municipality, streetName, postalCode) => ({
    postalCode,
    streetName,
    streetNumber,
    municipality })
)

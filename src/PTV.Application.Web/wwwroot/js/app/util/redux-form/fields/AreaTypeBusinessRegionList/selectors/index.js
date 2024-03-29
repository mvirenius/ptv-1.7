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
import { EntitySelectors } from 'selectors'
import { createSelector } from 'reselect'
import { List } from 'immutable'
import {
  getEntitiesForIds,
  getParameterFromProps
} from 'selectors/base'

const createBusinessRegionsSelector = idsSelector => createSelector(
    [EntitySelectors.businessRegions.getEntities, idsSelector],
    (businessRegions, ids) => getEntitiesForIds(businessRegions, List(ids), List())
)

const getBusinessRegionsForIds = createBusinessRegionsSelector(getParameterFromProps('ids'))

export const getBusinessRegionsForIdsJs = createSelector(
  [getBusinessRegionsForIds, getParameterFromProps('disabledAll')],
  (list, disabledAll) =>
    list.map(x => ({ value: x.get('id'), label: x.get('name'), clearableValue:!disabledAll }))
    .toArray()
  )

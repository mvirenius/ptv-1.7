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
import React from 'react'
import PropTypes from 'prop-types'
import { Field } from 'redux-form/immutable'
import {
  RenderRadioButtonGroup,
  RenderRadioButtonGroupDisplay
} from 'util/redux-form/renders'
import { injectIntl, intlShape, defineMessages } from 'react-intl'
import { compose } from 'redux'
import { connect } from 'react-redux'
import injectSelectPlaceholder from 'appComponents/SelectPlaceholderInjector'
import { getPhoneNumberTypes, getDefaultPhoneNumberType } from './selectors'
import { localizeList } from 'appComponents/Localize'
import { translateValidation } from 'util/redux-form/validators'
import { asDisableable, asComparable } from 'util/redux-form/HOC'

const messages = defineMessages({
  label: {
    id: 'Containers.Channels.AddPhoneChannel.Step1.PhoneTypes.Title',
    defaultMessage: 'Puhelinkanavan tyyppi'
  },
  tooltip: {
    id: 'Containers.Channels.AddPhoneChannel.Step1.PhoneTypes.Tooltip',
    defaultMessage: 'Puhelinkanavan tyyppi'
  }
})

const PhoneType = ({
  intl: { formatMessage },
  validate,
  ...rest
}) => (
  <Field
    name='type'
    component={RenderRadioButtonGroup}
    label={formatMessage(messages.label)}
    tooltip={formatMessage(messages.tooltip)}
    // validate={translateValidation(validate, formatMessage, messages.label)}
    {...rest}
  />
)
PhoneType.propTypes = {
  intl: intlShape,
  validate: PropTypes.func
}

export default compose(
  injectIntl,
  asComparable({ DisplayRender: RenderRadioButtonGroupDisplay }),
  asDisableable,
  connect(
    state => ({
      options: getPhoneNumberTypes(state),
      defaultValue: getDefaultPhoneNumberType(state)
    })
  ),
  localizeList({
    input: 'options',
    idAttribute: 'value',
    nameAttribute: 'label'
  }),
  injectSelectPlaceholder()
)(PhoneType)

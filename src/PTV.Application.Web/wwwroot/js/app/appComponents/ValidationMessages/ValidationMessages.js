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

// Components
import {
  getFormSyncErrors,
  // getFormAsyncErrors,
  getFormSubmitErrors,
  getFormSyncWarnings
} from 'redux-form/immutable'
import {
  hasSubmitFailed,
  getFormGeneralErrors
} from 'util/redux-form/selectors'
import { createGetFlatFormValidationErrors } from 'util/redux-form/selectors/errorMessages'
import { getValidationMessages } from 'util/redux-form/syncValidation/publishing/selectors'
import { compose } from 'redux'
import { connect } from 'react-redux'
import styles from './styles.scss'
import cx from 'classnames'
import ImmutablePropTypes from 'react-immutable-proptypes'
import { ItemList } from 'appComponents'
import { Alert } from 'sema-ui-components'
import { defineMessages, injectIntl, intlShape } from 'react-intl'
import { formActions, formActionsTypesEnum, formEntityTypes } from 'enums'
import { apiCall3 } from 'actions'
import { setReadOnly } from 'reducers/formStates'
import { withFormStates } from 'util/redux-form/HOC'
import {
  getSelectedEntityId
} from 'selectors/entities/entities'
import Scroll from 'react-scroll'
const scroll = Scroll.scroller

const messages = defineMessages({
  publishErrorTitle: {
    id: 'PublishingDialog.Language.CannotPublish.Title',
    defaultMessage: 'Kieliversiota ei voi julkaista. Tarkistathan seuraavat kohdat: '
  },
  saveErrorTitle: {
    id: 'AppComponents.ValidationMessages.CannotSave.Title',
    defaultMessage: 'Kieliversiota ei voi tallentaa. Tarkistathan seuraavat kohdat: '
  }
})

const ValidationMessages = ({
  syncErrors,
  publishErrors,
  asyncErrors,
  submitErrors,
  generalErrors,
  error,
  submitFailed,
  top,
  intl: { formatMessage }
}) => {
  const renderErrors = (label, errors, uiKey) => errors && (
    <ItemList
      type='error'
      title={label}
      items={errors}
      uiKey={uiKey}
      closable
    />
  )
  const componentClass = cx(
    styles.validationMessages,
    {
      [styles.top]: top
    }
  )
  const uiKey = top ? 'topValidationMessages' : 'bottomValidationMessages'
  // console.log(syncErrors, submitErrors)
  return (
    (submitFailed || publishErrors) &&
      <div className={componentClass}>
        {error &&
          <div style={{ margin: '5px' }}>
            <Alert warning>
              {error}
            </Alert>
          </div>
        }
        {renderErrors(formatMessage(messages.saveErrorTitle), syncErrors, uiKey)}
        {renderErrors(formatMessage(messages.saveErrorTitle), submitErrors, uiKey)}
        {renderErrors(formatMessage(messages.publishErrorTitle), publishErrors, uiKey)}
      </div>
  )
}

ValidationMessages.propTypes = {
  syncErrors: PropTypes.oneOfType([
    PropTypes.array,
    ImmutablePropTypes.list
  ]),
  asyncErrors: PropTypes.array,
  submitErrors: ImmutablePropTypes.map,
  error: PropTypes.string,
  submitFailed: PropTypes.bool,
  top: PropTypes.bool,
  intl: intlShape
}

const Messages = compose(
  injectIntl,
  connect(
    (state, { form, onClick }) => {
      let syncErrors = createGetFlatFormValidationErrors(getFormSyncErrors(form))(state) || null
      syncErrors = syncErrors && syncErrors.size > 0 && syncErrors.map(m => m.set('onClick', onClick))
      let submitErrors = createGetFlatFormValidationErrors(getFormSubmitErrors(form))(state) || null
      submitErrors = submitErrors && submitErrors.size > 0 && submitErrors.map(m => m.set('onClick', onClick))
      return {
        syncErrors,
      // asyncErrors: getFormAsyncErrors(form)(state),
        publishErrors: getValidationMessages(state, { formName: form, onClick }),
        submitErrors,
        submitFailed: hasSubmitFailed(form)(state),
        generalErrors: getFormGeneralErrors(form)(state)
      }
    }
  )
)(ValidationMessages)

export default compose(
  withFormStates,
  connect((state, { form }) => (
    {
      entityId: getSelectedEntityId(state),
      form
    }
  )))(({
    dispatch,
    form,
    isReadOnly,
    entityId,
    ...rest
  }) => {
    const lockSuccess = link => () => {
      dispatch(
        setReadOnly({
          form,
          value: false
        })
      )
      // console.log(link)
      scroll.scrollTo(link)
    }

    const handleOnErrorClick = (link) => {
      isReadOnly ? dispatch(
        apiCall3({
          keys: [formEntityTypes[form], 'loadEntity'],
          payload: {
            endpoint: formActions[formActionsTypesEnum.LOCKENTITY][form],
            data: { id: entityId }
          },
          form,
          successNextAction: () => lockSuccess(link)
        })
      ) : scroll.scrollTo(link)
    }

    return (
      <Messages {...rest} onClick={handleOnErrorClick} form={form} />
    )
  })

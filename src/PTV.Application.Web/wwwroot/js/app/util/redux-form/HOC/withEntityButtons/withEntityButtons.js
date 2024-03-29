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
import React, { PropTypes } from 'react'
import { submit, reset, change, isDirty, isSubmitting } from 'redux-form/immutable'
import { connect } from 'react-redux'
import { compose } from 'redux'
import { withFormStates, injectFormName } from 'util/redux-form/HOC'
import { Button, Spinner } from 'sema-ui-components'
import { CancelDialog } from 'appComponents'
import LanguageTabs from 'util/redux-form/fields/LanguageTabs'
import styles from './styles.scss'
import cx from 'classnames'
import { setReadOnly } from 'reducers/formStates'
import { mergeInUIState } from 'reducers/ui'
import {
  formActions,
  formActionsTypesEnum,
  formEntityTypes,
  formTypesEnum,
  securityOrganizationCheckTypes,
  permisionTypes
} from 'enums'
import { apiCall3 } from 'actions'
import {
  getSelectedEntityId,
  getEntity
} from 'selectors/entities/entities'
import { defineMessages, injectIntl, intlShape } from 'react-intl'
import {
  getPublishingStatusPublishedId } from 'selectors/common'
import { EntitySchemas } from 'schemas'
import { EntitySelectors } from 'selectors'
import withState from 'util/withState'
import { Map } from 'immutable'
import { OwnOrgSecurityPublish, OwnOrgSecurityUpdate, SecurityCreate, Security } from 'appComponents/Security'
import { getIsEntityArchived } from './selectors'
import { getIsFormDisabled } from 'selectors/formStates'

const messages = defineMessages({
  saveButton: {
    id: 'Components.Buttons.SaveButton',
    defaultMessage: 'Tallenna'
  },
  updateButton: {
    id: 'Components.Buttons.UpdateButton',
    defaultMessage: 'Muokkaa'
  },
  cancelUpdateButton: {
    id: 'Components.Buttons.CancelUpdateButton',
    defaultMessage: 'Keskeytä'
  },
  publishButton: {
    id: 'Components.Buttons.PublishButton',
    defaultMessage: 'Julkaise'
  }
})

// why it cannot be in enums???? it throws weird exception
const formSchemas = {
  [formTypesEnum.SERVICEFORM]: EntitySchemas.SERVICE_FORM,
  [formTypesEnum.GENERALDESCRIPTIONFORM]: EntitySchemas.GENERAL_DESCRIPTION,
  [formTypesEnum.ORGANIZATIONFORM]: EntitySchemas.ORGANIZATION,
  [formTypesEnum.ELECTRONICCHANNELFORM]: EntitySchemas.CHANNEL,
  [formTypesEnum.PHONECHANNELFORM]: EntitySchemas.CHANNEL,
  [formTypesEnum.PRINTABLEFORM]: EntitySchemas.CHANNEL,
  [formTypesEnum.SERVICELOCATIONFORM]: EntitySchemas.CHANNEL,
  [formTypesEnum.WEBPAGEFORM]: EntitySchemas.CHANNEL,
  [formTypesEnum.GENERALDESCRIPTIONSEARCHFORM]: '/noschema'
}

const ButtonStrip = ({
  inside,
  isReadOnly,
  formName,
  onlyEdit,
  entityId,
  dispatch,
  isDirty,
  isArchived,
  modifiedExist,
  isDialogLoading,
  isEntityLoading,
  isFormDisabled,
  updateUI,
  buttonClicked,
  resetForm,
  intl: { formatMessage }
}) => {
  const buttonGroupClass = cx(
    styles.buttonGroup,
    { [styles.inside]: inside }
  )

  const lockSuccess = () => {
    dispatch(
      setReadOnly({
        form: formName,
        value: false
      })
    )
  }

  const handleOnEdit = () => {
    !isArchived && dispatch(change(formName, 'publish', false))
    updateUI('buttonClicked', 'Edit')
    dispatch(
      apiCall3({
        keys: [formEntityTypes[formName], 'loadEntity'],
        payload: {
          endpoint: formActions[formActionsTypesEnum.LOCKENTITY][formName],
          data: { id: entityId }
        },
        formName,
        successNextAction: lockSuccess
      })
    )
  }

  const handleOnCancel = () => {
    updateUI('buttonClicked', 'Cancel')
    dispatch(mergeInUIState({
      key: `${formName}CancelDialog`,
      value: {
        isOpen: true
      }
    }))
  }

  const handleOnSave = () => {
    updateUI('buttonClicked', 'Save')
    dispatch(
      change(
        formName,
        'action',
        'save'
      )
    )
    dispatch(submit(formName))
  }

  const validateSuccess = () => {
    dispatch(mergeInUIState({
      key: `${formName}PublishingDialog`,
      value: {
        isOpen: true
      }
    }))
  }

  const handleOnPublish = () => {
    updateUI('buttonClicked', 'Publish')
    if (isDirty) {
      dispatch(
        change(
          formName,
          'action',
          'saveAndValidate'
        )
      )
      dispatch(submit(formName))
    } else {
      dispatch(
        apiCall3({
          keys: [formEntityTypes[formName], 'loadDialog'],
          payload: {
            endpoint: formActions[formActionsTypesEnum.GETVALIDATEDENTITY][formName],
            data: { id: entityId }
          },
          schemas: formSchemas[formName],
          successNextAction: validateSuccess,
          formName
        })
      )
    }
  }
  const checkOrganization = securityOrganizationCheckTypes.byOrganization
  const permisionType = entityId ? permisionTypes.update : permisionTypes.create
  return (
    <div>
      {!modifiedExist && ((isReadOnly && !entityId) || (isReadOnly && onlyEdit)
        ? <Security
          formName={formName}
          checkOrganization={checkOrganization}
          permisionType={permisionType}
        >
          <div className={buttonGroupClass}>
            <Button
              children={isEntityLoading && <Spinner /> || formatMessage(messages.updateButton)}
              onClick={handleOnEdit}
              medium
              secondary
              disabled={isFormDisabled || isEntityLoading}
            />
          </div>
        </Security>
        : <div className={buttonGroupClass}>
          {!isArchived && <Security
            formName={formName}
            checkOrganization={checkOrganization}
            permisionType={permisionType}
          >
            <Button
              children={isEntityLoading && buttonClicked === 'Cancel' && <Spinner /> ||
                formatMessage(messages.cancelUpdateButton)}
              onClick={handleOnCancel}
              medium
              secondary
              disabled={isFormDisabled || isEntityLoading || isDialogLoading}
            />
          </Security>}
          <Security
            formName={formName}
            checkOrganization={checkOrganization}
            permisionType={permisionType}
          >

            {((!entityId || onlyEdit) || (!isReadOnly && !!entityId)) &&
              <Button
                children={isDialogLoading && buttonClicked === 'Save' && <Spinner /> ||
                  formatMessage(messages.saveButton)}
                onClick={handleOnSave}
                medium
                secondary={isArchived || !!entityId}
                disabled={isFormDisabled || isDialogLoading || isEntityLoading}
              /> ||
              <Button
                children={isEntityLoading && buttonClicked === 'Edit' && <Spinner /> ||
                  formatMessage(messages.updateButton)}
                onClick={handleOnEdit}
                medium
                secondary
                disabled={isFormDisabled || isEntityLoading || isDialogLoading}
              />
            }
          </Security>
          <OwnOrgSecurityPublish
            formName={formName}
            checkOrganization={checkOrganization}
            permisionType={isReadOnly
              ? permisionTypes.publish
              : permisionTypes.publish | permisionType
            }
          >
            <Button
              children={isDialogLoading && buttonClicked === 'Publish' && <Spinner /> ||
                formatMessage(messages.publishButton)}
              onClick={handleOnPublish}
              medium
              secondary={isArchived || !entityId || onlyEdit}
              disabled={isFormDisabled || isDialogLoading || isEntityLoading}
            />
          </OwnOrgSecurityPublish>
        </div>
      )}
    </div>
  )
}

ButtonStrip.propTypes = {
  inside: PropTypes.bool,
  isReadOnly: PropTypes.bool,
  onlyEdit: PropTypes.bool.isRequired,
  isDirty: PropTypes.bool.isRequired,
  buttonClicked: PropTypes.string.isRequired,
  isDialogLoading: PropTypes.bool.isRequired,
  isArchived: PropTypes.bool.isRequired,
  isFormDisabled: PropTypes.bool.isRequired,
  modifiedExist: PropTypes.bool.isRequired,
  isEntityLoading: PropTypes.bool.isRequired,
  formName: PropTypes.string,
  intl: intlShape,
  dispatch: PropTypes.func.isRequired,
  updateUI: PropTypes.func.isRequired,
  entityId: PropTypes.string,
  resetForm: PropTypes.func.isRequired
}

const withEntityButtons = ({ formNameToSubmit = '' } = {}) => ComposedComponent => {
  const EntityButtons = props => {
    const formName = formNameToSubmit || props.formName

    return (
      <div>
        <div className={styles.entityNavigation}>
          <LanguageTabs isArchived={props.isArchived} />
          <ButtonStrip {...props} formName={formName} />
        </div>
        <ComposedComponent {...props} formName={formName} />
        <ButtonStrip inside {...props} formName={formName} />
        <CancelDialog name={formName} />
      </div>
    )
  }

  EntityButtons.propTypes = {
    formName: PropTypes.string,
    isArchived: PropTypes.bool.isRequired
  }

  return compose(
    injectFormName,
    injectIntl,
    withFormStates,
    withState({
      initialState: {
        buttonClicked: 'any'
      }
    }),
    connect((state, { formName }) => {
      const entity = getEntity(state)
      const entityPS = entity.get('publishingStatus')
      const previousInfo = entity.get('previousInfo') || Map()
      const publishedStatusId = getPublishingStatusPublishedId(state)
      const modifiedExist = !!(publishedStatusId === entityPS && previousInfo.get('lastModifiedId'))
      return {
        isDirty: isDirty(formName)(state),
        isFormDisabled: getIsFormDisabled(formName)(state),
        isArchived: getIsEntityArchived(state),
        entityId: getSelectedEntityId(state),
        onlyEdit: entityPS === publishedStatusId,
        isDialogLoading: isSubmitting(formName)(state) ||
          EntitySelectors[formEntityTypes[formName]].getEntityDialogIsFetching(state),
        isEntityLoading: isSubmitting(formName)(state) ||
          EntitySelectors[formEntityTypes[formName]].getEntityIsLoading(state),
        modifiedExist
      }
    }, {
      resetForm: reset
    })
  )(EntityButtons)
}

export default withEntityButtons

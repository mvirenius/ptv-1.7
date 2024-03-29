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
import React, { PureComponent } from 'react'
import PropTypes from 'prop-types'
import { compose } from 'redux'
import {
  Country,
  ForeignAddressText
} from 'util/redux-form/fields'
import { withFormStates } from 'util/redux-form/HOC'
import { addressUseCasesEnum } from 'enums'

class ForeignAddress extends PureComponent {
  static defaultProps = {
    name: 'foreignAddress'
  }
  render () {
    const {
      isCompareMode,
      addressUseCase,
      required
    } = this.props
    const foreignAddressTextLayoutClass = isCompareMode ? 'col-lg-24' : 'col-lg-12'
    const CountryLayoutClass = isCompareMode ? 'col-lg-24' : 'col-lg-12'
    return (
      <div>
        <div className='form-row'>
          <div className='row'>
            <div className={foreignAddressTextLayoutClass}>
              <ForeignAddressText required={required} />
            </div>
          </div>
        </div>
        {addressUseCase === addressUseCasesEnum.POSTAL &&
          <div className='form-row'>
            <div className='row'>
              <div className={CountryLayoutClass}>
                <Country />
              </div>
            </div>
          </div>}
      </div>
    )
  }
}

ForeignAddress.propTypes = {
  isCompareMode: PropTypes.bool,
  addressUseCase: PropTypes.string,
  required: PropTypes.bool
}

export default compose(
  withFormStates
)(ForeignAddress)

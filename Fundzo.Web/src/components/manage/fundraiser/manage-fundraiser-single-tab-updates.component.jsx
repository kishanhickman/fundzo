import { Component } from 'react';
import Textarea from '../../input/textarea.component';
import LabelDescription from '../../input/label-description.component';
import ButtonSubmit from '../../button/button-submit.component';

class FundraiserManageSingleTabUpdates extends Component {
  render() {
      return (
        <div>
            <h2 className='mb-4'>Write new updates for your Fundraiser</h2>
            <div className='grid mb-6'>
              <Textarea rows='8' placeholder='Tell everyone something new'/>
              <LabelDescription text='Maximum 500 characters' />
            </div>
              <ButtonSubmit className='btn-primary' title='Post your update' />
            
        </div>
  )
}
}

export default FundraiserManageSingleTabUpdates;
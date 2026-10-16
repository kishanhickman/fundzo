import { Component } from 'react';
import FundraiserNewForm from '../../../components/fundraiser/fundraiser-form/fundraiser-new-form.component';

class FundraiserNew extends Component {
  render() {
    return (
      <div className='w-full'>
        <FundraiserNewForm />
      </div>
    )
  }
}

export default FundraiserNew;
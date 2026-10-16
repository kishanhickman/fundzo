import { Component } from 'react';
import FundraiserEditForm from '../../../components/fundraiser/fundraiser-form/fundraiser-edit-form.component';

class FundraiserEdit extends Component {
    render() {
        return (
            <div className='w-full'>
                <FundraiserEditForm />
            </div>
        )
    }
}

export default FundraiserEdit;
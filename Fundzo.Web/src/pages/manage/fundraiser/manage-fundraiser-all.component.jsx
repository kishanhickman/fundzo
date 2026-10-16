import { Component } from 'react';
import FundraiserManageAllTabs from '../../../components/manage/fundraiser/manage-fundraiser-all-tabs.component';

class FundraiserManageAll extends Component {
  render() {
      return (
            <div className='w-full'>
              <div className='flex justify-between'>
                <h1 className='text-2xl'>Your Fundraisers</h1>
              </div>
              <FundraiserManageAllTabs />
            </div>
  )
}
}

export default FundraiserManageAll;
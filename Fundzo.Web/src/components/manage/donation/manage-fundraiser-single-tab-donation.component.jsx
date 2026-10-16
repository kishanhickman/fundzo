import { Component } from 'react';
import Search from '../../input/search.component';
import Button from '../../button/button.component';
import filterIcon from '../../../assets/icons/outline/filter.svg';
import ManageFundraiserSingleDonationTile from './manage-fundraiser-single-donation-tile.component';

const content = [
  {   
      id: 1,
      user: 'Some random user',
      userStatus: 'online',
      date: 'Apr 29, 2022',
      amount: '200',
      status: 'success'    
  },
  {
      id: 2,
      user: 'Some other user',
      userStatus: 'offline',
      date: 'May 2, 2022',
      amount: '150',
      status: 'pending'    
                    
  },
  {   
    id: 1,
    user: 'Some random user',
    userStatus: 'online',
    date: 'Apr 29, 2022',
    amount: '200',
    status: 'success'    
  },
  {
      id: 2,
      user: 'Some other user',
      userStatus: 'offline',
      date: 'May 2, 2022',
      amount: '150',
      status: 'pending'    
                    
  },
  {   
    id: 1,
    user: 'Some random user',
    userStatus: 'online',
    date: 'Apr 29, 2022',
    amount: '200',
    status: 'success'    
  },
  {
      id: 2,
      user: 'Some other user',
      userStatus: 'offline',
      date: 'May 2, 2022',
      amount: '150',
      status: 'pending'    
                    
  }
]

class FundraiserManageSingleTabDonation extends Component {
  render() {
      return (
        <div>
          <div className='flex flex-col md:flex-row md:justify-between items-baseline mb-4'> 
            <h2 className='mb-4 text-xl'>All Donations</h2>
            <div className='flex gap-2'>
            <Search btnClassName='bg-base-200' className='bg-base-200 border-l-base-200 focus:outline-none focus:ring-0 focus:border-primary' placeholder='Search' />
            <Button className='btn-ghost bg-base-200 gap-2' icon={filterIcon} title='Filter' />
            </div>
          </div>
          <div>
          <div className='hidden lg:grid grid-cols-6 p-4 border-b gap-4'>
            <div className='col-span-2'>User</div>
            <div className='col-span-1'>Date</div>
            <div className='col-span-1'>Amount</div>
            <div className='col-span-1'>Status</div>
          </div>
                {content.map((item) => (
                    <ManageFundraiserSingleDonationTile id={item.id} user={item.user} userStatus={item.userStatus} date={item.date} amount={item.amount} status={item.status} />              
                ))}
          </div>
        </div>
  )
}
}

export default FundraiserManageSingleTabDonation;
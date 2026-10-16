import { Component } from 'react';
import ManageTransactionTile from '../../../components/manage/transaction/manage-transaction-tile.component';
import Search from '../../../components/input/search.component';
import Button from '../../../components/button/button.component';
import filterIcon from '../../../assets/icons/outline/filter.svg';

const content = [
  {   
      id: 1,
      title: 'Raise Fund for Clean & Healthy Water',
      user: 'Some random user',
      userStatus: 'online',
      date: 'Apr 29, 2022',
      amount: '200000',
      raised: '47,000',
      total: '60,000',
      status: 'success'    
  },
  {
      id: 2,
      title: 'Donation for Cancer treatment',
      user: 'Some other user',
      userStatus: 'offline',
      date: 'May 2, 2022',
      amount: '150',
      raised: '53,000',
      total: '75,000',
      status: 'pending'    
                    
  }
]

class ManageTransactions extends Component {
  render() {
      return (
    <div>
        <div className='flex flex-col md:flex-row md:justify-between items-baseline mb-4'> 
          <h2 className='mb-4 text-2xl'>My Donations</h2>
          <div className='flex gap-2'>
          <Search btnClassName='bg-base-200' className='bg-base-200 border-l-base-200 focus:outline-none focus:ring-0 focus:border-primary' placeholder='Search' />
          <Button className='btn-ghost bg-base-200 gap-2' icon={filterIcon} title='Filter' />
          </div>
        </div>
        <div className='hidden xl:grid grid-cols-12 p-4 border-b gap-4'>
            <div className='col-span-4'>Fundraiser</div>
            <div className='col-span-3'>User</div>
            <div className='col-span-2'>Date</div>
            <div className='col-span-1'>Amount</div>
            <div className='col-span-1'>Status</div>
          </div>
              {content.map((item) => (
                  <ManageTransactionTile id={item.id} title={item.title} user={item.user} userStatus={item.userStatus} date={item.date} amount={item.amount} total={item.total} raised={item.raised} status={item.status} />              
              ))}
    </div>
  )
}
}

export default ManageTransactions;
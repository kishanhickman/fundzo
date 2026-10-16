import { Component } from 'react';
import UserImg from '../../users/user-img.component';
import dotsIcon from '../../../assets/icons/outline/dots.svg';
import DropDown from '../../dropdown/dropdown-menu.component';

class ManageFundraiserSingleDonationTile extends Component {
  render() {
      return (
        <div className='grid grid-cols-4 lg:grid-cols-6 items-center gap-4 border border-base-300 lg:border-t-0 lg:border-r-0 lg:border-l-0 rounded-lg lg:rounded-none p-4 mb-4'>
            <div className='order-1 col-span-3 lg:col-span-2'>
                <div className='flex items-center gap-4'>
                    <UserImg className='w-10' status={this.props.userStatus} />
                    <div>{this.props.user}</div>
                </div>
            </div>
            <div className='order-1 lg:order-6 col-span-1 flex justify-end'>
                <DropDown dropdownClassName='dropdown-left' btnClassName='btn-ghost btn-sm' icon={dotsIcon} />
            </div>
            <div className='order-3 lg:order-5 col-span-4 lg:col-span-1 ml-14 lg:ml-0 pb-3 lg:pb-0 border-b lg:border-0'>
                {this.props.status === 'success' 
                    ? 
                    <div className='badge badge-primary badge-outline p-4 rounded-lg text-base'>{this.props.status}</div>  
                    : 
                    <div className='badge badge-warning badge-outline p-4 rounded-lg text-base'>{this.props.status}</div> 
                }
            </div>   
            <div className='order-4 lg:order-2 col-span-2 lg:col-span-1'>
                <div className='lg:hidden'>Date</div>
                <div>{this.props.date}</div>
            </div>
            <div className='order-5 lg:order-3 col-span-2 lg:col-span-1 flex justify-end lg:justify-start mr-4 lg:mr-0'>
                <div className='flex-col'>
                    <div className='lg:hidden'>Amount</div>
                    <div>{this.props.amount}</div>
                </div>
            </div>
        </div>
  )
}
}

export default ManageFundraiserSingleDonationTile;
import { Component } from 'react';
import UserImg from '../../../components/users/user-img.component';
import dotsIcon from '../../../assets/icons/outline/dots.svg';
import DropDown from '../../dropdown/dropdown-menu.component';

class ManageDonationTile extends Component {
  render() {
      return (
        <div className='grid grid-cols-6 xl:grid-cols-12 items-center gap-4 border border-base-300 xl:border-t-0 xl:border-r-0 xl:border-l-0 rounded-lg xl:rounded-none p-4 mb-4'>
            <div className='order-1 col-span-5 xl:col-span-4 flex gap-4'> 
                    <img src='https://api.lorem.space/image?w=65&h=65' alt='' />
                    <div>
                    <div>{this.props.title}</div>
                    <div>{this.props.raised} raised of {this.props.total}</div>
                </div>
            </div>
            <div className='order-6 xl:order-2 col-span-4 xl:col-span-3'>
                <div className='flex items-center gap-4'>
                    <UserImg className='w-10' status={this.props.userStatus} />
                    <div>{this.props.user}</div>
                </div>
            </div>
            <div className='order-3 xl:order-2 col-span-3 xl:col-span-2'>
                <div className='xl:hidden'>Date</div>
                <div>{this.props.date}</div>
            </div>
            <div className='order-4 xl:order-3 col-span-3 xl:col-span-1 flex justify-end xl:justify-start mr-4 xl:mr-0'>
                <div className='flex-col'>
                    <div className='xl:hidden'>Amount</div>
                    <div>{this.props.amount}</div>
                </div>
            </div>
            <div className='order-5 xl:hidden col-span-6 border-b'></div>
            <div className='order-7 xl:order-5 col-span-2 xl:col-span-1 flex justify-end xl:justify-start mr-4 xl:mr-0'>
                {this.props.status === 'success' 
                    ? 
                    <div className='badge badge-primary badge-outline p-4 rounded-lg text-base'>{this.props.status}</div>  
                    : 
                    <div className='badge badge-warning badge-outline p-4 rounded-lg text-base'>{this.props.status}</div> 
                }
            </div>
            <div className='order-2 xl:order-6 col-span-1 flex justify-end'>
                <DropDown dropdownClassName='dropdown-left' btnClassName='btn-ghost btn-sm' icon={dotsIcon} />
            </div>   
        </div>
  )
}
}

export default ManageDonationTile;
import React from 'react';
import Button from '../../button/button.component';
import FundraiserDonationHistoryUserTile from '../../users/fundraiser-donation-history-user-tile.component';

const content = [
    {   
        id: 1,  
        userName: 'User name one',
        title: '2000',
        time: '30m'
    },
    {
        id: 2,
        userName: 'User name two',
        title: '2500',
        time: '49m'
    },
    {
        id: 3,
        userName: 'User name three',
        title: '1800',
        time: '55m'
    }
  ]

const FundraiserDonationHistoryTile = () => (
    <div className='w-full p-5 mb-3 border border-base-200 bg-base-100 rounded-lg'>
        <div className='flex flex-row mb-4'>
            <div className='mr-4'>Donation history</div>
            <div className='bg-base-200 p-1 text-xs'>8.2k</div>
        </div>
        <div className='mb-5'>
        {content.map((item) => (
            <FundraiserDonationHistoryUserTile key={item.id} userName={item.userName} amount={item.amount} time={item.time}/>
                    ))} 
        </div>
        <Button className='btn-base-300 w-full' title='View all' />
    </div>
)

export default FundraiserDonationHistoryTile;
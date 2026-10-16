import React from 'react';
import { useLocation } from 'react-router-dom';
import Button from '../../button/button.component';
import Label from '../../input/label.component';
import Input from '../../input/input.component';
import FundraiserDonationUserTile from '../../users/fundraiser-donation-user-tile.component';

const FundraiserDonationTile = () => {
    const { state } = useLocation();

    return (
        <div className='w-full p-5 mb-5 border border-base-300 rounded-lg'>
            <div className='text-3xl font-bold mb-3'>30000</div>
            <div>Raised of {state.goalAmount}</div>
            <progress className='progress progress-primary w-full mb-2' value={Math.round((30000/state.goalAmount)*100)} max='100'></progress>
            <div className='grid grid-cols-2 mb-5'>
                <div>
                    <div className='text-xl font-semibold'>20k</div>
                    <div>Donations</div>
                </div>
                <div>
                    <div className='text-xl font-semibold'>26 Days</div>
                    <div>Left to donate</div>
                </div>
            </div>
            <div className='form-control w-full'>
                <form>
                    <Label title='Donate (Minimum $100)' />
                    <Input type='text' placeholder='Amount' />
                </form>
            </div>
            <Button className='btn-primary text-base-100 w-full mb-5' title='Donate now' />
            <div className='mb-5'>
                <FundraiserDonationUserTile userName='Some awesome person' info='New york' />
            </div>
            <div>
                Created on 12 Mar 2022
            </div>
        </div>
    )
}

export default FundraiserDonationTile;
import React, { useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import FundraiserTile from './fundraiser-tile.component';
import Button from '../../button/button.component';
import { retrieveFundraisers } from '../../../actions/fundraiser';

const FundraiserExploreTiles = () => {
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(retrieveFundraisers());
    }, [dispatch]);

    const fundraisers = useSelector(state => state.fundraiser);

    return (
        <div className='container mb-10'>
            <h2 className='text-5xl py-8'>Explore causes</h2>    
            <div className='grid sm:grid-cols-2 lg:grid-cols-3 gap-10 mb-6'>
                {fundraisers.reverse().slice(0,6).map((_, index) => 
                    <FundraiserTile key={index} fundraiser={fundraisers} fundraiserIndex={index}/>                
                )}
            </div>
            <div className='container mx-auto text-center'>
                <Button className='btn-primary text-base-100' title='Show all Projects' to='/fundraiser-all' />
            </div>
        </div>
    )
}

export default FundraiserExploreTiles;
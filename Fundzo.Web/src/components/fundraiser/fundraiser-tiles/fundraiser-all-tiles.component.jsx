import React, { useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import FundraiserTile from './fundraiser-tile.component';
import { retrieveFundraisers } from '../../../actions/fundraiser';

const FundraiserAllTiles = () => {
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(retrieveFundraisers());
    }, [dispatch]);

    const fundraisers = useSelector(state => state.fundraiser);

    return (
        <div className='grid sm:grid-cols-2 lg:grid-cols-3 gap-10 mb-6'>
            {fundraisers.map((_, index) => 
                <FundraiserTile key={index} fundraiser={fundraisers} fundraiserIndex={index}/>                
            )}
        </div>
    );
}

export default FundraiserAllTiles;
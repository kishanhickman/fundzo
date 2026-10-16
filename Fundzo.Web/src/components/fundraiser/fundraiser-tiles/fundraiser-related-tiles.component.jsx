import React, { useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import FundraiserTile from './fundraiser-tile.component';
import { retrieveFundraisers } from '../../../actions/fundraiser';

const FundraiserRelatedTiles = (props) => {
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(retrieveFundraisers());
    }, [dispatch]);

    const fundraisers = useSelector(state => state.fundraiser);
    const fundraiserCategory = fundraisers.filter((fundraiser) => fundraiser.category.name === props.category.name);
    const filterOutSelectedFundraiser = fundraiserCategory.filter((fundraiser, _) => fundraiser.id !== props.id);
    return (
        <div className='bg-base-200 w-full'>
            <div className='container'>
                <h2 className='text-5xl py-8'>Related causes</h2>    
                <div className='grid sm:grid-cols-2 lg:grid-cols-3 gap-10 mb-6'>
                    {filterOutSelectedFundraiser.map((_, index) => 
                        <FundraiserTile key={index} fundraiser={filterOutSelectedFundraiser} fundraiserIndex={index}/>                
                    )}
                </div>
            </div>
        </div>
    )
}

export default FundraiserRelatedTiles;
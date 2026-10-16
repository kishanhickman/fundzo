import React, { useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import FundraiserManageFundraiserTile from './manage-fundraiser-fundraiser-tile.component';
import { retrieveFundraisers } from '../../../actions/fundraiser';

const FundraiserManageAllTabActiveFundraisers = () => {
  const dispatch = useDispatch();

  useEffect(() => {
      dispatch(retrieveFundraisers());
  }, [dispatch]);

  const fundraisers = useSelector(state => state.fundraiser);
  
  return (
    <div>
        <h2 className='mb-4'>Active fundraisers</h2>
        <div className='grid sm:grid-cols-2 xl:grid-cols-3 gap-10 mb-6'>
          {fundraisers.slice(0,6).map((_, index) => 
            <FundraiserManageFundraiserTile key={index} fundraiser={fundraisers} fundraiserIndex={index}/>                
          )}
        </div>
    </div>
  )
}

export default FundraiserManageAllTabActiveFundraisers;
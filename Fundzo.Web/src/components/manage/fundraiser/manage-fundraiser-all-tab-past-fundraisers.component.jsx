import React, { useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import FundraiserManageFundraiserTile from './manage-fundraiser-fundraiser-tile.component';
import { retrieveFundraisers } from '../../../actions/fundraiser';

const FundraiserManageAllTabPastFundraisers = () => {
  const dispatch = useDispatch();

  useEffect(() => {
      dispatch(retrieveFundraisers());
  }, [dispatch]);

  const fundraisers = useSelector(state => state.fundraiser);

  return (
    <div>
      <h2 className='mb-4'>Past fundraisers</h2>
      <div className='grid sm:grid-cols-2 xl:grid-cols-3 gap-10 mb-6'>
        {fundraisers.map((_, index) => 
          <FundraiserManageFundraiserTile key={index} fundraiser={fundraisers} fundraiserIndex={index}/>                
        )}
      </div>
    </div>
  )
}

export default FundraiserManageAllTabPastFundraisers;
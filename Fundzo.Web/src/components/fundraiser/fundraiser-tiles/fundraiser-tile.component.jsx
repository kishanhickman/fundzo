import React from "react";
import { Link } from 'react-router-dom';
import FundraiserTileUserTile from '../../users/fundraiser-tile-user-tile.component';
import Button from '../../button/button.component';
import clockIcon from '../../../assets/icons/clock.svg';

const FundraiserTile = ({fundraiser, fundraiserIndex}) => {
  return (
    <div className='card card-compact' key={fundraiserIndex}>
        <Link  to={{ 
                  pathname: `/fundraiser/${fundraiser[fundraiserIndex].id}`,
                  state: fundraiser[fundraiserIndex],
                }}
        >
            {fundraiser[fundraiserIndex].fundraiserMedias.map((media, index) =>  
                <div className='w-full h-64 bg-center bg-no-repeat bg-cover' style={{backgroundImage: `url(${media.staticMedia.blobUrl})`}} alt='' key={index}></div>
            )}
        </Link>
        <div className='card-body'>
          <div className='flex flex-row sm:flex-col xl:flex-row gap-4'>
            <div>
              <Button className='btn-accent text-white btn-sm' title={fundraiser[fundraiserIndex].category.name} to={{ pathname: `/category/${fundraiser[fundraiserIndex].category.id}`, state: fundraiser[fundraiserIndex] }} />
            </div>
            <div className='flex items-center gap-2'>
              <img src={clockIcon} alt=''/>
              <div className=''>20 Days Left</div>
            </div>
          </div>
            <h3 className='card-title'>{fundraiser[fundraiserIndex].name}</h3>
            <progress className='progress progress-primary bg-base-100 w-full' value={Math.round((30000/fundraiser[fundraiserIndex].goalAmount)*100)} max='100'></progress>
            <div className='flex justify-between my-2'>
              <div>
                <div className='text-base font-medium'>30000</div>
                <div className=''>Raised of {fundraiser[fundraiserIndex].goalAmount}</div>
              </div>  
                <span className='text-sm'>{Math.round((30000/fundraiser[fundraiserIndex].goalAmount)*100)}%</span>
            </div>
              <FundraiserTileUserTile userName='User Name'/>
        </div>
    </div>
  );
}

export default FundraiserTile;
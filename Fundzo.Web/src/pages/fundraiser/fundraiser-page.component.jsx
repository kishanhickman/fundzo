import React from 'react';
import { useLocation } from 'react-router-dom';
import UserImg from '../../components/users/user-img.component';
import FundraiserPageTabs from '../../components/fundraiser/fundraiser-page-tabs/fundraiser-page-tabs.component';
import FundraiserPageImage from '../../components/fundraiser/fundraiser-page-image/fundraiser-page-image.component';
import FundraiserDonationTile from '../../components/fundraiser/fundraiser-page-donation/fundraiser-page-donation-component';
import FundraiserDonationHistoryTile from '../../components/fundraiser/fundraiser-page-donation/fundraiser-page-donation-history.component';
import FundraiserRelatedTiles from '../../components/fundraiser/fundraiser-tiles/fundraiser-related-tiles.component';

const FundraiserPage = () => {
    const { state } = useLocation();
    return(
        <div className='w-full'>
        <div className='container'>
            <div className='max-w-xs text-sm breadcrumbs my-4'>
            <ul>
                <li>Breadcrumb 1</li>
                <li>Breadcrumb 2</li>
            </ul>
            </div>
        </div>
        <div className='container mb-2'>
            <div className='grid grid-cols-3 gap-10'>
                <div className='col-span-3 lg:col-span-2'>
                    <h1 className='text-5xl mb-6'>{state.name}</h1>
                    <div className='flex flex-row items-center mb-3'>
                    <UserImg className='w-8 h-8'/>
                    <div className='mx-3'>Liltotto Lamperd and 2 others are organizing this fundraiser.</div>
                    </div>
                    <FundraiserPageImage />
                    <FundraiserPageTabs />
                </div>
                <div className='col-span-3 lg:col-span-1'>
                    <FundraiserDonationTile />
                    <FundraiserDonationHistoryTile />
                </div>
                <div>
                </div>
            </div>
        </div>
            <FundraiserRelatedTiles {...state}/>
        </div>
    )
}

export default FundraiserPage;
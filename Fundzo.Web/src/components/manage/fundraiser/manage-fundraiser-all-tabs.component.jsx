import { React } from 'react';
import FundraiserManageAllTabActiveFundraisers from './manage-fundraiser-all-tab-active-fundraisers.component';
import FundraiserManageAllTabPastFundraisers from './manage-fundraiser-all-tab-past-fundraisers.component';
import { Tab } from '@headlessui/react'

const FundraiserManageAllTabs = () => (
    <Tab.Group>
        <Tab.List>
            <div className='my-8 border-b'>
                <Tab className={({ selected }) =>
                selected ? 'text-primary border-b-4 border-b-primary focus:outline-none' : 'text-neutral'
                } >
                <div className='p-4'>Active Fundraisers</div>
                </Tab>
                <Tab className={({ selected }) =>
                selected ? 'text-primary border-b-4 border-b-primary focus:outline-none' : 'text-neutral'
                } >
                <div className='p-4'>Past Fundraisers</div>
                </Tab>
            </div>                    
        </Tab.List>
        <Tab.Panels>
            <div className='my-8'>
                <Tab.Panel className={({ selected }) =>
                selected ? 'focus:outline-none' : ''
                } >
                    <FundraiserManageAllTabActiveFundraisers />
                </Tab.Panel>
                <Tab.Panel className={({ selected }) =>
                selected ? 'focus:outline-none' : ''
                } >
                    <FundraiserManageAllTabPastFundraisers />
                </Tab.Panel>  
            </div>                   
        </Tab.Panels>
    </Tab.Group>
)

export default FundraiserManageAllTabs;
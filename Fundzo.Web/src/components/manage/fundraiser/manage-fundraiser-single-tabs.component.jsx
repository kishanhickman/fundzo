import { React } from 'react';
import FundraiserManageSingleTabDonations from '../donation/manage-fundraiser-single-tab-donation.component';
import FundraiserManageSingleTabTeams from './manage-fundraiser-single-tab-teams.component';
import FundraiserManageSingleTabUpdates from './manage-fundraiser-single-tab-updates.component';
import { Tab } from '@headlessui/react'

const FundraiserManageSingleTabs = () => (
    <Tab.Group>
      <Tab.List>
            <div className='my-8 border-y'>
                <Tab className={({ selected }) =>
                selected ? 'text-primary border-b-4 border-b-primary focus:outline-none' : 'text-neutral'
                } >
                <div className='p-4'>Donations</div>
                </Tab>
                <Tab className={({ selected }) =>
                selected ? 'text-primary border-b-4 border-b-primary focus:outline-none' : 'text-neutral'
                } >
                <div className='p-4'>Teams</div>
                </Tab>
                <Tab className={({ selected }) =>
                selected ? 'text-primary border-b-4 border-b-primary focus:outline-none' : 'text-neutral'
                } >
                <div className='p-4'>Updates</div>
                </Tab>
            </div>                    
      </Tab.List>
      <Tab.Panels>
            <div className='my-8'>
                <Tab.Panel className={({ selected }) =>
                selected ? 'focus:outline-none' : ''
                } >
                    <FundraiserManageSingleTabDonations />
                </Tab.Panel>
                <Tab.Panel className={({ selected }) =>
                selected ? 'focus:outline-none' : ''
                } >
                    <FundraiserManageSingleTabTeams />
                </Tab.Panel>  
                <Tab.Panel className={({ selected }) =>
                selected ? 'focus:outline-none' : ''
                } >
                    <FundraiserManageSingleTabUpdates />
                </Tab.Panel>
            </div>                   
      </Tab.Panels>
    </Tab.Group>
  )

export default FundraiserManageSingleTabs;
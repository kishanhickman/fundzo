import { React } from 'react';
import FundraiserTabStory from './fundraiser-tab-story.component';
import FundraiserTabTeam from './fundraiser-tab-team.component';
import FundraiserTabWords from './fundraiser-tab-words-of-support.component';
import FundraiserTabFaq from './fundraiser-tab-faq.component';
import { Tab } from '@headlessui/react'

const FundraiserPageTabs = () => (
    <Tab.Group>
      <Tab.List>
            <div className='my-8'>
            <Tab className={({ selected }) =>
            selected ? 'text-primary border-b-4 border-b-primary focus:outline-none' : ''
            } >
            <div className='p-4'>Story</div>
            </Tab>
            <Tab className={({ selected }) =>
            selected ? 'text-primary border-b-4 border-b-primary focus:outline-none' : ''
            } >
            <div className='p-4'>Fundraising Team</div>
            </Tab>
            <Tab className={({ selected }) =>
            selected ? 'text-primary border-b-4 border-b-primary focus:outline-none' : ''
            } >
            <div className='p-4'>Words of support</div>
            </Tab>
            <Tab className={({ selected }) =>
            selected ? 'text-primary border-b-4 border-b-primary focus:outline-none' : ''
            } >
            <div className='p-4'>Faq</div>
            </Tab>
            </div>                    
      </Tab.List>
      <Tab.Panels>
            <div className='my-8'>
            <Tab.Panel className={({ selected }) =>
            selected ? 'focus:outline-none' : ''
            } >
              <FundraiserTabStory />
            </Tab.Panel>
            <Tab.Panel className={({ selected }) =>
            selected ? 'focus:outline-none' : ''
            } >
              <FundraiserTabTeam />
            </Tab.Panel>  
            <Tab.Panel className={({ selected }) =>
            selected ? 'focus:outline-none' : ''
            } >
              <FundraiserTabWords />
            </Tab.Panel>
            <Tab.Panel className={({ selected }) =>
            selected ? 'focus:outline-none' : ''
            } >
              <FundraiserTabFaq />
            </Tab.Panel>
            </div>                   
      </Tab.Panels>
    </Tab.Group>
  )

export default FundraiserPageTabs;
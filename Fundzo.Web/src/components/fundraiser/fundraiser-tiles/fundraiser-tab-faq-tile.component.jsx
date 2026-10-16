import { Component } from 'react';
import { Disclosure } from '@headlessui/react';
import { ChevronUpIcon } from '@heroicons/react/solid';

class FundraiserTabFaqTile extends Component {
  render() {
      return (
        <Disclosure as='li' className='mb-2'>
        {({ open }) => (
          <>
            <Disclosure.Button className='flex w-full justify-between focus:outline-none focus-visible:ring rounded-lg border-base-300 border'>
              <span>{this.props.title}</span>              
              <ChevronUpIcon
                className={`${
                  open ? 'rotate-180 transform' : ''
                } h-5 w-5`}
              />
            </Disclosure.Button>
            <Disclosure.Panel className='p-4 bg-base-100'>
                {this.props.text}
            </Disclosure.Panel>
          </>
        )}
      </Disclosure>
  )
}
}

export default FundraiserTabFaqTile;
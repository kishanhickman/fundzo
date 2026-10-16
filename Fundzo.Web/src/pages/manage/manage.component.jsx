import { Component } from 'react';
import { Switch, Route } from 'react-router-dom';

import FundraiserNew from './fundraiser/manage-fundraiser-new.component';
import FundraiserEdit from './fundraiser/manage-fundraiser-edit.component';
import FundraiserManageAll from './fundraiser/manage-fundraiser-all.component';
import FundraiserManageSingle from './fundraiser/manage-fundraiser-single.component';
import FundraiserReady from './fundraiser/manage-fundraiser-ready.component';
import ManageDonation from './dontation/manage-donation.component';
import ManageTransaction from './transaction/manage-transaction.component';

import DrawerSide from '../../components/drawer/drawer-side.component';
import hamburger from '../../assets/icons/outline/hamburger.svg';
import ManagePublicProfile from './public-profile/manage-public-profile.component';
import ManageSettings from './settings/manage-settings.component';

const routes = [
  {
    path: '/manage/donations',
    exact: true,
    main: () => <ManageDonation />
  },
  {
    path: '/manage/fundraiser/fundraiser-new',
    exact: true,
    main: () => <FundraiserNew />
  },
  {
    path: '/manage/fundraiser/fundraiser-edit',
    exact: true,
    main: () => <FundraiserEdit />
  },
  {
    path: '/manage/fundraiser/manage-fundraiser-all',
    exact: true,
    main: () => <FundraiserManageAll />
  },
  {
    path: '/manage/fundraiser/manage-fundraiser-single',
    exact: true,
    main: () => <FundraiserManageSingle />
  },
  {
    path: '/manage/fundraiser/fundraiser-ready',
    exact: true,
    main: () => <FundraiserReady />
  },
  {
    path: '/manage/transactions',
    exact: true,
    main: () => <ManageTransaction />
  },
  {
    path: '/manage/public-profile',
    exact: true,
    main: () => <ManagePublicProfile />
  },
  {
    path: '/manage/settings',
    exact: true,
    main: () => <ManageSettings />
  }
];

class Manage extends Component {
  render() {
    return (
      <div className='container mb-10'>
      <label for='my-drawer' className='drawer-button lg:hidden btn btn-ghost border border-base-300 active:bg-primary active:text-base-100'><div className='flex gap-4'><img className='icon' src={hamburger} alt='Menu' />Menu</div></label>
        <div className='drawer drawer-mobile'>
          <input id='my-drawer' type='checkbox' className='drawer-toggle' />
            <div className='drawer-content lg:pl-5 mt-10'>
                <Switch>
                  {routes.map((route, index) => (
                    <Route
                      key={index}
                      path={route.path}
                      exact={route.exact}
                      children={<route.main />}
                    />
                  ))}
                </Switch>
              </div>    
              <DrawerSide />
          </div>
        </div>
  )
}
}
export default Manage;
import { Component } from 'react';
import DrawerLink from './drawer-link.component';
import homeIcon from '../../assets/icons/drawer/home.svg';
import announcementIcon from '../../assets/icons/drawer/announcement.svg';
import donationsIcon from '../../assets/icons/drawer/donations.svg';
import reportsIcon from '../../assets/icons/drawer/reports.svg';
import transactionsIcon from '../../assets/icons/drawer/withdraw.svg';
import profileIcon from '../../assets/icons/drawer/public-profile.svg';
import settingsIcon from '../../assets/icons/drawer/setting.svg';
import helpIcon from '../../assets/icons/drawer/help.svg';

class DrawerSide extends Component {
    render() {
        return (
            <div className='drawer-side'>
                <label for='my-drawer' className='drawer-overlay lg:rounded-lg'></label> 
                <ul className='menu w-56 bg-base-200 py-3 overflow-y-auto lg:rounded-lg'>
                        <DrawerLink className='' to='/manage/dashboard' icon={homeIcon} title='Dashboard' />
                        <DrawerLink className='' to='/manage/fundraiser/manage-fundraiser-all' icon={announcementIcon} title='Fundraiser' />
                        <DrawerLink className='' to='/manage/donations' icon={donationsIcon} title='Donations' />
                        <DrawerLink className='' to='/manage/reports' icon={reportsIcon} title='Reports' />
                        <DrawerLink className='' to='/manage/transactions' icon={transactionsIcon} title='Transactions' />
                        <DrawerLink className='' to='/manage/public-profile' icon={profileIcon} title='My Public profile' />
                        <DrawerLink className='' to='/manage/settings' icon={settingsIcon} title='Settings' />
                        <DrawerLink className='' to='/help-center' icon={helpIcon} title='Help Center' />
                </ul>
            </div>
        )
    }
}

export default DrawerSide;


import { Component } from 'react';
import PropTypes from "prop-types";
import { withRouter } from 'react-router-dom';
import Button from '../../../components/button/button.component';
import FundraiserManageStatTile from '../../../components/manage/fundraiser/manage-fundraiser-stat-tile.component';
import FundraiserPageImage from '../../../components/fundraiser/fundraiser-page-image/fundraiser-page-image.component';
import FundraiserManageSingleTabs from '../../../components/manage/fundraiser/manage-fundraiser-single-tabs.component';

import shareIcon from '../../../assets/icons/outline/share.svg';
import editIcon from '../../../assets/icons/outline/edit.svg';
import withdrawIcon from '../../../assets/icons/outline/withdraw.svg';

import clockIcon from '../../../assets/icons/outline/clock.svg';
import donorsIcon from '../../../assets/icons/outline/donors.svg';
import locationIcon from '../../../assets/icons/outline/location.svg';
import educationIcon from '../../../assets/icons/outline/education.svg';

class FundraiserManageSingle extends Component {
  static propTypes = {
    location: PropTypes.object.isRequired,
  };

  render() {
    const { location } = this.props;
    return (
      <div className='w-full'>
        <div className='grid grid-cols-8 gap-5 my-4'>
          <div className='col-span-8 md:col-span-2'>
            <FundraiserPageImage />
          </div>
          <div className='col-span-8 md:col-span-6'>
            <div className='flex flex-col lg:flex-row gap-5 justify-between mb-4'>
              <div>
                <p>{location.state.name}</p>
                <progress className='progress progress-primary bg-base-100 w-full' value={Math.round((30000/location.state.goalAmount)*100)} max='100'></progress>
                <div className='flex justify-between my-2'>
                  <div>
                    <div className='text-xl'>47000</div>
                    <div className=''>Raised of {location.state.goalAmount}</div>
                  </div>  
                    <span className='text-sm'>{Math.round((30000/location.state.goalAmount)*100)}%</span>
                </div>
              </div>
              <div className='flex gap-4'>
                  <Button className='btn-ghost border-base-300' icon={shareIcon} to='/manage/fundraiser/fundraiser-ready' />
                  <Button className='btn-ghost border-base-300 gap-3' icon={editIcon} title='edit' to={{ pathname: '/manage/fundraiser/fundraiser-edit', state: location.state }}/>
                  <Button className='btn-ghost border-base-300 gap-3' icon={withdrawIcon} title='Withdraw' />
              </div>
            </div>
            <div className='flex flex-col lg:flex-row gap-8'>      
                <FundraiserManageStatTile icon={clockIcon} title='Created' text='Apr 28, 2022' />
                <FundraiserManageStatTile icon={donorsIcon} title='Donors' text='4000+' />
                <FundraiserManageStatTile icon={locationIcon} title='Location' text='United States' />
                <FundraiserManageStatTile icon={educationIcon} title='Category' text={location.state.category.name}/>
            </div>
          </div>
        </div>
            <FundraiserManageSingleTabs />
      </div>
    )
  }
}

export default withRouter(FundraiserManageSingle);
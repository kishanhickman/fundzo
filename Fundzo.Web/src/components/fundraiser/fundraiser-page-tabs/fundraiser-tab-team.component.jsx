import { Component } from 'react';
import FundraiserTeamUserTile from '../../users/fundraiser-team-user-tile.component';

class FundraiserTeam extends Component {
  render() {
      return (
        <div>
            <h2 className='mb-4'>Fundraising team</h2>
            <FundraiserTeamUserTile />
            <FundraiserTeamUserTile />
            <FundraiserTeamUserTile />
            <FundraiserTeamUserTile />
        </div>
  )
}
}

export default FundraiserTeam;
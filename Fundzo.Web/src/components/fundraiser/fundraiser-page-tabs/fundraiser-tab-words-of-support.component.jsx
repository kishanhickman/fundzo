import { Component } from 'react';
import FundraiserWordsUserTile from '../../users/fundraiser-words-user-tile.component';

class FundraiserTabWords extends Component {
  render() {
      return (
        <div>
            <h2 className='mb-4'>Words of support</h2>
            <FundraiserWordsUserTile />
            <FundraiserWordsUserTile />
            <FundraiserWordsUserTile />
            <FundraiserWordsUserTile />
            <FundraiserWordsUserTile />
        </div>
  )
}
}

export default FundraiserTabWords;
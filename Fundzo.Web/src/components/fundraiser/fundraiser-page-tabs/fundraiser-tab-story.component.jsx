import { Component } from 'react';
import PropTypes from "prop-types";
import { withRouter } from 'react-router-dom';

class FundraiserTabStory extends Component {
  static propTypes = {
    location: PropTypes.object.isRequired,
  };

  render() {
    const { location } = this.props;
    return (
      <div>
        <div className='mb-4'>{location.state.description}</div>
      </div>
    )
  }
}

export default withRouter(FundraiserTabStory);
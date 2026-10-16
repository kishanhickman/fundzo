import { Component } from 'react';
import PropTypes from "prop-types";
import { withRouter } from 'react-router-dom';

class FundraiserPageImage extends Component {
  static propTypes = {
    location: PropTypes.object.isRequired,
  };

  render() {
    const { location } = this.props;
    return (
      <div>
        <img src={location.state.fundraiserMedias[0].staticMedia.blobUrl} className={`rounded-lg ${this.props.className}`} alt='banner' /> 
      </div>
  )
}
}

export default withRouter(FundraiserPageImage);
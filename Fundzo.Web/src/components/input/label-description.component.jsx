import { Component } from 'react';

class LabelDescription extends Component {
  render() {
      return (
            <label>
                <span className='text-sm'>{this.props.text}</span> 
                <span className='text-sm font-bold'>{this.props.link}</span>
            </label>
  )
}
}

export default LabelDescription;
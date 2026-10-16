import { Component } from 'react';

class InputBlockDescription extends Component {
  render() {
      return (
            <label>
                <div className='font-osb'>{this.props.title}</div>
                <div className='text-neutral'>{this.props.text}</div>
            </label>
  )
}
}

export default InputBlockDescription;
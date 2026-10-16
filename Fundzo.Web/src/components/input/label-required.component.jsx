import { Component } from 'react';

class LabelRequired extends Component {
  render() {
      return (
            <label>
                <span className='after:content-["*"] after:ml-0.5 after:text-error block'>{this.props.title}</span>
            </label>
  )
}
}

export default LabelRequired;
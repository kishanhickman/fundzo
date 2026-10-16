import { Component } from 'react';

class FieldClipboardCopy extends Component {
  render() {
      return (
        <div className='flex p-4 my-4 rounded-lg border border-base-300 bg-base-200 w-full'>
            <label className='bg-base-300 flex gap-8'>
              <div>{this.props.title}</div>
              <img src={this.props.icon} alt='copy' />
            </label>
        </div>
  )
}
}

export default FieldClipboardCopy;
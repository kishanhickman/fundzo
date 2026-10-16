import { Component } from 'react';

class Radio extends Component {
  render() {
      return (
        <div className='flex gap-4'>
            <input type='radio' name={this.props.name} placeholder={this.props.placeholder} value={this.props.value} onChange={this.props.onChange} validations={this.props.validations} defaultChecked={this.props.defaultChecked}
            className={`radio ${this.props.className}`} />
            <span>{this.props.title}</span>
        </div>
  )
}
}

export default Radio;
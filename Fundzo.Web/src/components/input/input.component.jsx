import { Component } from 'react';

class Input extends Component {
  render() {
      return (
        <div>
            <input type={this.props.type} name={this.props.name} placeholder={this.props.placeholder} defaultValue={this.props.defaultValue} onChange={this.props.onChange} validations={this.props.validations}
            className='
            invalid:border-red
            focus:invalid:border-red'/>
            <span className="font-bold text-error mb-4">{ this.props.errorMessage }</span>
        </div>
  )
}
}

export default Input;
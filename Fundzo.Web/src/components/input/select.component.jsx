import { Component } from 'react';

class Select extends Component {
  render() {
      return (
        <div>
          <select onChange={this.props.onChange} defaultValue={this.props.defaultValue}
              className='invalid:border-red focus:invalid:border-red'>
              <option selected={this.props.selected}>Select {this.props.selectTitle}</option>
              {this.props.options}
          </select>
          <span className="font-bold text-error mb-4">{ this.props.errorMessage }</span>
        </div>
  )
}
}

export default Select;
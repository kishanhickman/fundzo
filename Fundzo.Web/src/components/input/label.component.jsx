import { Component } from 'react';

class Label extends Component {
  render() {
      return (
            <label>
                <span>{this.props.title}</span>
            </label>
  )
}
}

export default Label;
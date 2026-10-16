import { Component } from 'react';

class ButtonSubmit extends Component {
    render() {
        return (
            <button
            className={`btn ${this.props.className}`}
            >
            {this.props.icon}
            {this.props.title}
            </button>
        )
    }
}

export default ButtonSubmit;
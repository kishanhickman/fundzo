import { Component } from 'react';

class ButtonToggle extends Component {
    render() {
        return (
            <input type='checkbox' className={`toggle ${this.props.className}`}/>
            )
    }
}

export default ButtonToggle;






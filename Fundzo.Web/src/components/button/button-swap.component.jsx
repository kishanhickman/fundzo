import { Component } from 'react';

class ButtonSwap extends Component {
    render() {
        return (
            <label className='swap swap-rotate'>
                <input type='checkbox' />
                <img src={this.props.onIcon} className={`swap-on fill-current bg-base-100 ${this.props.className}`} alt='' />
                <img src={this.props.offIcon} className={`swap-off fill-current bg-base-100 ${this.props.className}`} alt='' />
                
            </label>
            )
    }
}

export default ButtonSwap;
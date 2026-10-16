import { Component } from 'react';
import { Link } from 'react-router-dom';

class Button extends Component {
    render() {
        return (
            <Link
            className={`btn active:border-primary-focus active:bg-primary-focus active:text-base-100 ${this.props.className}`}
            to={this.props.to}
            >
            {this.props.icon == null ? null : <img className='icon' src={this.props.icon} alt='' /> }     
            {this.props.title}
            </Link>
        )
    }
}

export default Button;
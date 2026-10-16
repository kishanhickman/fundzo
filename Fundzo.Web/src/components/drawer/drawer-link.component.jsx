import { Component } from 'react';
import { NavLink } from 'react-router-dom';

class DrawerLink extends Component {
    render() {
        return (
            <li>
                <NavLink className={`py-3 gap-4 justify-start active:text-base-100 ${this.props.className}`} to={this.props.to} >
                    <img className='icon' src={this.props.icon} alt='' />
                    {this.props.title}
                </NavLink>
            </li>
        )
    }
}

export default DrawerLink;
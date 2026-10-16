import { Component } from 'react';
import Button from '../button/button.component';

const links = [
    {   
        id: 1,
        title: 'link one',
        path: '/path/1'
    },
    {
        id: 2,
        title: 'link two',
        path: '/path/2'  
    }
  ]

class DropDown extends Component {
    render() {
        return (
            <div className={`dropdown ${this.props.dropdownClassName}`}>
            <label tabindex='0'><Button icon={this.props.icon} className={this.props.btnClassName} /></label>
            <ul tabindex='0' className='dropdown-content menu p-2 shadow bg-base-100 rounded-box w-36'>
                {links.map((item) => (
                    <li><Button id={item.id} to={item.path} title={item.title} className='btn-ghost'></Button></li>       
              ))}
            </ul>
            </div>
            )
        }
   }
            
export default DropDown;
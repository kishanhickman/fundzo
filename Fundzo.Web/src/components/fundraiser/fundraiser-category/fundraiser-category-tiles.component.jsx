import { Component } from 'react';
import { Link } from 'react-router-dom';
import arrowRightIcon from '../../../assets/icons/category/arrow-right.svg';

class CategoryTiles extends Component {
    render() {
        return (
            <li> 
                <Link tabIndex='0'
                    className='flex md:block border border-base-300 rounded-lg p-4 md:p-8 active:text-base-100'
                    to={this.props.to}
                >    
                <div className='w-full'>
                    <div className='mr-4 md:mr-0'>
                        <img className='icon-image h-16 md:-ml-2 mb-0 md:mb-8 flex-shrink' src={this.props.icon} alt={this.props.title} />
                    </div>
                    <div className='w-full'>
                        <h3 className='text-2xl'>{this.props.title}</h3>
                        <div className='flex flex-row justify-between md:justify-start'>
                            <div className='mr-3'>{this.props.numberof} Causes</div>
                            <img className='icon' src={arrowRightIcon} alt='arrow' />
                        </div>
                    </div>
                </div>
                </Link>
            </li>
        )
    }
}

export default CategoryTiles;
import { Component } from 'react';
import searchIcon from '../../assets/icons/search.svg';

class Search extends Component {
    render() {
        return (
            <div className='form-control'>
            <div className='input-group'>
            <button className={`btn btn-ghost border border-base-300 border-r-0 active:bg-primary-focus active:text-base-100 ${this.props.btnClassName}`}>
                <img className='icon' src={searchIcon} alt='Search' />
            </button>
            <input
                className={`input input-bordered border-base-300 ${this.props.className}`}
                type='search'
                placeholder={this.props.placeholder}
                value={this.props.value}
                onChange={this.props.onChange}
            />
            </div>
            </div>
        )
    }
}

export default Search;
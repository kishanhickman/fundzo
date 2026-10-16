import React, { useEffect, useCallback } from "react";
import { NavLink, Link } from 'react-router-dom';
import { useDispatch, useSelector } from "react-redux";
import Search from '../input/search.component'
import Button from '../button/button.component';
import UserImg from '../users/user-img.component';
import logo from '../../assets/images/logo-color.svg';
import { logout } from '../../actions/auth';
import { clearMessage } from '../../actions/message';
import { history } from '../../helpers/history';

const Header = () => {
  const { user: currentUser } = useSelector((state) => state.auth);
  const dispatch = useDispatch();

  useEffect(() => {
    history.listen((location) => {
      dispatch(clearMessage()); // clear message when changing location
    });
  }, [dispatch]);

  const logOut = useCallback(() => {
    dispatch(logout());
  }, [dispatch]);

  return (
    <header className='navbar container justify-between'>
        <div>
          <Link to='/' tabIndex='0'>
            <img src={logo} className='App-logo h-8 mr-3' alt='logo' />
          </Link>
          <div className='hidden lg:flex'>
            <ul className='menu menu-horizontal p-0 gap-2'>
              <li><NavLink tabIndex='0' className='btn-ghost active:bg-primary active:text-base-100' to='/fundraiser-all'>Explore Projects</NavLink></li>
              <li><NavLink tabIndex='0' className='btn-ghost active:bg-primary active:text-base-100' to='/about'>Why fundzo</NavLink></li>
            </ul>
          </div>
        </div>
        {currentUser ? (
          <div>
            <div className='flex flex-row gap-2'>
              <div className='form-control hidden md:flex'>
                  <Search className='border-l-base-100 focus:outline-none focus:ring-0 focus:border-primary' placeholder='Search' />
              </div>
              <Button className='btn btn-base-content' title='Start Fundraising' to='/manage/fundraiser/fundraiser-new' />
              <div className='dropdown dropdown-end'>
                <label tabIndex='0' className='btn btn-ghost btn-circle'>
                  <UserImg to='/' className='h-10 w-10' status='online' />
                </label>
                <ul tabIndex='0' className='mt-3 p-2 menu menu-compact dropdown-content bg-base-100 border border-base-300 rounded-box w-52'>
                  <li>
                    <Link to='/manage/fundraiser/manage-fundraiser-all' className='nav-link'>
                      Your Fundraisers
                      <span className='badge badge-error text-base-100'>New</span>
                    </Link>
                  </li>
                  <li>
                    <Link to='/manage/settings' className='nav-link'>
                      Settings
                    </Link>
                  </li>
                  <li>
                    <Link to='/manage/public-profile' className='nav-link'>
                      Public profile
                    </Link>
                  </li>
                  <li>
                    <Link to='/' className='nav-link btn-error' onClick={logOut}>
                      Log Out
                    </Link>
                  </li>
                </ul>
              </div>
            </div>
          </div>
        ) : (
          <div>
            <div className='flex flex-row gap-2'>
              <div className='form-control hidden lg:flex'>
                <Search className='border-l-base-100 focus:outline-none focus:ring-0 focus:border-primary' placeholder='Search' />
              </div>
              <Button tabindex='0' className='btn-ghost active:bg-primary active:text-base-100' title='Login' to='/login' />
              <Button tabindex='0' className='btn-base-content hidden lg:flex' title='Create Project' to='login' />
            </div>
          </div>
        )}
    </header>
  )
}

export default Header;
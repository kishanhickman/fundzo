import React from 'react';
import { Link } from 'react-router-dom';
import FooterSocial from './footer-social.component';
import footerlogo from '../../assets/images/logo-white.svg';

const Footer = () => (
    <footer>
            <div className='container pt-20 text-base-300'>
                <div className='grid grid-cols-1 sm:grid-cols-3 md:grid-cols-6 gap-8'>
                    <div className='col-span-2 sm:col-span-3 md:col-span-2'>
                    <div className='flex-shrink-0'>
                    <Link to='/'><img src={footerlogo} className='App-logo h-8 mb-8' alt='logo' /></Link>
                    </div>
                        <p>No matter how small the donation you give will mean a lot to them, let's donate now to help fellow humans in need</p>
                    </div>
                    <div className='col-span-1 sm:col-span-2 lg:col-span-1'>
                        <p className='mb-4 font-ob'>About</p>
                        <p className='mb-4'>How Fundzo works</p>
                        <p className='mb-4'>Success stories</p>
                        <p className='mb-4'>Who we are</p>
                        <p className='mb-4'>Start Crowdfunding</p>
                        <p className='mb-4'>Join Fundzo</p>
                    </div>
                    <div className='col-span-1 sm:col-span-2 lg:col-span-1'>
                        <p className='mb-4 font-ob'>Resources</p>
                        <p className='mb-4'>Help & Support</p>
                        <p className='mb-4'>Blog</p>
                        <p className='mb-4'>Updates</p>
                        <p className='mb-4'>Common Questions</p>
                    </div>
                    <div className='col-span-3 md:col-span-6 lg:col-span-2'>
                        <p className='mb-4 font-ob'>Newsletter</p>
                        <p>The latest cause news, articles, sent to your inbox weekly.</p> 
                        <div className='form-control w-full'>
                        <label className='label'>
                            <span className='label-text'>Enter your email address</span>
                        </label> 
                        <div className='relative input-group'>
                            <input type='email' placeholder='username@site.com' className='input input-bordered w-full text-base-content' /> 
                            <button className='btn btn-primary'>Subscribe</button>
                        </div>
                        </div>
                    </div>
                </div>
                <div className='grid md:col-span-6 lg:grid-cols-2 py-20'>
                <div><p className='flex justify-start'>2022 @ Fundzo. All rights reserved.</p></div>
                <FooterSocial />
                </div>
                </div>
        </footer>
)
export default Footer
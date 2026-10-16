import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import Button from '../button/button.component';
import BannerStats from './banner-stats.component';
import bannerImg1 from '../../assets/images/banner-image-1.png';
import bannerImg2 from '../../assets/images/banner-image-2.png';
import { clearMessage } from '../../actions/message';
import { history } from '../../helpers/history';

const Banner = () => {
    const { user: currentUser } = useSelector((state) => state.auth);
    const dispatch = useDispatch();

    useEffect(() => {
        history.listen((location) => {
            dispatch(clearMessage()); // clear message when changing location
        });
    }, [dispatch]);

    return (
        <div className='bg-secondary w-full lg:mb-20'>
        <div  className='container pt-7 lg:pt-14'>
                <div className='grid lg:grid-cols-2'>
                    <div className='mb-3'>
                        <h1 className='text-5xl md:text-6xl xl:text-7xl leading-tight lg:mt-20'>Empowering communities to thirve</h1>
                        <p className='my-6 lg:my-12 lg:mr-40'>Create a project through Fundzo and get all the support you need from funding through to professional consultancy and digital marketing.</p>
                        {currentUser ? (
                            <Button to='/manage/fundraiser/fundraiser-new' className='btn-primary text-white' title='Create Project'/>
                        ) : (
                                <Button to='/login' className='btn-primary text-white' title='Create Project'/>
                        )}
                    </div>
                    <div className='carousel bg-[url("./assets/images/banner-bg.png")] bg-no-repeat bg-left-top bg-[length:100%]'>
                        <div className='carousel-item w-full'>
                            <img src={bannerImg2} className='image-full' alt='logo' />
                        </div>
                        <div className='carousel-item w-full'>
                            <img src={bannerImg1} className='image-full' alt='logo' />
                        </div>
                    </div> 
                    
                </div>       
        </div>
        <div className='bg-base-100 w-full'>
            <div className='container mx-auto'>
            <BannerStats /> 
            </div>
        </div>
        </div>
    )
}
export default Banner
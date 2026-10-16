import React from 'react';
import CallToActionCauseList from './call-to-action-about-cause.list.component';
import causeImg from '../../../assets/images/call-to-action-about-cause-img.png';
import budgetIcon from '../../../assets/icons/budget.svg';
import donatiIcon from '../../../assets/icons/donati.svg';
import eventIcon from '../../../assets/icons/event.svg';
import emergencyIcon from '../../../assets/icons/emergency.svg';

const content = [
    {   icon: budgetIcon, 
        title: 'The best for every budget', 
        text: 'Join today in our effort to make someone feel blessed today and Donate as little as $1 to avoid the scam donations.',
        id: 1 
    },
    {   icon: donatiIcon, 
        title: 'Help people in need', 
        text: 'Provide direct support to an individual, family or community by paying medical expenses or offering financial aid.',
        id: 2  
    },
    {
        icon: eventIcon, 
        title: 'Take part in a charity event', 
        text: 'Choose from hundreds of official events including marathons, bike rides, Dryathlons and bake offs.',
        id: 3 
    },
    {
        icon: emergencyIcon, 
        title: 'Take action in an emergency', 
        text: 'Raise funds in response to a natural disaster or humanitarian crisis. Make a difference in minutes.',
        id: 4
    }
  ]

const CallToActionAboutCause = () => (
    <div className='bg-base-200'>
    <div  className='container pb-20'>
        <div className=''>
            <div className='grid md:grid-cols-2 gap-8'>
                <div className='order-1 md:order-2'>
                <img src={causeImg} className='' alt='Family' />
                </div>
                <div className='order-2 md:order-1'>
                <div className='my-20'>
                <h2 className='text-5xl my-10'>Give A Hand To Make The Better World</h2>
                {content.map((item) => (
                    <CallToActionCauseList icon={item.icon} title={item.title} text={item.text} key={item.id}/>               
                ))}
                </div>
                </div>
            </div>    
        </div>
    </div>
    </div>
)
export default CallToActionAboutCause
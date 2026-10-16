import { Component } from 'react';
import { connect } from "react-redux";
import Button from '../../button/button.component';
import stepIcon from '../../../assets/icons/step.svg';
import generousIcon from '../../../assets/icons/generous.svg';
import worldIcon from '../../../assets/icons/world.svg';
import raiseIcon from '../../../assets/icons/raise.svg';
import CallToActionAboutFundzoTile from './call-to-action-about-fundzo-tile.component';

const content = [
    {   icon: stepIcon, 
        title: 'Giving should be Easy', 
        text: 'Fundzo make it incredibly easy for your supporters to give, resulting in much higher conversion.',
        id: 1 
    },
    {   icon: generousIcon, 
        title: 'Unlock the Generosity', 
        text: 'Inspire suppoteres with your story, mobilize indivdual fundraisers, Fundzo encourge more people to give and get more people involved over time.',
        id: 2  
    },
    {
        icon: worldIcon, 
        title: 'Worldwide Leader', 
        text: 'Through the power of giving, we make the world a better place. Fundzo is trusted around the world for its simple, reliable fundraising platform.',
        id: 3 
    },
    {
        icon: raiseIcon, 
        title: 'Be an Empowered Fundraiser', 
        text: 'Create high-performing campsign and get access to unified dashboard and thoughtful integrations make fundraisng easy and efficient.',
        id: 4
    }
]

class CallToActionAboutFundzo extends Component {
    render() {
        const { isLoggedIn } = this.props;
        return (
            <div  className='container'>
                    <div className='grid lg:grid-cols-2 gap-12'>
                        <div className='min-h-full md:min-h-fit rounded-lg bg-secondary bg-[url("./assets/images/signup-bg.svg")] bg-no-repeat bg-local bg-bottom bg-cover px-10 pt-10 pb-20'>
                            <h2 className='text-4xl mb-5'>Raise money for any project that inspires you.</h2>
                            <p className='mb-5'>Get the help and support you need from a global network of consultants, engineers and leading experts to ensure your projects success!</p>
                            {isLoggedIn ? (
                            <Button to='/manage/fundraiser/fundraiser-new' className='btn-accent text-base-100' title='Create Project' />
                            ) : (
                                <Button to='/login' className='btn-accent text-base-100' title='Create Project' />
                            )}         
                        </div>
                        <div>
                            <div className='grid md:grid-cols-2 gap-4 md:gap-12'>
                            {content.map((item) => (
                                <CallToActionAboutFundzoTile icon={item.icon} title={item.title} text={item.text} key={item.id}/>               
                            ))}
                            </div>
                        </div>
                    </div>    
            </div>
        )
    }
}

function mapStateToProps(state) {
    const { isLoggedIn } = state.auth;;
    return {
        isLoggedIn,
    };
}

export default connect(mapStateToProps)(CallToActionAboutFundzo);
import { Component } from 'react';
import LabelBlockDescription from '../../../components/input/label-block-description.component';
import ButtonSubmit from '../../../components/button/button-submit.component';
import ButtonSwap from '../../../components/button/button-swap.component';
import ButtonToggle from '../../../components/button/button-toggle.component';
import sunIcon from '../../../assets/icons/outline/sun.svg';
import moonIcon from '../../../assets/icons/outline/moon.svg';


class ManageSettings extends Component {
    render() {
        return (
            <div className='container'>
                <h1 className='text-2xl'>Manage Settings</h1>
                <div className='my-4 py-4 border-t'>
                    <form>
                        <div className='input-block grid lg:grid-cols-8 gap-4 items-center'>
                            <div className='col-span-1 lg:col-span-2'>
                                <LabelBlockDescription title='Preferred theme' text='Choose if you want the light or dark theme for your experience' />
                            </div>
                            <div className='lg:col-start-4 lg:col-span-5'>    
                                <ButtonSwap className='w-10 h-10' offIcon={sunIcon} onIcon={moonIcon}  />
                            </div>
                        </div>
                        <div className='input-block grid lg:grid-cols-8 gap-4 items-center'>
                            <div className='col-span-1 lg:col-span-2'>
                                <LabelBlockDescription title='Profile information' text='Make my profile information public' />
                            </div>
                            <div className='lg:col-start-4 lg:col-span-5'>    
                                <ButtonToggle className='toggle-primary' />
                            </div>
                        </div>
                        <div className='input-block grid lg:grid-cols-8 gap-4 items-center'>
                            <div className='col-span-1 lg:col-span-2'>
                                <LabelBlockDescription title='Contact information' text='Make my contact information public' />
                            </div>
                            <div className='lg:col-start-4 lg:col-span-5'>    
                                <ButtonToggle className='toggle-primary' />
                            </div>
                        </div>
                        <div className='input-block grid lg:grid-cols-8 gap-4 items-center'>
                            <div className='col-span-1 lg:col-span-2'>
                                <LabelBlockDescription title='Send updates' text='Send updates to my email' />
                            </div>
                            <div className='lg:col-start-4 lg:col-span-5'>    
                                <ButtonToggle className='toggle-primary' />
                            </div>
                        </div>
                        <div className='grid lg:grid-cols-8 gap-4'>
                            <div className='col-span-1 lg:col-span-2'>
                            </div>
                            <div className='lg:col-start-4 lg:col-span-5'>
                                <div className='flex justify-end gap-4 pb-4 items-center'>    
                                    <ButtonSubmit className='btn-primary' title='save settings' />
                                    <ButtonSubmit className='btn-warning' title='default settings' />
                                </div>
                            </div>
                        </div>       
                    </form>
                </div>
            </div>
        )
    }
}

export default ManageSettings;
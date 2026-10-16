import { Component } from 'react';
import Input from '../../../components/input/input.component';
import Select from '../../../components/input/select.component';
import LabelBlockDescription from '../../../components/input/label-block-description.component';
import LabelRequired from '../../../components/input/label-required.component';
import ButtonSubmit from '../../../components/button/button-submit.component';

class ManagePublicProfile extends Component {
    render() {
        return (
            <div className='container'>
                <h1 className='text-2xl'>Public profile</h1>
                <div className='my-4 py-4 border-t'>
                    <form>
                        <div className='input-block grid lg:grid-cols-8 gap-4 items-center'>
                            <div className='col-span-1 lg:col-span-2'>
                                <LabelRequired title='First Name' />
                            </div>
                            <div className='lg:col-start-4 lg:col-span-5'>    
                                <Input type='text' />
                            </div>
                        </div>
                        <div className='input-block grid lg:grid-cols-8 gap-4 items-center'>
                            <div className='col-span-1 lg:col-span-2'>
                                <LabelRequired title='Last Name' />
                            </div>
                            <div className='lg:col-start-4 lg:col-span-5'>    
                                <Input type='text' />
                            </div>
                        </div>
                        <div className='input-block grid lg:grid-cols-8 gap-4 items-center'>
                            <div className='col-span-1 lg:col-span-2'>
                                <LabelRequired title='Username' />
                            </div>
                            <div className='lg:col-start-4 lg:col-span-5'>    
                                <Input type='text' />
                            </div>
                        </div>
                        <div className='input-block grid lg:grid-cols-8 gap-4 items-center'>
                            <div className='col-span-1 lg:col-span-2'>
                                <LabelRequired title='Email' />
                            </div>
                            <div className='lg:col-start-4 lg:col-span-5'>    
                                <Input type='email' />
                            </div>
                        </div>
                        <div className='input-block grid lg:grid-cols-8 gap-4 items-center'>
                            <div className='col-span-1 lg:col-span-2'>
                                <LabelBlockDescription title='Organisation' />
                            </div>
                            <div className='lg:col-start-4 lg:col-span-5'>    
                                <Select />
                            </div>
                        </div>
                        <div className='input-block grid lg:grid-cols-8 gap-4 items-center'>
                            <div className='col-span-1 lg:col-span-2'>
                                <LabelRequired title='Password' />
                            </div>
                            <div className='lg:col-start-4 lg:col-span-5'>    
                                <Input type='password' />
                            </div>
                        </div>
                        <div className='grid lg:grid-cols-8 gap-4'>
                            <div className='col-span-1 lg:col-span-2'>
                            </div>
                            <div className='lg:col-start-4 lg:col-span-5'>
                                <div className='flex justify-end gap-4 pb-4 items-center'>    
                                    <ButtonSubmit className='btn-primary' title='Update profile' to='' />
                                    <ButtonSubmit className='btn-error' title='Delete profile' to='' />
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        )
    }
}

export default ManagePublicProfile;
import { Component } from 'react';
import SignupForm from './signup-form.component';

class Signup extends Component {
  render() {
    return (
      <div className='container mb-10'>
        <div className='grid lg:grid-cols-2'>
          <div className='bg-secondary rounded-lg order-1 lg:order-2 bg-[url("./assets/images/signup-bg.svg")] bg-no-repeat bg-local bg-bottom bg-cover h-60 lg:min-h-full'>
            <div className='p-20 hidden lg:block'>
              <h2 className='text-5xl xl:text-6xl 2xl:text-7xl mb-16'>Give A Hand To Make The Better World.</h2>
              <p className='text-xl xl:text-2xl mb-10'>No matter how small the donation you give will mean a lot to them, lets donate now to help fellow humans in need.</p>
              <div className='avatar-group -space-x-3'>
                <div className='avatar'>
                  <div className='w-10'>
                    <img src='https://api.lorem.space/image/face?hash=53273' alt='1'/>
                  </div>
                </div>
                <div className='avatar'>
                  <div className='w-10'>
                    <img src='https://api.lorem.space/image/face?hash=91831' alt='2'/>
                  </div>
                </div>
                <div className='avatar'>
                  <div className='w-10'>
                    <img src='https://api.lorem.space/image/face?hash=27312' alt='3'/>
                  </div>
                </div>
                <div className='avatar'>
                  <div className='w-10'>
                    <img src='https://api.lorem.space/image/face?hash=26448' alt='4'/>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div className='order-2 lg:order-1'>
            <h1 className='text-3xl lg:text-4xl xl:text-5xl mb-4 mt-4'>Create New Account</h1>
            <p className='mb-8 text-neutral'>Welcome to Fundzo ! Lets’ get you setup!</p>
            <SignupForm />
            <p className='block text-sm'>By continuing, you agree to the GoFundMe terms and privacy policy.</p>
          </div>
        </div>
      </div>
    )
  }
}

export default Signup;
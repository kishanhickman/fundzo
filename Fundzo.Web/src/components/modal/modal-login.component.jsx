import { Component } from 'react';
import LoginComponent from '../../pages/login/login.component';
import loginComponent from '../../pages/login/login.component';

class LoginModal extends Component {
    render() {
        return (
          <div>
          <input type='checkbox' id='login-modal' className='modal-toggle' />
          <label for='login-modal' className='modal cursor-pointer'>
            <div className='modal-box relative' for=''>
              <LoginComponent />
            </div>
          </label>
          </div>
        )
    }
}

export default LoginModal;


import React, { Component } from "react";
import { Redirect } from 'react-router-dom';
import toastr from 'toastr';
import Form from "react-validation/build/form";
import LabelRequired from "../../components/input/label-required.component";
import Input from "../../components/input/input.component";
import ButtonSubmit from "../../components/button/button-submit.component";
import Button from "../../components/button/button.component";
import { login } from "../../actions/auth";
import { connect } from "react-redux";
import CheckButton from "react-validation/build/button";

class Login extends Component {
  constructor(props) {
    super(props);
    this.handleLogin = this.handleLogin.bind(this);
    this.onChangeUsername = this.onChangeUsername.bind(this);
    this.onChangePassword = this.onChangePassword.bind(this);
    this.state = {
      fields: {
        username: "",
        password: "",
        loading: false,
      },
      errors: {
        usernameError: '',
        passwordError: '',
      }
    };
  }

  onChangeUsername(e) {
    this.setState({ fields: {
      ...this.state.fields,
      username: e.target.value,
    }
    });
  }

  onChangePassword(e) {
    this.setState({ fields: {
      ...this.state.fields,
      password: e.target.value,
    }
    });
  }

  validateForm() {
    const { username, password } = this.state.fields;
    const errors = {};

    if (username === '') { errors.usernameError = 'Username is required.'; }
    if (password === '') { errors.passwordError = 'Password is required.'; }

    if (Object.keys(errors).length > 0) {
      this.setState({ ...this.state.errors, errors });
      return false;
    }

    return true;
  }

  handleLogin(e) {
    e.preventDefault();

    this.setState({ fields: {
      ...this.state.fields,
      loading: true,
    }
    });

    const { username, password } = this.state.fields;

    const { dispatch, history } = this.props;

    if (this.validateForm()) {
      dispatch(login(username, password))
        .then(() => {
          toastr.success('Login successful!', 'Success!');
          history.push("/manage/fundraiser/fundraiser-new");
        })
        .catch(() => {
          toastr.error('Incorrect username or password!', 'Failed!');
          this.setState({ fields: {
            ...this.state.fields,
            loading: false,
          }
          });
        });
    } else {
      toastr.error('Incorrect username or password!', 'Failed!');
      this.setState({ fields: {
        ...this.state.fields,
        loading: false,
      }
      });
    }
  }

  render() {
    const { isLoggedIn } = this.props;
    const { username, password } = this.state.fields;
    const { usernameError, passwordError } = this.state.errors;

    if (isLoggedIn) {
      return <Redirect to="/manage/fundraiser/fundraiser-new" />
    };

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
          <h1 className='text-3xl lg:text-4xl xl:text-5xl mb-4 mt-4'>Login</h1>
          <p className='mb-8 text-neutral'>Welcome to Fundzo ! Lets’ get your fundraiser going!</p>
          <div className='container'>
            <Form onSubmit={(e) => this.handleLogin(e)}>
              <div className='container'>
                <div className='my-40 mx-auto'>
                  <LabelRequired title='Username' />
                  <Input type='text' placeholder='Username' value={username} onChange={this.onChangeUsername} errorMessage={usernameError} />      
                  <LabelRequired title='Password' />
                  <Input type='password' placeholder='Password' value={password} onChange={this.onChangePassword} errorMessage={passwordError} />
                  <ButtonSubmit title='login' className='btn-primary btn-block' />
                </div>
              </div>
              <CheckButton
                  style={{ display: "none" }}
                  ref={(c) => {
                    this.checkBtn = c;
                  }}
              />
            </Form>
            <h2 className='text-2xl lg:text-3xl xl:text-4xl mb-4 mt-4'>Not registered?</h2>
            <h3 className='text-xl lg:text-2xl xl:text-3xl mb-4 mt-4'>Creating a new account is simple.</h3>
            <Button className='btn-primary btn-block' to='/signup' title='Create new account' />
          </div>
        </div>
      </div>
    </div>




    )
  }
}

function mapStateToProps(state) {
  const { isLoggedIn } = state.auth;
  const { message } = state.message;
  return {
    isLoggedIn,
    message
  };
}

export default connect(mapStateToProps)(Login);
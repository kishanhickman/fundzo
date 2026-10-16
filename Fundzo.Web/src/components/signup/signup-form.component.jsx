import React, { Component } from 'react';
import validator from 'validator';
import toastr from 'toastr';
import Form from 'react-validation/build/form';
import CheckButton from 'react-validation/build/button';
import LabelRequired from '../input/label-required.component';
import Input from '../input/input.component';
import { connect } from 'react-redux';
import { register } from '../../actions/auth';
import { CountryDropdown } from 'react-country-region-selector';

class SignupForm extends Component {
  constructor(props) {
    super(props);
    this.handleRegister = this.handleRegister.bind(this);
    this.onChangeUsername = this.onChangeUsername.bind(this);
    this.onChangeEmail = this.onChangeEmail.bind(this);
    this.onChangePassword = this.onChangePassword.bind(this);
    this.onChangeFirstName = this.onChangeFirstName.bind(this);
    this.onChangeLastName = this.onChangeLastName.bind(this);
    this.onChangeCountry = this.onChangeCountry.bind(this);
    this.onChangeZipCode = this.onChangeZipCode.bind(this);
    this.state = {
      fields: {
        username: '',
        email: '',
        password: '',
        firstName: '',
        lastName: '',
        country: '',
        zipCode: '',
        successful: false,
      },
      errors: {
        usernameError: '',
        emailError: '',
        passwordError: '',
        firstNameError: '',
        lastNameError: '',
        countryError: '',
        zipCodeError: '',
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

  onChangeEmail(e) {
    this.setState({ fields: {
      ...this.state.fields,
      email: e.target.value,
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

  onChangeFirstName(e) {
    this.setState({ fields: {
      ...this.state.fields,
      firstName: e.target.value,
    }
    });
  }

  onChangeLastName(e) {
    this.setState({ fields: {
      ...this.state.fields,
      lastName: e.target.value,
    }
    });
  }

  onChangeCountry(e) {
    this.setState({ fields: {
      ...this.state.fields,
      country: e.target.value,
    }
    });
  }

  onChangeZipCode(e) {
    this.setState({ fields: {
      ...this.state.fields,
      zipCode: e.target.value,
    }
    });
  }

  selectCountry (val) {
    this.setState({ fields: {
      ...this.state.fields,
      country: val,
    }
    });
  }

  validateForm() {
    const { username, email, password, firstName, lastName, country, zipCode } = this.state.fields;
    const errors = {};

    if (!validator.isEmail(email)) { errors.emailError = 'Email is not properly formatted.'; }
    if (username === '') { errors.usernameError = 'Username is required.'; }
    if (password === '') { errors.passwordError = 'Password is required.'; }
    if (firstName === '') { errors.firstNameError = 'First name is required.'; }
    if (lastName === '') { errors.lastNameError = 'Last name is required.'; }
    if (country === '') { errors.countryError = 'Country is required.'; }
    if (zipCode === '') { errors.zipCodeError = 'Zip code is required.'; }

    if (Object.keys(errors).length > 0) {
      this.setState({ ...this.state.errors, errors });
      return false;
    }

    return true;
  }


  handleRegister(e) {
    e.preventDefault();
    const { username, email, password, firstName, lastName, country, zipCode } = this.state.fields;
    
    if (this.validateForm()) {
      this.props
        .dispatch(
          register(username, email, password, firstName, lastName, country, zipCode)
        )
        .then(() => {
          toastr.success('The form was successfully submitted!', 'Success!');
          this.setState({ fields: {
            ...this.state.fields,
            successful: true,
          }
          });
        })
        .catch(() => {
          toastr.error('The form was not successfully submitted!', 'Failed!');
          this.setState({ fields: {
            ...this.state.fields,
            successful: false,
          }
          });
        });
    } else {
      toastr.error('The form was not successfully submitted!', 'Failed!');
      this.setState({ fields: {
        ...this.state.fields,
        successful: false,
      }
      });
    }
  }

  render() {
    const { username, email, password, firstName, lastName, country, zipCode, successful } = this.state.fields;
    const { usernameError, emailError, passwordError, firstNameError, lastNameError, countryError, zipCodeError } = this.state.errors;
    return (
      <Form className='lg:pr-8 xl:pr-20' onSubmit={(e) => this.handleRegister(e)}>
        {!successful && (
          <div>
            <div className='grid lg:grid-cols-2 gap-4'>
              <div>
                <LabelRequired title='First Name' />
                <Input type='text' placeholder='Enter first name' value={firstName} onChange={this.onChangeFirstName} errorMessage={firstNameError} />
              </div> 
              <div>  
                <LabelRequired title='Last Name' />
                <Input type='text' placeholder='Enter last name' value={lastName} onChange={this.onChangeLastName} errorMessage={lastNameError} />
              </div>
            </div>
                <LabelRequired title='Username' />
                <Input type='text' placeholder='Enter username' value={username} onChange={this.onChangeUsername} errorMessage={usernameError} />
                <LabelRequired title='Email' />
                <Input type='text' placeholder='you@example.com' name='email' value={email} onChange={this.onChangeEmail} errorMessage={emailError} />
            <div className='lg:flex gap-4'>
              <div className='flex-auto lg:w-60'>
                <LabelRequired title='Where do you live?' />
                <CountryDropdown value={country} onChange={(val) => this.selectCountry(val)} />
                <span className="font-bold text-error mb-4">{countryError}</span>
              </div>
              <div className='flex-auto lg:w-40'>
                <LabelRequired title='Zip code' />
                <Input type='text' placeholder='Search zip code' value={zipCode} onChange={this.onChangeZipCode} errorMessage={zipCodeError} />
              </div>
            </div>
              <LabelRequired title='Password' />
              <Input type='password' placeholder='Password' value={password} onChange={this.onChangePassword} errorMessage={passwordError} />
            <button className='btn btn-primary btn-block my-4'>
              Create Account
            </button>        
          </div>
        )}
        <CheckButton
          style={{ display: 'none' }}
          ref={(c) => {
            this.checkBtn = c;
          }}
        />
      </Form>
    )
  }
}

function mapStateToProps(state) {
  const { message } = state.message;
  return {
    message,
  };
}

export default connect(mapStateToProps)(SignupForm);
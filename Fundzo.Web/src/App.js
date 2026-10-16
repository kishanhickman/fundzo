import React from 'react';
import { Switch, Route, useLocation } from 'react-router-dom';
import './App.css';
import Home from './pages/home/home.component';
import Signup from './components/signup/signup.component';
import About from './pages/about/about.component';
import FundraiserPage from './pages/fundraiser/fundraiser-page.component';
import FundraiserAllPage from './pages/fundraiser/fundraiser-all-page.component';
import FundraiserCategoryPage from './pages/fundraiser/fundraiser-category-page.component';
import Login from './pages/login/login.component';
import Header from './components/header/header.component';
import Footer from './components/footer/footer.component';
import Manage from './pages/manage/manage.component'; 

function App() {

    const search = useLocation().search;
    const devMode = new URLSearchParams(search).get('devmode');
    const className = devMode === 'true' ? '' : 'overflow-hidden '

    return (
      <div className={'flex flex-col h-screen select-none ' + className}>
        <Header />
        <main className='flex flex-grow'>
            <Switch>
                <Route exact path='/' component={Home} />
                <Route exact path='/about' component={About} />
                <Route exact path='/login' component={Login} />
                <Route exact path='/signup' component={Signup} />
                <Route path='/fundraiser/:fundraiserID' component={FundraiserPage} />
                <Route path='/fundraiser-all' component={FundraiserAllPage} />
                <Route path='/category/:categoryID' component={FundraiserCategoryPage} />
                <Route path='/manage' component={Manage} />
            </Switch>
        </main>
        <Footer />
      </div>
    );
  }

export default App;
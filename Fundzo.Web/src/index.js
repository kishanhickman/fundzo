import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import ScrollToTop from './actions/scroll-to-top';
import { Provider } from 'react-redux';
import store from './store';

import './index.css';
import App from './App';

ReactDOM.render(
  <Provider store = {store}>
    <BrowserRouter>
      <ScrollToTop />
      <App />
    </BrowserRouter>
  </Provider>,  
  document.getElementById('root')
);

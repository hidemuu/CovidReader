import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Switch } from 'react-router-dom';
import App from './App';
import {IntlProvider} from 'react-intl';
import registerServiceWorker from './registerServiceWorker';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

// 言語設定が日本語ならjaを、それ以外ならenを使う
const language = window.navigator.language.substring(0, 2) === 'ja' ? 'ja' : 'en';

ReactDOM.render(
  <Router basename={baseUrl}>
      <Switch>
        <IntlProvider locale={language}>
          <App />
        </IntlProvider>
      </Switch> 
    </Router>,
    rootElement);

registerServiceWorker();


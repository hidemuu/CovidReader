import React, { Component } from 'react';
import { Route } from 'react-router';

import Layout from './pages/Layout';
import Home from './pages/Home';
import FetchData from './pages/FetchData';
import Counter from './pages/Counter';
import Charts from "./pages/Charts";
import Tables from "./pages/Tables";
import Archives from "./pages/Archives";
import Settings from "./pages/Settings";

//import 'bootstrap/dist/css/bootstrap.css';
//import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path="/charts" component={Charts}></Route>
        <Route path="/tables" component={Tables}></Route>
        <Route path="/archives/:article" component={Archives}></Route>
        <Route path="/settings" component={Settings}></Route>
      </Layout>
    );
  }
}

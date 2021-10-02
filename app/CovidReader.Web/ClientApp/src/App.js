import React, { Component } from 'react';
import { Route } from 'react-router';

import Layout from './pages/Layout';
import Home from './pages/Home';
import Charts from "./pages/Charts";
import Tables from "./pages/Tables";
// import Archives from "./pages/Archives";
import Settings from "./pages/Settings";
import SettingUI from "./pages/SettingUI";
import Dashboard from "./pages/Dashboard";
import SignIn from "./pages/SignIn";
import SignUp from "./pages/SignUp";

export default class App extends Component {
  
  static displayName = App.name;

  //レンダリング
  render () {
    
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path="/signin" component={SignIn}></Route>
        <Route exact path="/signup" component={SignUp}></Route>
        <Route path="/dashboard" component={Dashboard}></Route>
        <Route path="/charts" component={Charts}></Route>
        <Route path="/tables" component={Tables}></Route>
        <Route path="/settings" component={Settings}></Route>
        <Route path="/settingui" component={SettingUI}></Route>
        {/* <Route path="/archives/:article" component={Archives}></Route> */}
        {/* <Route path="/register" component={Register}></Route> */}
        
      </Layout>
    );
  }
}

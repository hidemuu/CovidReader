import React, { Component } from 'react';
import { Route } from 'react-router';

import Layout from './pages/Layout';
import Home from './pages/Home';
import Charts from "./pages/Charts";
import Tables from "./pages/Tables";
import VirusCharts from "./pages/VirusCharts";
import VirusTables from "./pages/VirusTables";
import Archives from "./pages/Archives";
import Settings from "./pages/Settings";
import Content from "./pages/Content";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path="/charts" component={Charts}></Route>
        <Route path="/tables" component={Tables}></Route>
        <Route path="/viruscharts" component={VirusCharts}></Route>
        <Route path="/virustables" component={VirusTables}></Route>
        <Route path="/archives/:article" component={Archives}></Route>
        <Route path="/settings" component={Settings}></Route>
        <Route path="/contents" component={Content}></Route>
      </Layout>
    );
  }
}

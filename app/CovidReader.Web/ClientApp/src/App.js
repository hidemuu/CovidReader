import React, { Component } from 'react';
import { Route } from 'react-router';
import { BrowserRouter as Redirect } from 'react-router-dom';

import Layout from './pages/Layout';
import Home from './pages/Home';
// import Charts from "./pages/Charts";
// import Tables from "./pages/Tables";
// import VirusCharts from "./pages/VirusCharts";
// import VirusTables from "./pages/VirusTables";
import InfectionCharts from "./pages/InfectionCharts";
import InfectionTables from "./pages/InfectionTables";
// import Archives from "./pages/Archives";
// import Settings from "./pages/Settings";
import Register from "./pages/Register";
import Dashboard from "./pages/Dashboard";
import DashboardSummary from "./pages/DashboardSummary";
import SignIn from "./pages/SignIn";
import SignUp from "./pages/SignUp";

export default class App extends Component {
  static displayName = App.name;

  render () {
    // PrivateRouteの実装
    // const PrivateRoute = ({...props}) => {
    //   const authUser = useAuthUser()
    //   const isAuthenticated = authUser != null //認証されているかの判定
    //   if (isAuthenticated) {
    //     return <Route {...props}/>
    //   }else{
    //     console.log(`ログインしていないユーザーは${props.path}へはアクセスできません`)
    //     return <Redirect to="/signin"/>
    //   }
    // }

    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path="/signin" component={SignIn}></Route>
        <Route exact path="/signup" component={SignUp}></Route>
        <Route path="/dashboard" component={Dashboard}></Route>
        <Route path="/dashboardsummary" component={DashboardSummary}></Route>
        {/* <Route path="/charts" component={Charts}></Route>
        <Route path="/tables" component={Tables}></Route>
        <Route path="/viruscharts" component={VirusCharts}></Route>
        <Route path="/virustables" component={VirusTables}></Route> */}
        <Route path="/infectioncharts" component={InfectionCharts}></Route>
        <Route path="/infectiontables" component={InfectionTables}></Route>
        {/* <Route path="/archives/:article" component={Archives}></Route>
        <Route path="/settings" component={Settings}></Route> */}
        <Route path="/register" component={Register}></Route>
        
      </Layout>
    );
  }
}

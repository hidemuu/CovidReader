import * as React from "react";
import { Route } from 'react-router';

import Layout from './pages/Layout';
import Home from './pages/Home';
import Charts from "./pages/charts/Charts";
import Tables from "./pages/tables/Tables";
import Dashboard from "./pages/dashboards/Dashboard";

export default class App extends React.Component<{}> {

    static displayName = App.name;

    render(): JSX.Element {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path="/dashboard" component={Dashboard}></Route>
                <Route path="/charts" component={Charts}></Route>
                <Route path="/tables" component={Tables}></Route>
            </Layout>
        );
    }
}
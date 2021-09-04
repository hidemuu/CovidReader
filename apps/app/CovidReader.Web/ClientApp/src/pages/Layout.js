import React, { Component } from 'react';
import { withRouter } from "react-router-dom";
import { Container } from 'reactstrap';
import Header from "../components/layout/Header";
import Footer from "../components/layout/Footer";
import NavMenu from '../components/layout/NavMenu';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
      const { location } = this.props;
      const containerStyle = {
          marginTop: "60px"
      };
      console.log("layout");
      return (
          <div>
              <NavMenu location={location} />
              <div class="container" style={containerStyle}>
                  <Header />
                  <div class="row">
                      <div class="col-lg-12">
                          {this.props.children}
                      </div>
                  </div>
                  <Footer />
              </div>
          </div>

      );
  }
}

export default withRouter(Layout);

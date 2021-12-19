import React, { Component } from 'react';
import { withRouter } from "react-router-dom";
import Header from "../templates/Header";
import Footer from "../templates/Footer";
import NavMenu from "../templates/NavMenu";

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
      const { location } = this.props;
      const containerStyle = {
          marginTop: "0px"
      };
      console.log("layout");
      return (
          <div>
              <NavMenu location={location} />
              <div className="container" style={containerStyle}>
                  {/* <Header /> */}
                  <div className="row">
                      <div className="col-lg-12">
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
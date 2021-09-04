import React from "react";
import { withRouter } from "react-router-dom";
//import { NavLink, Link, withRouter } from "react-router-dom";
import Header from "../components/layout/Header";
import Footer from "../components/layout/Footer";
import NavMenu from "../components/layout/NavMenu";

//import "react-bootstrap-table-next/dist/react-bootstrap-table2.min.css";

//export default class Layout extends React.Component {
class Layout extends React.Component {
      //navigate() {
        //console.log(this.props.history);
        //this.props.history.push("/");
        //this.props.history.replace("/");
      //}
  render() {
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
          <Footer/>
        </div>
      </div>
      
    );
  }
}

export default withRouter(Layout);
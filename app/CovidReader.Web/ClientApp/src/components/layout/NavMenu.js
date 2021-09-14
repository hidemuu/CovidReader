import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import HomeRoundedIcon from '@material-ui/icons/HomeRounded';
//import './NavMenu.css';

export default class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header class="sticky-top">
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white bg-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/">Covid Reader</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/"><HomeRoundedIcon />Home</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/dashboard">Dashboard</NavLink>
                </NavItem>
                {/* <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/charts">Charts</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/tables">Tables</NavLink>
                </NavItem> */}
                {/* <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/viruscharts">VirusCharts</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/virustables">VirusTables</NavLink>
                </NavItem> */}
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/infectioncharts">InfectionCharts</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/infectiontables">InfectionTables</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/register">Register</NavLink>
                </NavItem>
                {/* <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/archives/news?date=today&filter=none">Archives</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/srttings">Settings</NavLink>
                </NavItem> */}
                
                
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}

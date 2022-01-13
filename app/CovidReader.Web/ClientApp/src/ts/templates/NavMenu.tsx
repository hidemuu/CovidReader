import * as React from "react";
import NavBar from '../components/views/molecules/NavBar';

export default class NavMenu extends React.Component<Model.INavMenuTemplate, {}> {
    static displayName = NavMenu.name;

    constructor(props : Model.INavMenuTemplate) {
        super(props);
        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true,
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.props.collapsed
        });
    }

    render(): JSX.Element {
        let urls = [];
        urls.push({ url: "/", content: "Home" });
        urls.push({ url: "/dashboard", content: "Dashboard" });
        urls.push({ url: "/charts", content: "Charts" });
        urls.push({ url: "/tables", content: "Tables" });
        urls.push({ url: "/settings", content: "Settings" });
        return (<NavBar urls={urls} name="Covid Reader" toggleNavbar={this.toggleNavbar} isCollapsed={!this.props.collapsed} />);
    }
}
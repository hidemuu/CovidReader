import * as React from "react";
import { NavItem, NavLink } from 'reactstrap';
import { Link } from "react-router-dom";

type Props = {
    url: string;
    content: string;
};

export default class NavContent extends React.Component<Props> {

    render(): JSX.Element {
        return (
            <NavItem>
                <NavLink tag={Link} className="text-dark" to={this.props.url}>{this.props.content}</NavLink>
            </NavItem>
        );
    }
}
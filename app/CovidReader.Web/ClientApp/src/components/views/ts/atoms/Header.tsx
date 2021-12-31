import * as React from "react";

type Props = {
    title: string;
};

export default class Header extends React.Component<Props> {

    render(): JSX.Element {
        return (
            <header>
                <div className="row">
                    <div className="col-lg-12">
                        <h1>{this.props.title}</h1>
                    </div>
                </div>
            </header>
        );
    }
}
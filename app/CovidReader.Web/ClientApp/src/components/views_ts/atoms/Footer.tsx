import * as React from "react";

type Props = {
    title: string;
};

export default class Footer extends React.Component<Props> {

    render(): JSX.Element {
        return (
            <footer>
                <div className="row">
                    <div className="col-lg-12">
                        <p>Copyright &copy; {this.props.title}</p>
                    </div>
                </div>
            </footer>
        );
    }
}
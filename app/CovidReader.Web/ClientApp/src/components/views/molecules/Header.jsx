import React from "react";

export default class Header extends React.Component {
    render() {
        const { title } = this.props;
        return (
          <footer>
            <div className="row">
              <div className="col-lg-12">
                  <h1>{ title }</h1>
              </div>
            </div>
          </footer>
        );
  }
}
import React from "react";
import ArchiveTemplate from "../../templates/ArchiveTemplate";

export default class Archives extends React.Component {
  render() {
    return (
          <ArchiveTemplate
              searchLocation={this.props.location.search}
              matchParams={this.props.match.params}
        />      
    );
  }
}
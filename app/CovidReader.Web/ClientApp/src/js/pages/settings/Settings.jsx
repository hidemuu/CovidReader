import React from "react";
import SettingTemplate from "../../templates/SettingTemplate";

export default class Settings extends React.Component {
  render() {
    console.log("settings");
    return (  
      <SettingTemplate title="セッテングページ">
          <h1>Settings</h1>
      </SettingTemplate>
    );
  }
}
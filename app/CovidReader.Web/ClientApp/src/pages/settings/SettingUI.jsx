import React from "react";
import SettingTemplate from "../../templetes/SettingTemplate";

export default class Settings extends React.Component {
  render() {
    console.log("settingUI");
    return (  
      <SettingTemplate title="UIページ">
          <h1>SettingUI</h1>
      </SettingTemplate>
    );
  }
}
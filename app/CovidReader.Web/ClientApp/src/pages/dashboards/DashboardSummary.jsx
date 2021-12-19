import React, { useState } from "react";
import DashboardTemplate from "../../templates/DashboardTemplate";

const DashboardSummary = () => {

  const [dateFilter, setDateFilter] = useState('---');

  //週表示ボタンクリックイベント
  let handleWeeklyButtonClick = () =>　{ 
    setDateFilter('week');
    console.log('clicked weeklybutton');
  };
  //月表示ボタンクリックイベント
  let handleMonthlyButtonClick = () => {
    setDateFilter('month');
    console.log('clicked monthlybutton');
  };
  //年表示ボタンクリックイベント
  let handleYearlyButtonClick = () => {
    setDateFilter('year');
    console.log('clicked yearlybutton');
  };

  return (
    <DashboardTemplate title="サマリーページ">
      <button className="btn btn-primary" onClick={handleWeeklyButtonClick}>週</button>
      <button className="btn btn-primary" onClick={handleMonthlyButtonClick}>月</button>
      <button className="btn btn-primary" onClick={handleYearlyButtonClick}>年</button>
      <p>チャート {dateFilter}</p>
      <p>リスト </p>
    
    </DashboardTemplate>
  );
};

export default DashboardSummary;
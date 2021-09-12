# Corona Virus Reader App

公開されているコロナウイルス感染データを収集し、視点別に集計しグラフ化

# Prerequisites
* 内閣官房 (https://corona.go.jp/dashboard/)
* 厚生労働省 OpenApi (https://portal.opendata.go.jp/)
* NHK (https://www3.nhk.or.jp/news/special/coronavirus/data-widget/)
* 行動解析 (https://it.impress.co.jp/articles/-/20332 https://medicalnote.jp/contents/201014-009-EZ)
* 統計 (https://qiita.com/takahashi_yukou/items/ab60bbba87a06618d81c
        https://qiita.com/dumbbell/items/a801e20fb812ff4dbc83
        https://qiita.com/seki0809/items/f1759c142eedd1ae5b9d)
* MaterialDesignUI (https://material-ui.com/)
* Chart.js (https://qiita.com/HRKN/items/2d11897bc2652efdc7da)
* locationMind (https://locationmind.com/products/xpop/)

# assets

## Covid19 APIスキーマ
* 全国感染状況 (https://opendata.corona.go.jp/api/Covid19JapanAll) -> Covid19JapanAll.json
  - errorInfo
    - errorFlag
    - errorCode
    - errorMessage
  - itemList []
    - date
    - name_jp
    - npatients

* 全国累積死亡者数 (https://opendata.corona.go.jp/api/Covid19JapanNdeaths) -> Covid19JapanNdeaths.json
  - errorInfo
    - errorFlag
    - errorCode
    - errorMessage
  - itemList []
    - date
    - ndeaths

* 世界感染状況 (https://opendata.corona.go.jp/api/OccurrenceStatusOverseas) -> OccurrenceStatusOverseas.json  
  - errorInfo
    - errorFlag
    - errorCode
    - errorMessage
  - itemList []
    - date
    - dataName
    - infectedNum
    - deceasedNum

* 全国医療機関の医療提供体制の状況 (https://opendata.corona.go.jp/api/covid19DailySurvey) -> covid19DailySurvey.json
  - facilityId
  - facilityName
  - zipCode
  - prefName
  - facilityAddr
  - facilityTel
  - latitude
  - longitude
  - submitDate
  - facilityType
  - ansType
  - localGovCode
  - cityName
  - facilityCode

* 日報-感染者数 (https://data.corona.go.jp/converted-json/covid19japan-npatients.json)

* 日報-入院必要者数 (https://data.corona.go.jp/converted-json/covid19japan-ncures.json)

* 日報-死亡者数 (https://data.corona.go.jp/converted-json/covid19japan-ndeaths.json)

* 日報-都道府県別感染者数 (https://data.corona.go.jp/converted-json/covid19japan-all.json)

* 日報-世界感染状況 (https://data.corona.go.jp/converted-json/occurrence_status_overseas.json)

* 全国医療機関の医療提供体制の状況 インフォグラフィックス (https://covid-19-surveillance.s3-ap-northeast-1.amazonaws.com/public_data/covid-19_daily_survey.csv)

* 人流 15時台 (https://data.corona.go.jp/converted-json/reduction_rate_busy_quarter-daytime.json)

  - date
  - dataType
  - dataName
  - comparisonPreDay
  - comparisonPreDeclare
  - comparisonPreSpread

* 人流 21時台（https://data.corona.go.jp/converted-json/reduction_rate_busy_quarter-night.json)

* 全国の人口変動分析 (https://data.corona.go.jp/converted-json/reduction_rate.json)

  - date
  - dataType
  - dataName
  - comparisonPreDay
  - comparisonPreDeclare
  - comparisonPreSpread

* 全国主要観光地における人の流れの推移 (https://data.corona.go.jp/converted-json/reduction_rate_tourist_site.json)

  - date
  - dataType
  - area
  - dataName
  - comparisonPreDay
  - comparisonPreYear

* 高速道路の通過台数の推移 (https://data.corona.go.jp/converted-json/transportation_facilities_road.json)
  - date 
  - providerName 
  - dataType 
  - dataName 
  - all 
  - small 
  - big

## APP APIスキーマ
* Virus


### Quick start 

コンソールアプリ：XAMPPをインストールし、Apache ポートを81にして起動する

#### 環境設定

- ターゲットOS / フレームワーク
  Windows 10
  .Net 5
  .Net framework 4.7.2
  .Net Standard 2.0

- 通信チャネル
  Restful Webサービス
  PostgreSQL データベース

- 通信ポート
  REST API ： 8443
  PostgreSQL : 5432
  XAMPP Apache : 81(localhost)

> *Note* 開発環境：Visual Studio 2019

#### Other

- マイグレーション方法
  https://zenn.dev/kmd_htsh0226/articles/2f49f0978a12cc2d1d5a
  Add-Migration InitialCreate
  Update-Database

- パッケージインストール

  $ cd .\ClientApp\
  $ npm install --save-dev babel-plugin-react-html-attrs
  $ npm install --save react-chartjs-2 chart.js
  $ npm install --save react-bootstrap-table-next
  $ npm install @material-ui/core
  $ npm install @material-ui/icons
  % npm install --save material-table
  $ npm install react-hook-form
  $ npm install elemental --save
  $ npm install node-sass

- webpackコマンド
  $ webpack --mode development

- Visual Studio Codeから実行
  $ dotnet run (.csprojファイルのディレクトリで)
  $ npm run wstart


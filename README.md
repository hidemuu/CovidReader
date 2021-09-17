# Corona Virus Reader App

公開されているコロナウイルス感染データを収集し、視点別に集計しグラフ化

# Prerequisites

# データ構造
CovidReader<br>
| CovidReader.sln<br>
| <br>
├─app<br>
|<br>
|<br>
└─src<br>


# 参照データ
* 内閣官房 (https://corona.go.jp/dashboard/)
* 厚生労働省 OpenApi (https://portal.opendata.go.jp/)
* ジョンズホプキンス大学 (https://github.com/CSSEGISandData/COVID-19/) (https://www.arcgis.com/apps/dashboards/bda7594740fd40299423467b48e9ecf6)
* Covid19API (https://covid19api.com/)

# assets
* Infection

* ViralTest

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




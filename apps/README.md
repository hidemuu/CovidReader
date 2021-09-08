# Corona Virus Reader App



# Prerequisites
* 厚生労働省 (https://corona.go.jp/dashboard/)
* OpenApi (https://portal.opendata.go.jp/)
* NHK (https://www3.nhk.or.jp/news/special/coronavirus/data-widget/)
* 行動解析 (https://it.impress.co.jp/articles/-/20332 https://medicalnote.jp/contents/201014-009-EZ)
* 統計 (https://qiita.com/takahashi_yukou/items/ab60bbba87a06618d81c
        https://qiita.com/dumbbell/items/a801e20fb812ff4dbc83
        https://qiita.com/seki0809/items/f1759c142eedd1ae5b9d)

* Chart.js (https://qiita.com/HRKN/items/2d11897bc2652efdc7da)

# assets



### Quick start 

XAMPPをインストールし、Apache ポートを81にして起動する

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

- リレーションシップ
  https://docs.microsoft.com/ja-jp/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key

- パッケージインストール

  $ cd .\ClientApp\
  $ npm install (念の為)
  $ npm install --save-dev babel-plugin-react-html-attrs
  $ npm install --save react-chartjs-2 chart.js
  $ npm install --save react-bootstrap-table-next
  $ npm install @material-ui/core
  $ npm install @material-ui/icons
  $ npm install react-hook-form
  $ npm install elemental --save

- webpackコマンド
  $ webpack --mode development

- Visual Studio Codeから実行
  $ dotnet run (.csprojファイルのディレクトリで)
  $ npm run wstart
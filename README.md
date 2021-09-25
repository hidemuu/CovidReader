# Covid19 Inspection Data Reader App

一般公開されているコロナウイルス感染データを収集し、視点別に集計しグラフ化

# ソリューション構造
```
CovidReader
| CovidReader.sln  
|
├─app  
|  | CovidReader          : コンソールアプリ
|  |
|  | CovidReader.Web      : Webアプリ（バックエンドASPNETCore / フロントエンドReact）  
|  |   ├─ClientApp        : フロントエンド処理
|  |   └─Controllers      : バックエンド処理
|  |
|  | CovidReader.Windows  : WindowsOS ネイティブアプリ（WPF）
|
├─src  
|  ├─api 
|  |  | CovidReader.Api     : コマンドAPIライブラリ
|  |  | CovidReader.WebApi  : WebAPIライブラリ
|  |
|  ├─controllers
|  |  | CovidReader.Controllers           : 各種アプリケーションコントロール　インターフェイス
|  |  | CovidReader.UseCases              : アプリケーションコントロール　実装ユースケース
|  |  | 
|  |  | CovidReader.Service               : 各種データアクセスサービス　インターフェイス
|  |  | CovidReader.Service.Api           : API関連データアクセスサービス　実装クラス
|  |  | CovidReader.Service.Covid19       : Covid19関連データアクセスサービス　実装クラス
|  |  | 
|  |  | CovidReader.Plugins               : 各種プラグイン　インターフェイス
|  |  | CovidReader.Plugins.Log           : ログプラグイン　実装クラス
|  |  |
|  |  | CovidReader.Utilities             : 共通汎用ロジック
|  |
|  ├─models
|  |  | CovidReader.Models : データモデル
|  |  |   ├─Api
|  |  |   ├─Covid19
|  |  |   |   ├─CS    : 内閣官房提供APIのデータ構造
|  |  |   |   ├─MHLW  : 厚生労働省提供APIのデータ構造
|  |  |   |   └─RESAS : 内閣府地方創生推進室提供APIのデータ構造
|  |  |   |
|  |  |   └─Settings
|  |  |
|  |  | CovidReader.Repository          : リポジトリのインターフェイス
|  |  | CovidReader.Repository.Api      : API関連リポジトリの実装クラス
|  |  |   ├─Csv
|  |  |   ├─InMemory
|  |  |   ├─Json
|  |  |   ├─Rest
|  |  |   └─Sql
|  |  |
|  |  | CovidReader.Repository.Covid19  : Covid19関連リポジトリの実装クラス
|  |  |   ├─CS
|  |  |   ├─MHLW
|  |  |   └─RESAS
|  |  |
|  |  | CovidReader.Repository.Setting  : 初期設定関連リポジトリの実装クラス
|  |      ├─Csv
|  |      ├─Ini
|  |      ├─Json
|  |      └─Xml
|  |
|  └─views  
|     | CovidReader.Infrastructure      : View基盤ライブラリ
|     | CovidReader.Infrastructure.Wpf  : WPF関連のView基盤ライブラリ
|
├─helps
|  | CovidReader.Document : ヘルプドキュメント生成
|
└─builds
   | CovidReader.Setup : インストーラ生成
```

# Web フロントエンドデータ構造
```
ClientApp
| package.json      : パッケージファイル
| webpack.config.js : WebPack設定 
|
├─public
|  | index.html     : 起動html
|  | favicon.ico    : アイコンファイル
|  | manifest.json  :
|  |
|  ├─css
|  └─images
|   
└─src
   | App.js                   : アプリケーション基幹クラス
   | index.js                 : 起動スクリプト
   | registerServiceWorker.js : 
   |
   ├─components
   |  | CommonDialog.js
   |  |
   |  ├─layout
   |  |   | Footer.js   : フッター
   |  |   | Header.js   : ヘッダー
   |  |   | NavMenu.js  : ナビゲーションメニュー
   |  |   
   |  ├─functions
   |  |   | fetchItems.js       :
   |  |   | getChartConfigs.js  :
   |  |   | getItems.js         :
   |  |   | getTableConfigs.js  :
   |  |
   |  ├─models
   |  └─templetes
   |
   └─pages
      | Layut.js            : アプリケーションレイアウト
      | Home.js             : ホーム画面
      | Dashboard.js        : ダッシュボード画面
      | InfectionCharts.js  : 感染データチャート画面
      | InfectionTables.js  : 感染データテーブル画面
      | SignIn.js           : サインイン画面
      | SignUp.js           : サインアップ画面

```

# モデル構造
* Infection

* Inspection

# 命名規則

* 名前空間 : Pascal
* クラス : Pascal
* インターフェイス : Pascal
* 構造体 : Pascal
* 列挙型 : Pascal
* 列挙値 : Pascal
* イベント : Pascal
* メソッド : Pascal
* プロパティ : Pascal
* 定数 : すべて大文字
* Publicフィールド : Camel
* Privateフィールド : 先頭にアンダースコア(_) + Camel
* 引数（パラメータ） : Camel
* ローカル変数 : Camel

# APIスキーマ


# 参照データ
* 内閣官房 (https://corona.go.jp/dashboard/)
* 厚生労働省 OpenApi (https://portal.opendata.go.jp/) ※2021/9/30で公開終了
* V-RESAS (https://v-resas.go.jp/)
* ジョンズホプキンス大学 (https://github.com/CSSEGISandData/COVID-19/) (https://www.arcgis.com/apps/dashboards/bda7594740fd40299423467b48e9ecf6)
* Covid19API (https://covid19api.com/)

### Quick start 

コンソールアプリ  ：XAMPPをインストールし、Apache ポートを81にして起動する
Webアプリ      　：Kestralをインストールし、dotnetコマンドで起動する

#### 環境設定

- ターゲットOS / フレームワーク
  Windows 10
  .Net 5 (アプリケーション)
  .Net Standard 2.0 (ライブラリ)

- 通信チャネル
  Restful Webサービス
  PostgreSQL データベース

- 通信ポート
  REST API ： 8443
  PostgreSQL : 5432
  XAMPP Apache : 81(localhost)

> *Note* 開発環境：Visual Studio 2019




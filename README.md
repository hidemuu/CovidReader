# Covid19 Inspection Data Reader App

一般公開されているコロナウイルス感染データを収集し、視点別に集計しグラフ化

# ソリューション構造
CovidReader<br>
| CovidReader.sln<br>  
|<br>
├─app<br>  
|  | CovidReader          : コンソールアプリ<br>    
|  | CovidReader.Web      : Webアプリ（バックエンドASPNETCore / フロントエンドReact）<br>  
|  | CovidReader.Windows  : WindowsOS ネイティブアプリ（WPF）<br>  
|<br>
├─src<br>  
|  ├─api<br> 
|  |  | CovidReader.Api     : コマンド型APIライブラリ<br>
|  |  | CovidReader.WebApi  : WebAPIライブラリ<br>
|  |<br>
|  ├─controllers<br>
|  |  | CovidReader.Controllers           : 各種アプリケーションコントロール　インターフェイス<br>
|  |  | CovidReader.Controllers.UseCases  : アプリケーションコントロール　実装ユースケース<br>
|  |  | <br>
|  |  | CovidReader.Service               : 各種データアクセスサービス　インターフェイス<br>
|  |  | CovidReader.Service.Api           : API関連データアクセスサービス　実装クラス<br>
|  |  | CovidReader.Service.Covid19       : Covid19関連データアクセスサービス　実装クラス<br>
|  |  | <br>
|  |  | CovidReader.Plugins               : 各種プラグイン　インターフェイス<br>
|  |  | CovidReader.Plugins.Log           : ログプラグイン　実装クラス<br>
|  |<br>
|  ├─models<br>
|  |  | CovidReader.Models : データモデル<br>
|  |  |   ├─Api<br>
|  |  |   ├─Covid19<br>
|  |  |   |   ├─CS    : 内閣官房提供APIのデータ構造<br>
|  |  |   |   ├─MHLW  : 厚生労働省提供APIのデータ構造<br>
|  |  |   |   ├─RESAS : 内閣府地方創生推進室提供APIのデータ構造<br>
|  |  |   |<br>
|  |  |   ├─Settings<br>
|  |  |<br>
|  |  | CovidReader.Repository          : リポジトリのインターフェイス<br>
|  |  | CovidReader.Repository.Api      : API関連リポジトリの実装クラス<br>
|  |  |   ├─Csv<br>
|  |  |   ├─InMemory<br>
|  |  |   ├─Json<br>
|  |  |   ├─Rest<br>
|  |  |   ├─Sql<br>
|  |  |<br>
|  |  | CovidReader.Repository.Covid19  : Covid19関連リポジトリの実装クラス<br>
|  |  |   ├─CS<br>
|  |  |   ├─MHLW<br>
|  |  |   ├─RESAS<br>
|  |  |<br>
|  |  | CovidReader.Repository.Setting  : 初期設定関連リポジトリの実装クラス<br>
|  |      ├─Csv<br>
|  |      ├─Ini<br>
|  |      ├─Json<br>
|  |      ├─Xml<br>
|  |<br>
|  └─views<br>  
|     | CovidReader.Infrastructure      : View基盤ライブラリ<br>
|     | CovidReader.Infrastructure.Wpf  : WPF関連のView基盤ライブラリ<br>
|<br>
├─helps<br>
|  | CovidReader.Document : ヘルプドキュメント生成<br>
|<br>
└─builds<br>
   | CovidReader.Setup : インストーラ生成<br>

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




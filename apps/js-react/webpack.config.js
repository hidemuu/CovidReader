var debug   = process.env.NODE_ENV !== "production";
var webpack = require('webpack');
var path    = require('path');
const outputPath = path.resolve(__dirname, 'public');

module.exports = {
  mode: 'development',
  context: path.join(__dirname, "src"),
  //devtool: debug ? "inline-sourcemap" : false,
  entry: "./js/client.js",
  module: {
    rules: [{
      test: /\.js[x]?$/,
      exclude: /node_modules/,
      use: [{
        loader: 'babel-loader',
        options: {
          presets: [
            '@babel/preset-env',
            '@babel/preset-react' //ReactのPresetを追加
          ],
          plugins: ['@babel/plugin-syntax-jsx'] //JSXパース用
        }
      }]
    }]
  },
  resolve: {
    extensions: ['.js', '.jsx', '.json']  // .jsxも省略可能対象にする
  },
  output: {
    path: outputPath,
    filename: "client.min.js",
    publicPath: '/'
  },
  devServer: {
    //contentBase: outputPath,
    open: true,
    historyApiFallback: true
  },
  plugins: debug ? [] : [
    /* Search for equal or similar files and deduplicate them in the output. */
    // new webpack.optimize.DedupePlugin(), /* It has been removed since Webpack 2 */
    /* Assign the module nad chunk ids by occurrence count.
       Ids that are used often get lower (shorter) ids.
       This make ids predictable reduces total file size and is recommended. */
    //new webpack.optimize.OccurrenceOrderPlugin(),
    /* UglifyJS Webpack Plugin */
    //new webpack.optimize.UglifyJsPlugin({ mangle: false, sourcemap: false }),
  ],
};

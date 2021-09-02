var path    = require('path');
const outputPath = path.resolve(__dirname, 'public');

module.exports = {
  devtool: 'source-map',
  context: path.join(__dirname, "src"),
  entry: './index.js',
  mode: 'development',
  output: {
    path: outputPath,
    filename: 'index.min.js'
  },
  resolve: {
      extensions: ['.webpack.js', '.web.js', '.ts', '.js', '.jsx', '.tsx']
  },
  module: {
      rules: [
          {
              test: /\.js[x]?$/,
              exclude: /(node_modules|bower_components)/,
              use: {
                  loader: 'babel-loader',
                  options: {
                    presets: [
                      '@babel/preset-env',
                      '@babel/preset-react' //ReactのPresetを追加
                    ],
                    plugins: [
                      'react-html-attrs',
                      '@babel/plugin-syntax-jsx'
                    ] //JSXパース用
                  }
              }
          }
      ]
  }
}
const { resolve } = require('path')
const webpack = require('webpack')
const HtmlWebpackPlugin = require('html-webpack-plugin')

module.exports = {
  context: resolve(__dirname, 'MailNet', 'Web'),

  entry: [
    './App/index'
  ],

  output: {
    path: resolve(__dirname, 'MailNet', 'bin', 'Debug', 'Web', 'Content', 'Dist'),
    filename: 'bundle.js',
    publicPath: '/content/dist'
  },

  devtool: 'inline-source-map',

  module: {
    rules: [{
      test: /\.js$/,
      use: ['babel-loader'],
      exclude: /node_modules/,
    },{
      test: /\.css$/,
      use: ['style-loader', 'css-loader?modules', 'postcss-loader'],
    },{
      test: /\.(ico|jpg|jpeg|png|gif|eot|otf|webp|svg|ttf|woff|woff2)(\?.*)?$/,
      use: ['file-loader'],
      options: {
        name: 'images/[name].[hash:8].[ext]'
      },
    }]
  },

  plugins: [
    new webpack.NamedModulesPlugin(),
    // prints more readable module names in the browser console on HMR updates

    new webpack.NoErrorsPlugin(),
    // displays error messages in the browser

    new HtmlWebpackPlugin({
      filename: '../../../Web/Views/Home/index.html',
      template: 'App/index.html',
      inject: true
    }),

    new webpack.ProvidePlugin({
      '$': 'jquery',
      'jQuery': 'jquery',
      'window.jQuery': 'jquery'
    })
  ]
}

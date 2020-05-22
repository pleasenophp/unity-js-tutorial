const path = require('path');

module.exports = env => {
  return {
    entry: {
        app: './index.js'
    },
    module: {
        rules: [
          { test: /\.js$/, loader: 'babel-loader' }
        ]
    },
    output: {
      filename: 'app.js',
      path: path.resolve(__dirname, '../Assets/Resources')
    },
    optimization: {
        minimize: env != 'dev'
    }
  };
};

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
    optimization: {
        minimize: env != 'dev'
    }
  };
};


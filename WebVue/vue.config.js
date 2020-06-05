module.exports = {
  // vue的配置
  devServer: {
    // 针对开发服务器的配置
    proxy: {
      "/api": {
        // 当请求路径以 /api 开头时，开发服务器需要代理到 http://localhost:5000
        // /api/user/login  --->   http://localhost:5000/api/user/login
        target: "http://localhost:5000",
      },
    },
  },
};

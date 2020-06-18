import Vue from "vue";
import App from "./App.vue";
//icon
import Antd from 'ant-design-vue';
import 'ant-design-vue/dist/antd.css';
Vue.config.productionTip = false;

import "./assets/style/reset.css";
import "./assets/style/global.css";
import router from "./routes";
import store from "./store";
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import GoEasy from 'goeasy';
// 频道数据一开始就需要获取
store.dispatch("channels/fetchDatas");
store.dispatch("loginUser/whoAmI");

Vue.use(ElementUI);
//icon
Vue.use(Antd);

//创建全局GoEasy对象
Vue.prototype.$goEasy = new GoEasy({
  host:'hangzhou.goeasy.io', //应用所在的区域地址: 【hangzhou.goeasy.io |singapore.goeasy.io】
  appkey: "BC-60cedca440c44adca499dc824d536afc", //替换为您的应用appkey
  onConnected: function() {
      console.log('连接成功！')
  },
  onDisconnected: function() {
      console.log('连接断开！')
  },
  onConnectFailed: function(error) {
      console.log('连接失败或错误！')
  }
});

new Vue({
  render: (h) => h(App),
  router,
  store,
  
}).$mount("#app");

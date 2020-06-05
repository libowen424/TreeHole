// 登录用户 的仓库数据
import { login, loginOut, whoAmI } from "../services/userService";
export default {
  namespaced: true, // 开启命名空间
  state: {
    data: null, // 当前登录的用户
    isLoading: false, // 是否正在远程加载中
  },

  mutations: {
    setIsLoading(state, payload) {
      state.isLoading = payload;
    },
    setData(state, payload) {
      state.data = payload;
    },
  },
  //登录 我是谁 注销
  actions: {
    async login(context, payload) {
      context.commit("setIsLoading", true);
      var resp = await login(payload); // null或者一个user对象
      var result = false;
      //根据返回值
      if (resp!=null) {
        // 登录成功
        context.commit("setData", resp);
        result = true;
      }
      context.commit("setIsLoading", false);
      return result;
    },

    //获取数据赋给当前用户
    async whoAmI(context) {
      context.commit("setIsLoading", true);
      var resp = await whoAmI();
      context.commit("setData", resp);
      context.commit("setIsLoading", false);
    },
    
    loginOut(context) {
      loginOut();
      context.commit("setData", null);
    },
  },
};

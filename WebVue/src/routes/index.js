import VueRouter from "vue-router";
import Vue from "vue";
import config from "./config"

//1. 安装
Vue.use(VueRouter);

//2. 创建路由对象
var router = new VueRouter(config);

//在进入每一个路由之前会触发这个函数 
//to要进入的 from从哪来
//next是函数，可以通过该函数跳转到指定路由 调用next才允许跳转
//其他页面无所谓，但对于受保护的页面要进行判断
// router.beforeEach(function(to,from,next){
// //需要登录后才能访问
//     if(to.meta.auth)
// {

// }
// else{
//     //可以随意访问
//     next();
// }
// });

export default router;

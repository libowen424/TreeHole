export default {
  routes: [
    {
      path: "/chat",
      name: "Chat",
      component: () => import("@/views/Chat"),
    },
    {
      path: "/match",
      name: "Match",
      component: () => import("@/views/Match"),
    },
    {
      path: "/post",
      name: "Post",
      component: () => import("@/views/Post"),
    },
    {
      path: "/personal",
      name:"Personal",
      component:()=>import("@/views/Personal"),
      // meta:{
      //   auth:true,
      // }
    },
    {
      path: "/",
      name: "Home",
      component: () => import("@/views/Home"),
    },
    {
      path: "/login",
      name: "Login",
      component: () => import("@/views/Login"),
    },
    {
      path: "/reg",
      name: "Reg",
      component: () => import("@/views/Reg"),
    },
    {
      path: "/channel/:id",
      name: "ChannelNews",
      component: () => import("@/views/ChannelNews"),
    },
    {
      path: "/comment/:id",
      name: "Comment",
      component: () => import("@/views/Comment"),
    },
    {
      path: "*", //匹配所有路径
      name: "404",
      component: () => import("@/views/NotFound"),
    },
  ],
  mode: "history",
};

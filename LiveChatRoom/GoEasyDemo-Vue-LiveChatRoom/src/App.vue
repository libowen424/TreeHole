<template>
  <div id="app">
    <Login @loginRoom="loginRoom" v-if="showLogin" />
    <ChatRoom v-else :roomToken="roomToken" @quitRoom="showLogin = true" />
  </div>
</template>

<script>

  import Login from "./components/Login";
  import ChatRoom from "./components/ChatRoom";
  export default {
    name: 'App',
    data () {
      return {
        roomToken : null,
        showLogin : true
      }
    },
    components: {
      Login,
      ChatRoom
    },
    methods : {
      loginRoom (roomToken) {
        this.showLogin = false;
        this.roomToken = roomToken;
      }
    }
  }
</script>

<style>
  *{
    margin: 0;
    padding: 0;
    box-sizing: border-box;
  }
  html,body{
    width: 100%;
    height: 100%;
    margin: 0;
    padding: 0;
  }
  #app {
    width: 3.75rem;
    height: 100%;
    margin: auto;
  }
</style>

<template>
  <div class="login-container">
    <div class="header">
      <span class="title">欢迎来到吐槽聊天室</span>
    </div>
    <div class="content">
      
      <!--
      <input :class='nickname == "" ? "input-notice nick-input" : "nick-input"'
             :value="nickname"
             placeholder="请输入您在直播间中的名字"
             @input="onInputUserName">
      <div class="avatar-container">

        <div class="avatar-notice">
          <span>请选择头像</span>
          <span class="avatar-notice-info" v-if="selectedAvatar.imgUrl ==''">请选一个头像哦!!!</span>
        </div>

        <div class="avatar-box">
          <div
          :class="selectedAvatar.id == avatar.id ? 'avatar-box-item active' : 'avatar-box-item'"
          v-for="(avatar, key) in avatarList"
          :key="key"
          @click="onSelectAvatar(avatar)">
            <img :src="avatar.imgUrl" />
          </div>
        </div>
      -->

      </div>
      <div class="room-container">
        <span class="room-title">请选择聊天室</span>
        <div class="room-box">
          <span
          class="room-box-item"
          v-for="room in roomList"
          :key="room.roomId"
          @click="onSelectRoom(room)">{{room.name}}
          </span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        avatarList: [
          {id: '1', imgUrl:require( '../assets/images/author.png')},
          {id: '2', imgUrl:require( '../assets/images/2.png')},
          {id: '3', imgUrl:require( '../assets/images/3.png')},
          {id: '4', imgUrl:require( '../assets/images/4.png')},
          {id: '5', imgUrl:require( '../assets/images/5.png')},
          {id: '6', imgUrl:require( '../assets/images/6.png')},
          {id: '7', imgUrl:require( '../assets/images/7.png')},
          {id: '8', imgUrl:require( '../assets/images/8.png')}
        ],
        roomList: [
          {roomId: "001", name: "女朋友太难哄"},
          {roomId: "002", name: "疫情在家好无聊"},
          {roomId: "003", name: "GNR加油"},
          {roomId: "004", name: "交个朋友吧"},
     

        ],
        nickname: '李',
        selectedAvatar: {
          imgUrl:'../assets/images/author.png',
          id: '1'
        },
        selectedRoom: {
          roomId: null,
          roomName: '',
        }

      }
    },
    beforeMount() {
      Object.assign(this.$data, this.$options.data());
    },
    methods: {
      GetRequest() {
             var url = location.search; //获取url中"?"符后的字串
             var theRequest = new Object();
             if (url.indexOf("?") != -1) {
                 var str = url.substr(1);
                 var strs = str.split("&");
                 for(var i = 0; i < strs.length; i ++) {
                     theRequest[strs[i].split("=")[0]]=unescape(strs[i].split("=")[1]);
                 }
             }
             return theRequest;
         },
      onInputUserName(event) {// 输入用户名
        this.nickname = event.target.value;
      },
      onSelectAvatar(avtar) {//选择头像
        this.selectedAvatar = avtar;
      },
      onSelectRoom(room) {//登录
        if (this.selectedAvatar.imgUrl != "" && this.nickname != "") {
          this.roomToken = {
            roomId: room.roomId,
            roomName: room.name,
            userId: (Math.random() * 1000).toString(),
            nickname: this.nickname,
            avatar: this.selectedAvatar.imgUrl
          };
          this.$emit("loginRoom", this.roomToken);
        }
      }
    }
  }
</script>

<style scoped>
  .login-container{
    padding:0.34rem 0.36rem 0 0.36rem;
  }
  .header {
    font-size: 0.26rem;
    line-height: 0.33rem;
    text-align: center;
    display: flex;
    flex-direction: column;
    font-family: Microsoft YaHei UI;
  }
  .title {
    color: #D02129;
    font-weight: bold;
  }

  .content {
    display: flex;
    justify-content: center;
    flex-direction: column;
  }

  .nick-input {
    height: 0.42rem;
    border: 0.02rem solid rgba(0, 0, 0, 0.1);
    outline: none;
    border-radius: 2rem;
    padding: 0.16rem 0.3rem;
    box-sizing: border-box;
    font-size: 0.15rem;
    text-align: center;
    margin: 0.3rem 0;
  }

  .avatar-container {
  }

  .avatar-notice {
    line-height: 0.28rem;
    font-size: 0.14rem;
  }

  .avatar-notice-info {
    color: #D02129;
  }

  .avatar-box {
    height: 1.5rem;
    display: flex;
    flex-wrap: wrap;
  }

  .avatar-box-item {
    height: 0.67rem;
    width: 0.67rem;
    margin: 0.04rem;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .avatar-box-item img {
    height: 0.62rem;
    width: 0.62rem;
    background-color: #F0AD4E;
    border-radius: 0.62rem;
  }

  .avatar-box .active {
    border: 0.04rem solid red;
    box-sizing: border-box;
    border-radius: 0.62rem;
  }

  .avatar-box .active img {
    border: 0.04rem solid #fff;
    box-sizing: border-box;
  }

  .room-container {
    height:1.65rem;
    display: flex;
    flex-direction: column;
    margin-bottom: 0.1rem;
  }

  .room-title {
    font-size: 0.15rem;
    line-height: 0.55rem;
    height: 0.55rem;
  }

  .room-box {
    display: flex;
    flex-wrap: wrap;
    flex-grow: 1;
    justify-content: space-between;
    align-content: space-between;
  }

  .room-box-item {
    width: 1.44rem;
    height: 0.45rem;
    line-height: 0.45rem;
    text-align: center;
    background-color: #D02129;
    border-radius: 0.5rem;
    color: #fff;
    font-size: 0.12rem;
  }
  .input-notice {
    border: 0.01rem solid #D02129;
  }

</style>

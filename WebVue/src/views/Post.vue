<template>
<div>
<div>
  <h1>
      POst
      {{this.$route.params.channelname}}
      {{this.$route.params.channelid}}
  </h1>
</div>
  <div class="main">
    <div>
        <el-input
        placeholder="请输入内容"
        v-model="channelName"
        :disabled="true" style="font-size:20px">
        </el-input>
    </div>
    <div class="title">
        <img src="../assets\ico.jpg" height="15" width="15">
        发表话题
    </div>
        <div class="inputBox">
        <input style="width:920px;height:80px" v-model="topicname" placeholder="请输入话题名">
        </div>
    <div class="inputBox">
        <input style="width:920px;height:250px" v-model="topicdes" placeholder="请输入话题描述"> 
    </div>
    <div class="button">
        <button @click="addtopic">发表</button>
    </div>
</div>
</div>
</template>

<script>
import {postTopic} from "../services/newsService"
export default {
    methods:{
        addtopic()
        {
            if(this.$store.state.loginUser.data==null){
                  this.$message.error('请先登录');
            }
            else{
        this.topicadd.channelId=this.$route.params.channelid;
        this.topicadd.channelname=this.$route.params.channelname;
        this.topicadd.topicName=this.topicname;
        this.topicadd.describe=this.topicdes;
        this.topicadd.publisher=this.$store.state.loginUser.data.nickname;
        postTopic(this.topicadd);
        this.topicname="";
        this.topicdes="";
            }
        }
    },
data(){
    return{
        topicname:"",
        topicdes:"",
        topicadd:{
            channelId:0,
            channelname:"",
            topicName:"",
            describe:"",
            publisher:"",
        },
    }
},
computed:
{
    channelName(){
        var str = "【"+this.$route.params.channelname+"】";
        return str;
    }
}
}
</script>

<style>
.title{
    margin-top: 10px;
    margin-left: 10px;
}
.main{
    margin-top: 100px;
    border:1px solid rgb(38, 46, 48);
        width: 980px;

}
.inputBox{
    margin-top: 20px;
    margin-left: 20px;
}
.button{
    margin-top: 30px;
    margin-left: 10px;
    margin-bottom: 20px;
}
</style>
<template>
<div class="main">
    <div class="title">
        <img src="../assets\ico.jpg" height="15" width="15">
        发表回复
    </div>
    <div class="inputBox">
        <input style="width:920px;height:250px" v-model="text">
    </div>
    <div class="button">
        <button @click="addReply">发表</button>
    </div>
</div>
</template>

<script>
import {postReply} from "../services/replyService"
export default {
    props:{
        topicId:{
            default:null,
        }
    },
data(){
        return{
            text:"",
    replyadd:{
        content:"",
        topicId:0,
        author:"",
    },
}
},
methods:{
    addReply()
    {
    this.replyadd.content=this.text;
    this.replyadd.topicId=this.topicId;
    this.replyadd.author=this.$store.state.loginUser.data.nickname;
            postReply(this.replyadd);
                this.text="";
                        this.$emit("replyadded");
    }
},
}
</script>

<style>
.title{
    margin-left: 10px;
}
.main{
    margin-top: 100px;
    border:1px solid rgb(38, 46, 48);
        width: 980px;

}
.inputBox{
    margin-top: 30px;
    margin-left: 20px;
}
.button{
    margin-top: 30px;
    margin-left: 10px;
    margin-bottom: 20px;
}
</style>
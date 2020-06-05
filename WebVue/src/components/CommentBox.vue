<template>
<div class="content">

    <div class="author">
        <ul class="=p_author">
            <li><img src="../assets\author.png" height="100" width="100"></li>
            <li>{{author}}</li>  
        </ul>
    </div> 

    <div class="content_main">
    {{content}}
    </div> 
<div class="contentToreply">
    <div 
    class="reply"
    v-for="item in subreplies"
    :key="item.id">
        <div class="reply_content"><a>{{item.pubName}}</a>: 回复 <a>{{item.repName}}</a>: {{item.content}}
        <button  style="background-color: #FFFFFF ;color: #387cdf; border:1px solid #387cdf;" 
         class="button1" @click="showAddsub(item.pubName)">
         {{
      isReplying ? "收起回复" : "回复"
        }}
    </button>
        </div>
    </div>

    <div v-show="isReplying">
        <div class="input">
        <input  style="width:750px;height:80px" v-model="text"> 
        </div>
        <div >
    <button style="background-color: #FFFFFF ;color: #387cdf; border:1px solid #387cdf;" 
    class="button2" @click="addSubreply">回复</button>
        </div>
    </div>
</div>
</div>
</template>

<script>
import {getSubreplies} from "../services/replyService"
import {postSubreply} from "../services/replyService"
export default {
    data(){
        return{
    subreplyadd:{
        pubName:"",
        repName:"",
        content:"",
        replyId:0,
    },
    text:"",
    isReplying:false,//是否出现添加评论的输入框

     subreplies:[],
        };
    },
    //需要传进来待展示的数据
    //replies是主回复
props:{
    replyId:{
        default:null,
    },
   content:{
       default:"",
       type:String,
   },
   author:{
       default:"",
       type:String,
   },
   topicId:{
       default:null,
   }
},
methods:{
    showAddsub(repname)
    {
this.isReplying = !this.isReplying;
this.subreplyadd.repName=repname;
    },
    addSubreply()
    {
    this.isReplying = !this.isReplying;
    //添加副回复
    this.subreplyadd.content=this.text;
    this.subreplyadd.pubName=this.$store.state.loginUser.data.nickname;
    this.subreplyadd.replyId=this.replyId;
    postSubreply(this.subreplyadd);
    this.text="";
    this.setDatas();
    },
async setDatas()
{
    getSubreplies(this.replyId).then
    ((resp) =>
    {
        this.subreplies=resp.data;
    })
//   var resp =await getSubreplies(this.replyId);
//       console.log(resp.data);
//   return resp.data;
}
},
created: function (){
//    this.subreplies=this.setDatas();
//    console.log(this.subreplies);
this.setDatas();
}
};
</script>

<style scoped>
.content {
    width: 980px;
    min-height:300px;
    border:1px solid rgb(38, 46, 48);
    margin-bottom: 10px;
}
.author {
    width: 130px;
    float: left;
    text-align: center;
    padding: 15px 0;
}
.content_main {
    position: relative;
    float: left;
    width: 800px;
    padding: 0 0 8px 20px;
    background: #fff;
    margin-top:20px;
}
.contentToreply{
    margin-top: 100px;
    margin-bottom: 50px;
}
.reply {
    background: #f7f8fa;
    border: 1px solid #f0f1f2;
    width: 700px;
    border: 1px solid  #fff;
    margin-left: 170px;
    min-height: 0;
    padding: 4px 15px 14px;
}
.reply_content {
    margin-top: 15px;
}
.button{
    margin-right: 20px;
     float: right;
         float: bottom;

     height: 30px;
     width: 150px;
}
.button1{
    float: right;
    float: bottom;
    text-align: center;
    width: 80px;
    height: 30px;
}
.input{
    margin-top: 30px;
     margin-left: 170px;
}
.button2{
  float: right;
     width: 50px;
    height: 30px;
    margin-right: 70px;
}
</style>
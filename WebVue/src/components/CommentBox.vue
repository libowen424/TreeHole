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

    <div class="rightbottom">
     <button  style="background-color: #FFFFFF ;color: #387cdf; " 
            class="button1"  @click="showSub()">
            {{
        isReplying ? "收起回复" : "回复"
            }}
        </button>
    </div>
    

    <div class="replyBOx" v-show="isReplying">

            <div 
        class="reply"
        v-for="item in subreplies"
        :key="item.id">
            <div class="reply_content">
                <a>{{item.pubName}}</a>: 回复 <a>{{item.repName}}</a>: {{item.content}}
                <button style="background-color: #FFFFFF ;color: #387cdf;   " 
            class="button1" @click="showSub1(item.pubName)">
        回复
        </button>
            </div>

     

        </div>

        <div class="input">
        <input  style="width:750px;height:80px" v-model="text"> 
        </div>
        <div >
    <button style="background-color: #FFFFFF ;color: #387cdf; " 
    class="button2" @click="addSubreply">发表</button>
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
    showSub1(pubName){
        this.text="@"+this.author+":";
    },
    showSub(repname)
    {
this.isReplying = !this.isReplying;
this.text="@"+this.author+":";
    },
    addSubreply()
    {
           if(this.$store.state.loginUser.data==null){
                  this.$message.error('请先登录');
            }
            else{
    //添加副回复
    var strlist = this.text.split(":");
    this.subreplyadd.content=strlist[1];
    this.subreplyadd.pubName=this.$store.state.loginUser.data.nickname;
    this.subreplyadd.repName=strlist[0].substring(1);
    this.subreplyadd.replyId=this.replyId;
    this.text="@"+this.author+":";
    if( postSubreply(this.subreplyadd)){
            this.setDatas();
    }
            }
    },
async setDatas()
{
    getSubreplies(this.replyId).then
    ((resp) =>
    {
        this.subreplies=resp.data;
    })
    console.log("重新获取副回复数据");
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

.replyBOx{
    margin-top: 300px;
    margin-bottom: 50px;
}
.rightbottom{
position: absolute; 
left:890px ; top:250px; 
}
.content {
    position:relative;
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
    min-height: 280px;
    margin-top: 100px;
    margin-bottom: 10px;
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
        position:relative;
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
    text-align: center;
    width: 80px;
    height: 20px;
    position: absolute; 
right:20px ; bottom:0px; 
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
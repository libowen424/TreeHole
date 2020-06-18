<template>
<div>
<div v-for="item in replies" :key="item.id">
    <!--加了:是js代码，双引号里的内容是变量不是字符串 不加是字符串-->
  <CommentBox :content="item.content" :author="item.author" :replyId="item.id" :topicId="item.topicId" />
  
</div>
  <PostBox @replyadded="setDatas()" :topicId=this.$route.params.id />
</div>
</template>

<script>
import CommentBox from "../components/CommentBox";
import {getReplies} from "../services/replyService";
import PostBox from "../components/PostBox";
export default {
components:{
    CommentBox,
    PostBox,
},
data(){
    return{
        replies:[],
      //subreplies:[{id:1,PubName:"李",RepName:"王",Content:"当前是否为折叠状态当前是否为折叠状态"},{id:2,PubName:"王",RepName:"李",Content:"当前是否为折叠状态当前是否为折叠状态"}]
        }
},
// computed:{
//     subreplies:function(replyId)
//     {
//         return function()
//         {
//             console.log(replyId);
//         var resp = getSubreplies(replyId);
//         return resp.data;
//         }
//     }
// },
methods:{
async setDatas(){
    var resp = await getReplies(this.$route.params.id);
    this.replies = resp.data;
    console.log("获取主回复数据")
}
},
watch:{
    "$route.params.id":{
        immediate:true,
        handler(){
            this.setDatas();
        },
    },
},
};
</script>

<style>

</style>
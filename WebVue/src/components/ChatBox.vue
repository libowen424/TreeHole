<template>
        <div class="container">

                <div class="message-content">
                    <div class="message-text" v-for="(message, key) in messages" :key="key">{{message}}</div>
                </div>

               <div class="send">
                <input style="width:600px"  class="send-box" v-model="content"/>
                <el-button type="text" @click="sendMessage" class="send-button">发送</el-button>
                </div>

        </div>
</template>

<script>
import {postMessage} from "../services/messageService"
import {getMessage} from "../services/messageService"
export default {
    data(){
        return{
                currentChannel:"",
                 messages: [],
                content: "",
                beforemessages:[],
        }
    },
props:{
    target:"",
    targetId:{
        default:()=>0,
    }
},
        created:function()
        {
                this.getmessage();      
        },
      beforeMount() {
            let self = this;

             this.$goEasy.subscribe({
                 //这里不知道为什么写下面的不行  都是21 先暂时不管了
                 //this.currentChannel
                channel: 21,
                onMessage: function (message) {
                self.messages.push(message.content);
                    console.log("Channel:" + message.channel + " content:" + message.content);
                },
                onSuccess: function () {
                    self.unshiftMessage('订阅成功.');
                }
            });
        },
methods: {
            async getmessage()
            {
                 var resp = await getMessage(this.$store.state.loginUser.data.id,this.targetId);
                 console.log(resp.data);
                 if(resp.data.length == 0)
                 {
                     this.currentChannel=String(this.targetId)+String(this.$store.state.loginUser.data.id);
                            console.log("这里拼接");
                            console.log(this.currentChannel);
                 }
                 else
                 {
                     this.currentChannel=resp.data[0].channel;
                            console.log("这里获取");
                            console.log(this.currentChannel);
                 }
                 for(var i =0 ;i<resp.data.length;i++)
            {
                this.messages.push(resp.data[i].content);

            };
            console.log(this.messages);
            },

            unshiftMessage(content) {
                let formattedTime = new Date().formatDate("hh:mm");
                let message = formattedTime + " " + this.$store.state.loginUser.data.nickname + " : "+ content;
                this.messages.push(message);
                console.log("push成功");
            },
            shiftMessage(content)
            {
                let formattedTime = new Date().formatDate("hh:mm");
                console.log(this.$store.state.loginUser.data.nickName)
                let message = formattedTime + " " + this.$store.state.loginUser.data.nickname +  " : " + content;
                return message;
            },
            sendMessage: function () {//发送消息
                let self = this;
                postMessage(
                    {
                        userId1:this.$store.state.loginUser.data.id,
                        userId2:this.targetId,
                        content:this.shiftMessage(this.content),
                        channel:this.currentChannel,
                    }
                );
                if (this.content.trim() != '') {
                     this.$goEasy.publish({
                        channel: this.currentChannel,
                        message: this.shiftMessage(this.content),
                        onSuccess: function () {
                            self.content = "";
                            console.log("send message success");
                        },
                        onFailed: function (error) {
                            self.unshiftMessage('发送失败，请检查您的appkey和host配置.');
                        }
                    });
                }
            }
} 

}
</script>

<style scoped>
    .container{
        margin-top: 10px;
        width: 800px;
        min-height:400px;
        border:1px solid rgb(38, 46, 48);
    }
    .message-content{
            border:1px solid rgb(38, 46, 48);
            width: 800px;
            min-height:350px;

    }
    .send{
            position:relative;
    }
    .send-box{
        margin-top: 5px;
        margin-left: 5px;
    }
    .send-button
    {
                margin-top: 5px;
        position: absolute; 
        right:10px ; 
    }
   
</style>
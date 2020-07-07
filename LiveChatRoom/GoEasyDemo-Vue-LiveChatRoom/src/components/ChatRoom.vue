<template>
    <div class="chat-room">
        <div class="header">
            {{room.name}}
            <span class="quit-btn" @click="quitRoom">X</span>
        </div>
        <div class="online-avatar-container">
            <div class="online-avatar-item" v-for="(user, key) in room.onlineUsers.users"
                 :key="key"
                 :style="realignAvatar(key)">
                <img :src="user.avatar" />
            </div>
            <div class="online-count">{{room.onlineUsers.count}}</div>
        </div>
        <div class="chat-room-container">
            <div class="chat-room-content" ref="myscroll">
                <div class="message-box" v-for="(message, key) in room.messages"
                     :key="key"
                     :id="'message-box'+ key">
                    <div class="message-item">
                        <span class="user-name">{{message && message.senderNickname}}:</span>
                        <span :class="message.senderUserId == room.currentUser.id ? 'user-message self' : 'user-message' ">
                            {{message && message.content}}
                        </span>
                    </div>
                </div>
            </div>
            <div class="chat-room-action">
                <div class="message-input-box">
                    <input class="message-input" :value="newMessageContent"
                           placeholder="说点什么..."
                           @input="onInputMessage"/>
                    <div class="message-btn" @click="sendMessage(room.MessageType.CHAT, newMessageContent)">↑</div>
                </div>
                <img class="heart" @click="sendMessage(room.MessageType.PROP, room.Prop.HEART)"
                       src="../assets/images/handle-heart.png">
                <img class="rocket" @click="sendMessage(room.MessageType.PROP, room.Prop.ROCKET)"
                       src="../assets/images/rokect.png">
            </div>
        </div>
        <div class="show-animation" v-if="prop.play">
            <img class="prop-heart" v-for="img in 4" :key="img"
                 src="../assets/images/heart.png"
                 v-if="prop.showPropType == room.Prop.HEART">
            <img class="prop-rocket" src="../assets/images/rokect.png"
                 v-if="prop.showPropType == room.Prop.ROCKET">
        </div>
    </div>
</template>

<script>
    import ChatRoomService from '../assets/lib/chatservice.js';
    export default {
        name: "ChatRoom",
        props : {
            roomToken : {
                type: Object,
                default () {
                    return null
                }
            }
        },
        data() {
            return {
                room: null,
                prop: {
                    showPropType: 0,
                    play: false,
                    timer: null
                },
                newMessageContent: "",
                chatRoomService: null

            }
        },
        beforeMount() {


            let currentUser = {//当前用户
                id: this.roomToken.userId,
                nickname: this.roomToken.nickname,
                avatar: this.roomToken.avatar
            };

            let room = {
                id : this.roomToken.roomId,
                name : this.roomToken.roomName
            };

            //构造chatRoomService
            this.chatRoomService = new ChatRoomService(room, currentUser);
            this.chatRoomService.initialWhenNewMessage(this.whenNewMessage);
            this.chatRoomService.connectGoEasyIM();
            //获取当前聊天室数据
            this.room = this.chatRoomService.room;

        },
        methods: {
            realignAvatar(key) {//排列头像
                var len = this.room.onlineUsers.users.length-1;
                if(key == len) {
                    return {
                        zIndex: 100
                    }
                }
                var p = (len - key+1)*0.1 +'rem'
                return {
                    transform:'translateX('+ p +')',
                    zIndex : 100-key
                }
            },
            onInputMessage(event) {//双向绑定消息 兼容
                this.newMessageContent = event.target.value;
            },
            whenNewMessage(message) {//新消息监听
                if (message.type == this.room.MessageType.PROP) {
                    this.propAnimation(parseInt(message.content))
                }
                this.$nextTick(() => {
                    this.$refs.myscroll.scrollTo(0, this.$refs.myscroll.scrollHeight)
                })
            },
            sendMessage(messageType, content) {//发送消息

                if (content == "" && messageType == this.room.MessageType.CHAT) return;
                var message = {
                    senderNickname: this.room.currentUser.nickname,
                    senderUserId: this.room.currentUser.id,
                    type: messageType,
                    content: content
                }
                this.chatRoomService.sendMessages(this.room.id, message);
                this.newMessageContent = "";
            },
            propAnimation(type) {//道具动画
                //动画的实现，可以不用关心
                if (this.prop.timer) {
                    return;
                }
                ;
                this.prop.showPropType = type;
                this.prop.play = true;
                this.prop.timer = setTimeout(() => {
                    this.prop.play = false;
                    this.prop.timer = null;
                }, 2000)
            },
            quitRoom () {
                this.$emit('quitRoom')
                this.chatRoomService.quitRoom(this.room.id);
            }
        }
    }
</script>

<style scoped>
    .chat-room {
        width: 100%;
        flex-direction: column;
        height: 100%;;
        position: relative;
    }

    .header{
        height: 0.9rem;
        line-height: 0.9rem;
        text-align: center;
        font-size: 0.24rem;
        color: #D02129;
        position: fixed;
        top:0;
        left: 0;
        width: 100%;
        z-index: 1000;
        background: #fff;
    }
    .quit-btn{
        position: absolute;
        right: 0.1rem;
        color: #999;
    }

    .online-avatar-container {
        height: 0.4rem;
        line-height: 0.4rem;
        display: flex;
        justify-content: flex-end;
        box-shadow: 0.05rem 0.15rem 0.25rem #fff;
        z-index: 40;
        padding: 0 0.1rem;
        position: fixed;
        top:0.9rem;
        right: 0;
        width: 100%;
        background: #fff;
    }

    .online-avatar-item {
        width: 0.4rem;
        height: 0.4rem;
        border-radius: 0.2rem;
        text-align: center;
        line-height: 0.4rem;
        background: rgba(51, 51, 51, 0.3);
        color: #fff;
        font-size: 0.14rem;
    }

    .online-count {
        width: 0.4rem;
        height: 0.4rem;
        border-radius: 0.4rem;
        text-align: center;
        background: rgba(51, 51, 51, 0.3);
        color: #fff;
        font-size: 0.14rem;
    }

    .online-avatar-item img {
        width: 0.4rem;
        height: 0.4rem;
    }

    .chat-room-container {
        position: fixed;
        left: 0;
        right: 0;
        flex-direction: column;
        padding: 1.3rem 0.2rem 0.66rem 0.2rem ;
        overflow: hidden;
        width:100%;
        height: 100%;
    }

    .chat-room-content {
        width: 100%;
        overflow: auto;
        height: 100%;
    }

    .message-box {
        margin-top: 0.08rem;
        display: flex;
    }

    .message-item {
        box-sizing: border-box;
        height: 0.36rem;
        background-color: rgba(196, 196, 196, 0.2);
        font-size: 0.14rem;
        border-radius: 0.5rem;
        padding: 0.09rem 0.15rem;
        font-family: Microsoft YaHei UI;
    }

    .user-name {
        color: #D02129;
        font-family: Microsoft YaHei UI;
    }

    .user-message {
        color: #333;
        font-family: Microsoft YaHei UI;
    }

    .chat-room-action {
        height: 0.66rem;
        line-height: 0.46rem;
        padding:0.1rem 0.14rem;
        display: flex;
        background: #ffffff;
        position: fixed;
        bottom: 0;
        right: 0;
        width: 100%;
    }
    .message-input-box{
        flex-grow: 1;
        display: flex;
        position: relative;
    }

    .message-input {
        background-color: rgba(51, 51, 51, 0.1);
        border-radius: 0.5rem;
        box-sizing: border-box;
        font-size: 0.14rem;
        padding: 0.13rem 0.2rem;
        flex: 1;
        border: 0;
        outline: none;
    }

    .message-btn {
        position: absolute;
        width: 0.36rem;
        height: 0.36rem;
        background: #D02129;
        right: 0.05rem;
        top: 0.05rem;
        border-radius: 0.36rem;
        text-align: center;
        line-height: 0.36rem;
        color: #fff;
        font-weight: bold;
        font-size: 0.16rem;
    }

    .heart {
        width: 0.4rem;
        height: 0.46rem;
    }

    .rocket {
        width: 0.2rem;
        height: 0.46rem;
    }

    .self {
        color: #D02129;
    }

    .show-animation {
        width: 0.4rem;
        height: 1.6rem;
        position: fixed;
        z-index: 44;
        left: 50%;
        bottom: 0.4rem;
        margin: 0 -0.2rem;
        justify-content: flex-end;
        animation: myanimation 2s linear;
        display: flex;
        flex-direction: column;
    }

    .prop-heart {
        height: 0.4rem;
        width: 0.4rem;
    }

    .prop-rocket {
        height: 0.8rem;
        width: 0.4rem;
    }

    @keyframes myanimation {
        from {
            bottom: 0.4rem;
        }
        to {
            bottom: 3rem;
        }
    }
</style>
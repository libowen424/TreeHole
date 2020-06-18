<template>
<div>
  <ChatBox :target="target" :targetId="targetId" />
</div>
</template>

<script>
import ChatBox from "../components/ChatBox";
export default {
    components:{
        ChatBox,
    },
    data()
    {
        return{
            
        };
    },
    computed:
    {
        target(){
            return this.$route.params.target;
        },
        targetId()
        {
            return this.$route.params.targetId;
        }
    }
}
</script>

<style>

</style>
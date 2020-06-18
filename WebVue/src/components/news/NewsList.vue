<template>
  <div>
    <div v-for="item in news" :key="item.id" class="news-item-normal">
      <!--暂时没用图片
      <div class="image" v-if="item.havePic">
        <a :href="item.link" target="_blank">
          <img :src="item.imageurls[0].url" alt="" />
        </a>
      </div>
      -->
      <div class="words">
        <div>
          <div>
        <h2 class="title">
          <a :href="item.link" target="_blank">
            <router-link 
            :to="{
              name:'Comment',
              params:{
                id:item.id,
              },
              }">
            {{ item.topicName }}
            </router-link>
          </a>
        </h2>
        </div>


            <div class="fav">

             <a @click="addThumbup(item.id)">
              <a-icon type="like" 
              theme="twoTone"
              :two-tone-color="hasExisted(item.id)?'#d32':''" 
              style="margin-right:50px;"
              />

             </a>
                 <a @click="addCollection(item.id)">
              <a-icon type="star" 
                theme="twoTone"
              :two-tone-color="hasExisted1(item.id)?'#d32':''" 
              style="margin-right:50px;"
              />
                 </a>
                 
             <div class="supportNum">
               10
             </div>
           

        </div>
        </div>
     
    

        <div class="aside">
          <span>{{ item.channelName }}</span>
          <span>来源：{{ item.publisher }}</span>
          <span>发布日期：{{ item.date }}</span>
        </div>
        <div class="content">
          {{ item.describe }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {getThumbUp} from "../../services/actionService"
import {postThumbUp} from "../../services/actionService"
import {deleteThumbUp} from "../../services/actionService"
import {getCollection} from "../../services/actionService"
import {postCollection} from "../../services/actionService"
import {deleteCollection} from "../../services/actionService"
export default {
  data(){
    return{
      //被收藏的话题id数组
      collections:[],
      //被点赞的话题id数组
      thumbups:[],
      //待删除的点赞信息id
      deleteId:0,
      //待删除的收藏信息id
      deleteId1:0,
    }
  },
  props: {
    news: {
      type: Array,
      default: () => [],
    },
  },
  created:function(){
    this.getThumbUp();
    this.getCollection();
  },
  methods:{
      //获取被收藏的话题id
    async getCollection()
    {
      var resp=await getCollection(this.$store.state.loginUser.data.id);
      this.collections=resp.data;
  },
    //获取被点赞的话题id
    async getThumbUp()
    {
      var resp=await getThumbUp(this.$store.state.loginUser.data.id);
      this.thumbups=resp.data;
  },
  //判断是否在收藏数组中
  hasExisted1(topicid){
    for(var j = 0; j < this.collections.length; j++) 
        {
          if(this.collections[j].topicId==topicid)
        {
          this.deleteId1=this.collections[j].id;
          return true;
        }

        } 
          return false;
      
  },
    //判断当前话题id是否在已被点赞是数组中
    hasExisted(topiciid)
    {
      for(var j = 0; j < this.thumbups.length; j++) 
      {
         if(this.thumbups[j].topicId==topiciid)
      {
        this.deleteId=this.thumbups[j].id;
        return true;
      }

      } 
        return false;
     

    },
    addCollection(id)
    {
      console.log("添加收藏");
      if(!this.hasExisted1(id)){
      postCollection({
        topicId:id,
        userId:this.$store.state.loginUser.data.id,
      });
      this.getCollection();
      }

      else{
        deleteCollection(this.deleteId1);
        this.getCollection();
      }
    },
    addThumbup(id){
      if(!this.hasExisted(id)){
      postThumbUp({
        topicId:id,
        userId:this.$store.state.loginUser.data.id,
      });
      this.getThumbUp();
      }

      else{
        //问题是怎么取出id
        deleteThumbUp(this.deleteId);
        this.getThumbUp();
      }
    }
      },
    };
</script>

<style scoped>
.supportNum{
  margin-top:0px ;
}
.fav{
  margin-top: -30px;
  margin-left: 900px;
}
.news-item-normal {
  border-bottom: 1px solid #ccc;
  overflow: hidden;
  padding: 20px 0;
}
.image {
  width: 150px;
  height: 150px;
  border: 1px solid #ccc;
  border-radius: 4px;
  float: left;
  margin-right: 20px;
}
.image img {
  width: 100%;
  height: 100%;
  object-fit: contain;
}
.title {
  font-size: 1.5em;
}
.aside {
  font-size: 14px;
  color: #888;
}
.aside span {
  margin-right: 15px;
}

.content {
  max-height: 100px;
  overflow: hidden;
  line-height: 2;
}
</style>

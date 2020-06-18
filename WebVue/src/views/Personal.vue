<template>
<div>

<div>
      <el-tabs v-model="activeName" @tab-click="handleClick">

        <el-tab-pane label="发帖记录" name="first">
          <div>
        <NewsList :news="myTopic" />
        </div>
        </el-tab-pane>

    <el-tab-pane label="我的收藏" name="second">
      <div>
       <NewsList :news="myCollecitons" />
      </div>
    </el-tab-pane>

    <el-tab-pane label="个人信息" name="third">
      <Ifoform />
    </el-tab-pane>

      <el-tab-pane label="我的关注" name="forth">
<MyConcern />
    </el-tab-pane>

  </el-tabs>
</div>
</div>
</template>

<script>
import NewsList from "../components/news/NewsList";
import {getNewsBynickname} from "../services/newsService";
import {getCollection} from "../services/actionService";
import {getNewsByid} from "../services/newsService";
import Ifoform from "../components/Ifoform";
import MyConcern from "../components/MyConcern";
export default {
    components:{
        NewsList,
        Ifoform,
        MyConcern,
    },
    data(){
        return{
            myTopic:[],
            myCollecitons:[],
            myCollectionIds:[],
            //ele
            activeName: 'first'
        };
    },
    methods:
    {
        //ele
          handleClick(tab, event) {
      },
        async setData() {
      var resp = await getNewsBynickname(this.$store.state.loginUser.data.nickname); //经过一段时间
      this.myTopic = resp.data;
    },
    async getCollection(){
      var resp = await getCollection(this.$store.state.loginUser.data.id); //经过一段时间
      this.myCollectionIds = resp.data;
      for(var j=0;j<this.myCollectionIds.length;j++){
 
        var resp1 = await getNewsByid(this.myCollectionIds[j].topicId);
        this.myCollecitons.push(resp1.data[0]);
      }
      console.log(this.myCollecitons);
    },
    },
    created:function()
    {
        this.setData();
        this.getCollection();
    }
}
</script>

<style>

</style>
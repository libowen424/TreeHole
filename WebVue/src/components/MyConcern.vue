<template>

   <el-table
    :data="Data"
    style="width: 100%">

    <el-table-column
      label="头像"
      width="180">
        <el-avatar :size="50" :src="circleUrl"></el-avatar>
    </el-table-column>

    <el-table-column
      label="用户名"
      width="180">

      <template slot-scope="scope">
        <el-popover trigger="hover" placement="top">

        <p>姓名: {{ scope.row.userName }}</p>
          <p>性别: {{ scope.row.sex }}</p>
            <p>生日: {{ scope.row.birth }}</p>
          <p>专业: {{ scope.row.profession }}</p>

          <div slot="reference" class="name-wrapper">
            <el-tag size="medium">{{ scope.row.userName }}</el-tag>
          </div>
        </el-popover>
      </template>
    </el-table-column>

    <el-table-column label="操作">
      <template slot-scope="scope">
        <el-button
          size="mini"
          @click="handleEdit(scope.$index, scope.row)">不再关注</el-button>
       
         <router-link
              :to="{
                name: 'Chat',
                params: {
                  target: scope.row.userName,
                  targetId:scope.row.userId,
                },
              }"
              >
        <el-button
          size="mini"
          type="danger"
          @click="handleDelete(scope.$index, scope.row)">留言
          </el-button>
      </router-link>

      </template>
    </el-table-column>
  </el-table>

</template>

<script>
import {getConcern} from "../services/concernService"
import {deleteConcern} from "../services/concernService"
export default {
    
  data() {
      return {
        Data:[],
        circleUrl:"https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png",
       }
    },
    created:function()
    {
      this.getConcern();
    },
    methods: {
      async getConcern(){
        var resp = await getConcern(this.$store.state.loginUser.data.id);
        this.Data=resp;
        console.log(resp);
              },
      handleEdit(index, row) {
        this.Data.pop(row);
         deleteConcern(     
               this.$store.state.loginUser.data.id,
              row.userId,);
        console.log(index, row);
      },
      handleDelete(index, row) {
        console.log(index, row);
      }
    }

}
</script>

<style>

</style>
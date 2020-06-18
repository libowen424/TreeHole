<template>

   <el-table
    :data="Data"
    style="width: 100%"
    :default-sort = "{prop:'mark',order:'descending'}"
    >

    <el-table-column
      label="匹配度"
      width="180"
      prop="mark"
      sortable>
      <template slot-scope="scope">
        <span style="margin-left: 10px">{{ scope.row.mark }}</span>
      </template>
    </el-table-column>

    <el-table-column
      label="用户名"
      width="180">
      <template slot-scope="scope">
        <el-popover trigger="hover" placement="top">
          <p>姓名: {{ scope.row.name }}</p>
          <p>性别: {{ scope.row.sex }}</p>
            <p>生日: {{ scope.row.birth }}</p>
          <p>专业: {{ scope.row.profession }}</p>

          <div slot="reference" class="name-wrapper">
            <el-tag size="medium">{{ scope.row.name }}</el-tag>
          </div>
        </el-popover>
      </template>
    </el-table-column>


    <el-table-column label="操作">
      <template slot-scope="scope">
        <el-button
          size="mini"
          @click="handleEdit(scope.$index, scope.row)">
             {{scope.row.isConcern ?"已关注":"关注"}}
        </el-button>

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
          @click="handleDelete(scope.$index, scope.row)">
          留言
          </el-button>
      </router-link>

      </template>
    </el-table-column>
  </el-table>

</template>

<script>
import {getMark} from "../services/markService"
import {postConcern} from "../services/concernService"
import {deleteConcern} from "../services/concernService"
export default {
  data() {
      return {
        Data:[],
      }
    },
    created:function()
    {
       this.getMark();
    },
    methods: {
        async getMark(){
        var resp =await getMark(this.$store.state.loginUser.data.id);
        this.Data=resp;
        console.log(resp);
        },
      handleEdit(index, row) {
        console.log(index, row);
        //添加一个关注消息
        if(row.isConcern){
          deleteConcern(
             this.$store.state.loginUser.data.id,
              row.userId,
                     )
        }
        if(!row.isConcern){
        postConcern(
          {
            userId1:this.$store.state.loginUser.data.id,
            userId2:row.userId,
          }
        );
        }
        row.isConcern=!row.isConcern;
      },
      handleDelete(index, row) {
        console.log(index, row);
      }
    }
}
</script>

<style>

</style>
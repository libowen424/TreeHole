<template>
<div class="center">
  <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">

 <el-form-item label="性别" prop="sex">
    <el-radio-group v-model="ruleForm.sex">
      <el-radio label="男"></el-radio>
      <el-radio label="女"></el-radio>
    </el-radio-group>
  </el-form-item>

 <el-form-item label="性取向" prop="sexorien">
    <el-radio-group v-model="ruleForm.sexorien">
      <el-radio label="男"></el-radio>
      <el-radio label="女"></el-radio>
        <el-radio label="双性"></el-radio>
      <el-radio label="无性"></el-radio>
    </el-radio-group>
  </el-form-item>

 <el-form-item label="专业" prop="profession">
    <el-select v-model="ruleForm.profession" placeholder="请选择专业">
      <el-option label="文" value="文"></el-option>
      <el-option label="法" value="法"></el-option>
        <el-option label="理" value="理"></el-option>
      <el-option label="工" value="工"></el-option>
      <el-option label="农" value="农"></el-option>
      <el-option label="医" value="医"></el-option>
    </el-select>
  </el-form-item>

 <el-form-item label="身高" prop="height">
    <el-select v-model="ruleForm.height" placeholder="请选择身高">
      <el-option label="0-150" value=1></el-option>
      <el-option label="150-160" value=2></el-option>
        <el-option label="160-170" value=3></el-option>
      <el-option label="170-180" value=4></el-option>
      <el-option label="180-190" value=5></el-option>
      <el-option label="190-200" value=6></el-option>
        <el-option label="200-300" value=7></el-option>
    </el-select>
  </el-form-item>
  
  <el-form-item label="兴趣爱好" prop="interest">
    <el-checkbox-group v-model="ruleForm.interest">
      <el-checkbox label="运动" name="interest"></el-checkbox>
      <el-checkbox label="读书" name="interest"></el-checkbox>
      <el-checkbox label="看电影" name="interest"></el-checkbox>
      <el-checkbox label="唱歌" name="interest"></el-checkbox>
            <el-checkbox label="跳舞" name="interest"></el-checkbox>
      <el-checkbox label="打游戏" name="interest"></el-checkbox>
    </el-checkbox-group>
  </el-form-item>

  <el-form-item label="出生日期" required>
       <el-col :span="11">
      <el-form-item prop="birth">
        <el-date-picker type="date" placeholder="选择日期" v-model="ruleForm.birth" style="width: 100%;"></el-date-picker>
      </el-form-item>
       </el-col>
  </el-form-item>

 <el-form-item v-show="ispost">
    <el-button type="primary" @click="submitForm('ruleForm')">保存</el-button>
    <el-button @click="resetForm('ruleForm')">重置</el-button>
  </el-form-item>

<!--修改按钮
    如果ispost是false 说明此次为修改 只需要修改函数就可以了
-->
 <el-form-item v-show="!ispost">
    <el-button type="primary" @click="putIfo('ruleForm')">修改</el-button>
  </el-form-item>

</el-form>
</div>
</template>

<script>
import {postIfo} from "../services/ifoService"
import {getIfo} from "../services/ifoService"
import {putIfo} from "../services/ifoService"
export default {
data(){
    return{
      //ispost是指 是修改还是新提交的用户
      ispost:false,
      ifo:{},
        ruleForm:{
            sex:'男',
            sexorien:'',
            profession:'',
            height:'',
            interest:[],
            birth: 'Tue Jun 02 2020 00:00:00 GMT+0800 (中国标准时间)',
        },
        interestId:"",
        rules:{
        sex: [
            { required: true, message: '请选择性别', trigger: 'change' }
          ],
        sexorien: [
            { required: true, message: '请选择性取向', trigger: 'change' }
          ],
          profession:[
            { required: true, message: '请选择专业', trigger: 'change' }
          ],
          height:[
            { required: true, message: '请选择身高', trigger: 'change' }
          ],
           interest: [
            { type: 'array', required: true, message: '请至少选择一个爱好', trigger: 'change' }
          ],
          //type: 'date',
           birth: [
            {  required: true, message: '请选择出生日期', trigger: 'change' }
          ],
        },
    }
},
created:function(){
this.getIfo();
},
 methods: {
   //修改信息的函数
   putIfo(formName)
   {
        this.$refs[formName].validate((valid) => {
          if (valid) {
                        this.interestId="";
            this.setinterest();
            //递交数据
            putIfo(this.$store.state.loginUser.data.id,
            {
              userId:this.$store.state.loginUser.data.id,
              birth:this.ruleForm.birth,
              height:this.ruleForm.height,
              interest:this.interestId,
              profession:this.ruleForm.profession,
              sex:this.ruleForm.sex,
              sexorien:this.ruleForm.sexorien,
            }
            );
            this.interestId="";
          } 
          else {
            console.log('error submit!!');
            return false;
          }
        });
   },
   async getIfo()
   {
      var resp=await getIfo(this.$store.state.loginUser.data.id);
      if(resp.data.length!=0)
      {
      this.ruleForm.birth=resp.data[0].birth;
      this.ruleForm.height=resp.data[0].height;
      this.ruleForm.profession=resp.data[0].profession;
      this.ruleForm.sex=resp.data[0].sex;
      this.ruleForm.sexorien=resp.data[0].sexorien;
      this.interestId=resp.data[0].interest;
      this.getinterest();
      }
      //新创新时获取数据，如果获取不到，则设置ispost为true，说明此次为新增信息
      else{
        console.log("这里");
        this.ispost=true;
      }
   },

      submitForm(formName) {
        this.$refs[formName].validate((valid) => {
          if (valid) {
            alert('submit!');
            console.log(this.ruleForm);
            this.setinterest();
            //递交数据
          postIfo(
            {
              userId:this.$store.state.loginUser.data.id,
              birth:this.ruleForm.birth,
              height:this.ruleForm.height,
              interest:this.interestId,
              profession:this.ruleForm.profession,
              sex:this.ruleForm.sex,
              sexorien:this.ruleForm.sexorien,

            }
          );
            this.resetForm('ruleForm');
            this.interestId="";
          } 
          else {
            console.log('error submit!!');
            return false;
          }
        });
      },
      setinterest()
      {
        if(this.ruleForm.interest.includes("运动"))
          {
             this.interestId=this.interestId.concat('1');
          }
          else{
               this.interestId=this.interestId.concat('0');
          }
            if(this.ruleForm.interest.includes("读书"))
          {
             this.interestId=this.interestId.concat('1');
          }
          else{
               this.interestId=this.interestId.concat('0');
          }  if(this.ruleForm.interest.includes("看电影"))
          {
             this.interestId=this.interestId.concat('1');
          }
          else{
               this.interestId=this.interestId.concat('0');
          }  if(this.ruleForm.interest.includes("唱歌"))
          {
             this.interestId=this.interestId.concat('1');
          }
          else{
               this.interestId=this.interestId.concat('0');
          }  if(this.ruleForm.interest.includes("跳舞"))
          {
             this.interestId=this.interestId.concat('1');
          }
          else{
               this.interestId=this.interestId.concat('0');
          }  if(this.ruleForm.interest.includes("打游戏"))
          {
             this.interestId=this.interestId.concat('1');
          }
          else{
               this.interestId=this.interestId.concat('0');
          }
          console.log(this.interestId);
      },
      getinterest()
      {
        if(this.interestId.charAt(0)=='1')
        this.ruleForm.interest.push("运动");
        if(this.interestId.charAt(1)=="1")
        this.ruleForm.interest.push("读书");        
        if(this.interestId.charAt(2)=="1")
        this.ruleForm.interest.push("看电影");        
        if(this.interestId.charAt(3)=="1")
        this.ruleForm.interest.push("唱歌");        
        if(this.interestId.charAt(4)=="1")
        this.ruleForm.interest.push("跳舞");        
        if(this.interestId.charAt(5)=="1")
        this.ruleForm.interest.push("打游戏");

      },
      resetForm(formName) {
        this.$refs[formName].resetFields();
      }
    }

}
</script>

<style scoped>
.center{
    margin-right: auto;
    margin-left: auto;
}
</style>
import axios from "axios";
  //增加一个关注信息
  export async function postConcern(concern) {
    var resp = await axios.post("/api/concern", concern);
    return resp;
  }

  //删除关注
  export async function deleteConcern(userId1,userId2) {
    var resp = await axios.delete("/api/concern?userId1="+userId1+"&&userId2="+userId2);
    return resp;
  }

  //获取用户的关注对象
  export async function getConcern(userId1) {
    var resp = await axios.get("/api/concern?userId1="+userId1);
    var data=[];
    for(var i=0;i<resp.data.length;i++)
    {
      var resp1 = await axios.get("/api/ifo?userId="+resp.data[i].userId2);
      data.push(resp1.data[0]);
    }
    return data;
  }
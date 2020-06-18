import axios from "axios";
//根据用户id获取所有点赞话题id
export async function getThumbUp(userId) {
    var sql ="/api/thumbup?userId="+userId;
    var resp = await axios.get(sql);
    return resp;
  }
  //增加一个点赞信息
export async function postThumbUp(thumup) {
    var resp = await axios.post("/api/thumbup", thumup);
    return resp;
  }
  //删除一个点赞信息
  export async function deleteThumbUp(id) {
    var resp = await axios.delete("/api/thumbup?id="+id);
    return resp;
  }

  //根据用户id获取所有收藏话题id
export async function getCollection(userId) {
  var sql ="/api/collection?userId="+userId;
  var resp = await axios.get(sql);
  return resp;
}
//增加一个收藏信息
export async function postCollection(collection) {
  var resp = await axios.post("/api/collection", collection);
  return resp;
}
//删除一个点赞信息
export async function deleteCollection(id) {
  var resp = await axios.delete("/api/collection?id="+id);
  return resp;
}
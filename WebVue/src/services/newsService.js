// 远程获取话题和话题类别的数据
import axios from "axios";
// import { APPCODE } from "./config";
/**
 * 获取所有的话题类别
 */
export async function getNewsChannels() {
  var resp = await axios.get("/api/channel");
  return resp;
}

/**
 * 按照频道，分页获取话题
 * @param {*} channelId 频道id
 * @param {*} page 页码，从1开始
 * @param {*} limit 每页多少条数据
 */
export async function getNews(channelId, page = 1, limit = 10) {
  var sql ="/api/topic?channelId="+channelId;
  var resp = await axios.get(sql);
  return resp;
}

//按照用户名获取话题
export async function getNewsBynickname(nickname) {
  var sql ="/api/topic?nickName="+nickname;
  var resp = await axios.get(sql);
  return resp;
}
//按照话题id获取话题
export async function getNewsByid(id) {
  var sql ="/api/topic?id="+id;
  var resp = await axios.get(sql);
  return resp;
}
//发布话题
export async function postTopic(topicadd) {
  var resp = await axios.post("/api/topic", topicadd);
return resp;
}

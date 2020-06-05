// 远程获取新闻和新闻类别的数据
import axios from "axios";
// import { APPCODE } from "./config";
/**
 * 获取所有的新闻类别
 */
export async function getNewsChannels() {
  var resp = await axios.get("/api/channel");
  return resp;
}

/**
 * 按照频道，分页获取新闻
 * @param {*} channelId 频道id
 * @param {*} page 页码，从1开始
 * @param {*} limit 每页多少条数据
 */
export async function getNews(channelId, page = 1, limit = 10) {
  var sql ="/api/topic?channelId="+channelId;
  var resp = await axios.get(sql);
  return resp;
}

import axios from "axios";

//按照话题Id来获取所有相关的回复
export async function getReplies(topicId)
{
    var sql = "/api/reply?topicId="+topicId;
    var resp = await axios.get(sql);
    return resp;
}
//添加回复
export async function postReply(replyadd)
{
    var resp = await axios.post("/api/reply", replyadd);
    return resp;
}
//按照回复Id来获取所有相关的sub回复
export async function getSubreplies(replyId)
{
    var sql = "/api/subreply?replyId="+replyId;
    var resp = await axios.get(sql);
    return resp;
}
//添加副回复
export async function postSubreply(subreplyadd)
{
    var resp = await axios.post("/api/subreply", subreplyadd);
    return resp;
}
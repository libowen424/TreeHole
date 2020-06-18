import axios from "axios";
export async function postIfo(ifo) {
    var resp = await axios.post("/api/ifo",ifo);
    return resp;
  }

  export async function getIfo(userId) {
    var sql ="/api/ifo?userId="+userId;
    var resp = await axios.get(sql);
    return resp;
  }
  export async function putIfo(userId,ifo) {
    var resp = await axios.put("/api/ifo/"+userId,ifo);
    return resp;
  }
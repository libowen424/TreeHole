import axios from "axios";
export async function postMessage(message) {
    var resp = await axios.post("/api/message", message);
    return resp;
  }

  export async function getMessage(userId1,userId2) {
    var resp = await axios.get("/api/message?userId1="+userId1+"&&userId2="+userId2);
    return resp;
  }
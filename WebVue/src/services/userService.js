import axios from "axios";

//辅助的delay函数 延后方便查看
function delay(duration) {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve();
    }, duration);
  });
}

export async function login(loginInfo) {
  await delay(2000);
  // post http://study.yuanjin.tech/api/user/login
  var resp = await axios.post("/api/user/login", loginInfo);
  // var token = resp.headers.authorization; // 拿到服务器的令牌
  // if (token) {
  //   // 把令牌保存下来
  //   localStorage.setItem("token", token);
  // }
  return resp.data;
}

// 使用保存的令牌从服务器换取登录信息
export async function whoAmI() {
  // get http://study.yuanjin.tech/api/user/whoami
  // authorization: bearer tokenxxxxx
  await delay(2000);
  var token = localStorage.getItem("token");
  if (!token) {
    return null;
  }
  var resp = await axios.get("/api/user/whoami", {
    headers: {
      authorization: `bearer ${token}`,
    },
  });
  return resp.data.data;
}

// 注销
export function loginOut() {
  localStorage.removeItem("token");
}

// 注册
//userInfo:   {LoginId,LoginPwd,Nickname}
export async function reg(userInfo) {
  // post http://localhost:5000/api/user/reg
  var resp = await axios.post("/api/user/reg", userInfo);
  console.log("这里");
  console.log(resp);
  return resp;
}

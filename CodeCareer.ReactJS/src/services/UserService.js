import axios from "./custom-exios";

function Login(userInfo) {
    return axios.post("/Users/Login", userInfo)
}

export { Login }
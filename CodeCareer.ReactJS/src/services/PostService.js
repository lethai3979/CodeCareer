import axios from "./custom-exios"

function getAllPosts() {
    return axios.get("/Post/GetAll")
}
function getAllPersonalPosts() {
    return axios.get(`/Post/GetAllById`)
}

function getPostById(id) {
    return axios.get(`/Post/GetById/${id}`)
}

function createPost(title, description, expireDate) {
    return axios.post("/Post/Create", { title, description, expireDate })
}

function updatePost(id, title, description, expireDate) {
    return axios.put(`/Post/Update/${id}`, { id, title, description, expireDate })
}

function deletePost(id) {
    return axios.delete(`/Post/Delete/${id}`)
}
export { getAllPosts, getAllPersonalPosts, createPost, getPostById, updatePost, deletePost}
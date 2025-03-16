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

function createPost(title, description, expireDate, image) {
    const formData = new FormData();
    formData.append("title", title);
    formData.append("description", description);
    formData.append("expireDate", expireDate);
    if (image) formData.append("image", image);

    return axios.post("/Post/Create", formData, {
        headers: {
            "Content-Type": "multipart/form-data",
        },
    });
}


function updatePost(id, title, description, expireDate,image) {
    return axios.put(`/Post/Update/${id}`, { id, title, description, expireDate,image })
}

function deletePost(id) {
    return axios.delete(`/Post/Delete/${id}`)
}
export { getAllPosts, getAllPersonalPosts, createPost, getPostById, updatePost, deletePost}
import axios from "./custom-exios"

function getAllPosts() {
    return axios.get("/Post/GetAll")
}

function getPostById(id) {
    return axios.get(`/Post/GetById/${id}`)
}

function createPost(title, description, expireDate) {
    return axios.post("/Post/Create", { title, description, expireDate })
}

function updatePost(id, title, description, expireDate) {
    return axios.put(`/Post/Update/${id}`,
        { id, title, description, expireDate },
        {
            headers: {
                Authorization: `Bearer ${localStorage.getItem('token')}`,
                'Content-Type': 'application/json'
            }
        }
    );
}

export { getAllPosts, createPost, getPostById, updatePost }
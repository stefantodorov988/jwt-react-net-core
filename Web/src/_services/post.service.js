export const postService = {
    getPosts,
    handleClick,
    createPost,
};

function getPosts() {
    return window.api.get("/posts")
        .then(values => {
            return values;
        });
}

function handleClick(id, ip){
    return window.api.post('/posts/click', { id : id , ip : ip })
}

function createPost(title, imageUrl) {
    return window.api.post("/posts", {title : title , imageLink : imageUrl})
        .then(values => {
            return values;
        });
}
import Card from 'react-bootstrap/Card';
import { Row, Col } from 'react-bootstrap';
import { useState, useEffect } from 'react';
import { getAllPersonalPosts } from '../../services/PostService';
import ModalAddPost from './ModalAddPost';
import { Link } from 'react-router-dom';
import ModalEditPost from './ModalEditPost';
import ModalDeletePost from './ModalDeletePost';

function PersonalPosts() {
    const [posts, setPosts] = useState([]);
    const [selectedPost, setSelectedPost] = useState({});
    const [showModalAddPost, setShowModalAddPost] = useState(false);
    const [showModalEditPost, setShowModalEditPost] = useState(false);
    const [showModalDeletePost, setShowModalDeletePost] = useState(false);
    const [reload, setReload] = useState(false); // Thêm state để kiểm soát việc gọi lại API

    // Hàm gọi API để lấy danh sách bài viết
    const getPosts = async () => {
        try {
            let res = await getAllPersonalPosts();
            if (res && res.data) {
                setPosts(res.data);
            }
        } catch (error) {
            console.error("Error fetching posts:", error);
        }
    };

    // Gọi API khi component mount hoặc khi reload thay đổi
    useEffect(() => {
        getPosts();
    }, [reload]);

    const handleEditPost = post => {
        setSelectedPost(post);
        setShowModalEditPost(true);
    };

    const handleDeletePost = post => {
        setSelectedPost(post);
        setShowModalDeletePost(true);
    };

    return (
        <>
            <div>
                <button
                    className="btn btn-success my-3"
                    onClick={() => setShowModalAddPost(true)}
                >
                    Add new post
                </button>
                <ModalAddPost
                    show={showModalAddPost}
                    handleClose={() => {
                        setShowModalAddPost(false);
                        setReload(prev => !prev); // Kích hoạt reload sau khi đóng modal
                    }}
                />
                <ModalEditPost
                    show={showModalEditPost}
                    handleClose={() => {
                        setShowModalEditPost(false);
                        setReload(prev => !prev);
                    }}
                    post={selectedPost}
                />
                <ModalDeletePost
                    show={showModalDeletePost}
                    handleClose={() => {
                        setShowModalDeletePost(false);
                        setReload(prev => !prev);
                    }}
                    postId={selectedPost.id}
                />
            </div>
            <div>
                <Row>
                    {posts.map((p) => (
                        <Col key={p.id} xs={12} md={6} lg={4} className="mb-4">
                            <Card className="h-100 d-flex flex-column">
                                <Card.Img variant="top"
                                    src={p.imageUrl || "https://coffective.com/wp-content/uploads/2018/06/default-featured-image.png.jpg"}
                                    style={{ height: "350px", objectFit: "cover", width: "100%" }}
                                />
                                <Card.Body className="d-flex flex-column flex-grow-1">
                                    <Card.Title className="flex-grow-0">{p.title}</Card.Title>
                                    <Card.Text className="flex-grow-1">{p.description}</Card.Text>
                                    <Card.Text>{p.recruiterUserName}</Card.Text>
                                    <Card.Text>Ngày đăng: {new Date(p.publishDate).toLocaleDateString('vi-VN')}</Card.Text>
                                    <Card.Text>Ngày kết thúc: {new Date(p.expireDate).toLocaleDateString('vi-VN')}</Card.Text>
                                    <div>
                                        <Link className='btn btn-success' to={`/detail-post/${p.id}`}>Chi tiết</Link>
                                    </div>
                                    <div>
                                        <button
                                            className="btn btn-warning my-3"
                                            onClick={() => handleEditPost(p)}
                                        >
                                            Update
                                        </button>
                                    </div>
                                    <div>
                                        <button
                                            className="btn btn-danger my-3"
                                            onClick={() => handleDeletePost(p)}
                                        >
                                            Delete
                                        </button>
                                    </div>
                                </Card.Body>
                            </Card>
                        </Col>
                    ))}
                </Row>
            </div>
        </>
    );
}

export default PersonalPosts;

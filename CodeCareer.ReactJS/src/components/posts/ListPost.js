import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import { Row, Col } from 'react-bootstrap';
import { useState, useEffect } from 'react';
import { getAllPosts } from '../../services/PostService';
import ModalAddPost from '../posts/ModalAddPost';
import { Link } from 'react-router-dom';

function ListPost() {
    const [posts, setPosts] = useState([]);
    const getPosts = async () => {
        let res = await getAllPosts();
        if (res && res.data) {
            setPosts(res.data)
        }
    }

    useEffect(() => {
        getPosts();
    }, []);
    return (
        <>
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
                                    <Card.Text>{p.recruiter?.userName}</Card.Text>
                                    <Card.Text>Ngày đăng: {new Date(p.publishDate).toLocaleDateString('vi-VN')}</Card.Text>
                                    <Card.Text>Ngày kết thúc: {new Date(p.expireDate).toLocaleDateString('vi-VN')}</Card.Text>
                                    <Link className='btn btn-success' to={`/detail-post/${p.id}`}>Chi tiết</Link>
                                </Card.Body>
                            </Card>
                        </Col>
                    ))}
                </Row>
            </div >
        </>
    );
}

export default ListPost;

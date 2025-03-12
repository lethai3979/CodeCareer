import { Button, Card, Col, Container, Row } from "react-bootstrap";
import { getPostById } from "../../services/PostService";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

export default function DetailPost() {
    const { id } = useParams();
    const [post, setPosts] = useState({});
    // const [description, setDescription] = useState('');
    // const [publishDate, setPublishDate] = useState('');
    // const [expireDate, setExpireDate] = useState('');
    // const [recruiterName, setRecruiterName] = useState('');
    // const [recruiterDescription, setRecruiterDescription] = useState('');
    // const [recruiterAddress, setRecruiterAddress] = useState('');


    useEffect(() => {
        const post = async () => {
            try {
                let res = await getPostById(id);
                if (res && res.data) {
                    setPosts(res.data)
                }
            }
            catch (Error) {
                console.log(Error.message);
            }
        };
        post();
    })

    return (
        <div className="mt-5">
            <Row className="g-4">
                {/* Chi tiết bài đăng */}
                <Col md={8}>
                    <Card className="shadow">
                        <Card.Body>
                            <Card.Title className="text-primary">{post.title}</Card.Title>
                            <Card.Subtitle className="mb-2 text-muted">
                                {post.description}
                            </Card.Subtitle>
                            <Card.Text className="text-start">
                                Yêu cầu ứng tuyển
                            </Card.Text>
                            <Card.Text className="text-start">
                                Chi iết tuyển dụng
                            </Card.Text>
                        </Card.Body>
                    </Card>
                </Col>

                {/* Nhà tuyển dụng */}
                <Col md={3}>
                    <Card className="shadow">
                        <Card.Body>
                            <Card.Title className="text-success">{post?.recruiter?.userName}</Card.Title>
                            <Card.Text className="text-start">Địa chỉ: {post?.recruiter?.address}</Card.Text>
                            <Card.Text className="text-start">Mô tả: {post?.recruiter?.description}</Card.Text>
                        </Card.Body>
                    </Card>
                </Col>

            </Row>
        </div>
    );
}
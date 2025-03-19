import { useState } from "react";
import { Button, Form, Modal, Image } from "react-bootstrap";
import { createPost } from "../../services/PostService";
import { toast } from "react-toastify";

function ModalAddPost(props) {
    const { show, handleClose } = props;
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [date, setDate] = useState("");
    const [imageFile, setImageFile] = useState(null);
    const [previewImage, setPreviewImage] = useState(null);

    // Xử lý chọn ảnh và tạo preview
    const handleImageChange = (e) => {
        const file = e.target.files[0];
        setImageFile(file);

        if (file) {
            const imageUrl = URL.createObjectURL(file);
            setPreviewImage(imageUrl);
        }
    };

    const handleSaveNewPost = async () => {
        try {
            const expireDate = new Date(date + "T00:00:00Z").toISOString();
            let res = await createPost(title, description, expireDate, imageFile);
            toast.success("Đăng bài thành công");
            console.log("Response:", res);
        } catch (error) {
            toast.error("Đăng bài không thành công");
            console.error("Error creating post:", error);
        }
    };

    return (
        <>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Add Post</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group className="mb-3" controlId="formBasicTitle">
                            <Form.Label>Title</Form.Label>
                            <Form.Control
                                type="text"
                                value={title}
                                onChange={(event) => setTitle(event.target.value)}
                            />
                        </Form.Group>
                        <Form.Group className="mb-3" controlId="formBasicDescription">
                            <Form.Label>Description</Form.Label>
                            <Form.Control
                                type="text"
                                value={description}
                                onChange={(event) => setDescription(event.target.value)}
                            />
                        </Form.Group>
                        <Form.Group className="mb-3" controlId="formBasicExpireDate">
                            <Form.Label>Expire Date</Form.Label>
                            <Form.Control
                                type="date"
                                value={date}
                                onChange={(event) => setDate(event.target.value)}
                            />
                        </Form.Group>
                        <Form.Group className="mb-3" controlId="formBasicImage">
                            <Form.Label>Image</Form.Label>
                            <Form.Control
                                type="file"
                                accept="image/*"
                                onChange={handleImageChange}
                            />
                        </Form.Group>

                        {/* Hiển thị ảnh preview nếu người dùng chọn ảnh */}
                        {previewImage && (
                            <div className="text-center mb-3">
                                <Image src={previewImage} alt="Preview" fluid thumbnail />
                            </div>
                        )}
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={() => handleSaveNewPost()}>
                        Create
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
}

export default ModalAddPost;

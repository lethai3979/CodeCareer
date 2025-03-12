import { useState } from "react";
import { Button, Form, Modal } from "react-bootstrap"
import { createPost } from "../../services/PostService";
import { toast } from "react-toastify";

function ModalAddPost(props) {
    const { show, handleClose } = props;
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [date, setDate] = useState("");
    const handleSaveNewPost = async () => {
        try {
            const expireDate = new Date(date + "T00:00:00Z").toISOString();
            let res = await createPost(title, description, expireDate);
            toast.success("Đăng bài thành công")
            console.log("Response:", res);
        } catch (error) {
            toast.error("Đăng bài không thành công")
            console.error("Error creating post:", error);
            console.error("Request error:", error.message);

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

export default ModalAddPost
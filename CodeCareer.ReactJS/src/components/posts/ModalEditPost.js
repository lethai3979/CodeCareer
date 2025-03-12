import { useEffect, useState } from "react";
import { Button, Form, Modal } from "react-bootstrap"
import { updatePost } from "../../services/PostService";
import { toast } from "react-toastify";

function ModalEditPost(props) {
    const { show, handleClose, post } = props;
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [date, setDate] = useState("");
    const handleEditPost = async () => {
        try {
            const expireDate = new Date(date + "T00:00:00Z").toISOString();
            const editPost = {
                id: post.id,
                title: title,
                description: description,
                date: expireDate
            }
            console.log(editPost)
            let res = await updatePost(post.id, title, description, expireDate);
            toast.success("cập nhật thành công")
            console.log("Response:", res);
        } catch (error) {
            toast.error("cập nhật không thành công")
            console.error("Error updating post:", error);
            console.error("Request error:", error.message);

        }
    };
    useEffect(() => {
        if (show) {
            setTitle(post.title)
            setDescription(post.description)
            setDate(post.expireDate ? new Date(post.expireDate).toLocaleDateString('en-CA') : "")
        }

    }, [post, show])
    return (
        <>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Edit</Modal.Title>
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
                    <Button variant="primary" onClick={() => handleEditPost()}>
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
}

export default ModalEditPost
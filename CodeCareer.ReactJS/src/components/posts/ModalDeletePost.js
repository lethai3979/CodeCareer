import { Button, Modal } from "react-bootstrap"
import { deletePost } from "../../services/PostService";
function ModalDeletePost(props) {
    const { postId, show, handleClose } = props;
    const handleDeletePost = async () => {
        try {
            const res = await deletePost(postId);
            console.log("Delete post with id:", postId);
            console.log("Response:", res);
        } catch (error) {
            console.error("Error deleting post:", error);
            console.error("Request error:", error.message);
        }
    };
    return (
        <>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Modal heading</Modal.Title>
                </Modal.Header>
                <Modal.Body>Delete this post ?</Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Cancel
                    </Button>
                    <Button
                        variant="primary"
                        onClick={() => {
                            handleClose();
                            handleDeletePost();
                        }}
                    >
                        Confirm
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
}

export default ModalDeletePost;
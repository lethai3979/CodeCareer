import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { useNavigate } from 'react-router-dom';

function ModalRegister(props) {
    const { show, handleClose } = props;
    const navigate = useNavigate();
    return (
        <div
            className="modal show"
            style={{ display: "block", position: "initial" }}
        >
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Register</Modal.Title>
                </Modal.Header>
                <Modal.Body className="d-flex justify-content-center gap-3">
                    <Button
                        variant="primary"
                        className="m-2"
                        onClick={() => navigate("/applier-register")}
                    >
                        Đăng ký Ứng viên
                    </Button>
                    <Button
                        variant="secondary"
                        className="m-2"
                        onClick={() => navigate("/recruiter-register")}
                    >
                        Đăng ký Nhà tuyển dụng
                    </Button>
                </Modal.Body>
                <Modal.Footer></Modal.Footer>
            </Modal>
        </div>
    );
}

export default ModalRegister;
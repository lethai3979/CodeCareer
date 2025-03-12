import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { Link } from 'react-router-dom';
import ModalRegister from './ModalRegister';
import { useState } from 'react';

function Header() {
    const [showModalRegister, setShowModalRegister] = useState(false);
    return (
        <>
            <Navbar expand="lg" className="bg-body-tertiary">
                <Container>
                    <Navbar.Brand>Code Career</Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav className="me-auto">
                            <Link className="nav-link" to="/">Home</Link>
                            <Link className="nav-link" to="/personal-post">Bài đăng cá nhân</Link>
                            <NavDropdown title="Dropdown" id="basic-nav-dropdown">
                                <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
                                <NavDropdown.Item href="#action/3.2">
                                    Another action
                                </NavDropdown.Item>
                                <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
                                <NavDropdown.Divider />
                                <NavDropdown.Item href="#action/3.4">
                                    Separated link
                                </NavDropdown.Item>
                            </NavDropdown>
                        </Nav>

                        <Nav className="ms-auto">
                            <Link className="btn btn-warning text-dark" to="/login">Login</Link>
                        </Nav>
                        <Nav className="ms-auto">
                            <div>
                                <button
                                    className="btn btn-success my-3"
                                    onClick={() => setShowModalRegister(true)}
                                >
                                    Register

                                </button >
                                <ModalRegister
                                    show={showModalRegister}
                                    handleClose={() => setShowModalRegister(false)}
                                ></ModalRegister>
                            </div >
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
        </>
    );
}

export default Header;

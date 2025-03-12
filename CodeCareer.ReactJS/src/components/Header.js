import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { Link, useNavigate } from 'react-router-dom';
import ModalRegister from './ModalRegister';
import { useState, useEffect } from 'react';
import { jwtDecode } from 'jwt-decode';

function Header() {
    const [showModalRegister, setShowModalRegister] = useState(false);
    const navigate = useNavigate();
    const token = sessionStorage.getItem('authToken');
    const user = token ? jwtDecode(token) : null;
    const role = user?.role;
    const isLoggedIn = !!token;
   const handleLogout = () => {
        sessionStorage.clear();
        navigate('/');
    };

    return (
        <>
            <Navbar expand="lg" className="bg-body-tertiary">
                <Container>
                    <Navbar.Brand>Code Career</Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                    <Navbar.Collapse id="basic-navbar-nav">
                        <Nav className="me-auto">
                            <Link className="nav-link" to="/">Home</Link>
                            {role === 'Recruiter' && <Link className="nav-link" to="/personal-post">Bài đăng cá nhân</Link>}
                            <NavDropdown title="Dropdown" id="basic-nav-dropdown">
                                <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
                                <NavDropdown.Item href="#action/3.2">Another action</NavDropdown.Item>
                                <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
                                <NavDropdown.Divider />
                                <NavDropdown.Item href="#action/3.4">Separated link</NavDropdown.Item>
                            </NavDropdown>
                        </Nav>

                        <Nav className="ms-auto">
                            {isLoggedIn ? (
                                <>
                                    <span className="nav-link">Welcome, {user.email}</span>
                                    <button className="btn btn-danger" onClick={handleLogout}>Logout</button>
                                </>
                            ) : (
                                <>
                                    <Link className="btn btn-warning text-dark me-2" to="/login">Login</Link>
                                    <button
                                        className="btn btn-success"
                                        onClick={() => setShowModalRegister(true)}
                                    >
                                        Register
                                    </button>
                                    <ModalRegister
                                        show={showModalRegister}
                                        handleClose={() => setShowModalRegister(false)}
                                    />
                                </>
                            )}
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
        </>
    );
}

export default Header;
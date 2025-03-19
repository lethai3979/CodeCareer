/* eslint-disable no-undef */
import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { Login } from "../services/UserService";
import { jwtDecode } from "jwt-decode";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
export default function LoginForm() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();
    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await Login({ email, password });
            const token = response.data;
            sessionStorage.setItem("authToken", token);
            const decoded = jwtDecode(token);
            console.log("Thông tin từ token:", decoded);
            toast.success("Đăng nhập thành công");
            navigate("/");
        } catch (error) {
            console.error("Lỗi đăng nhập:", error.response?.data || error.message);
            toast.error(`Đăng nhập thất bại`);
        }
    };

    return (
        <div className="d-flex justify-content-center align-items-center vh-100">
            <Form className="p-4 shadow rounded w-25 bg-light" onSubmit={handleSubmit}>
                <h3 className="text-center mb-4">Đăng nhập</h3>
                <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Label>Email</Form.Label>
                    <Form.Control
                        type="email"
                        placeholder="Enter email"
                        value={email}
                        onChange={(event) => setEmail(event.target.value)}
                        required
                    />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control
                        type="password"
                        autoComplete="off"
                        placeholder="Password"
                        value={password}
                        onChange={(event) => setPassword(event.target.value)}
                        required
                    />
                </Form.Group>
                <Button variant="primary" type="submit">
                    Đăng nhập
                </Button>
            </Form>
        </div>
    );
}

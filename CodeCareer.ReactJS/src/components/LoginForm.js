import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import { Login } from "../services/UserService";

export default function LoginForm() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await Login({ email, password });
            console.log("Đăng nhập thành công:", response.data);
        } catch (error) {
            console.error("Lỗi đăng nhập:", error.response?.data || error.message);
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
                    Submit
                </Button>
            </Form>
        </div>
    );
}

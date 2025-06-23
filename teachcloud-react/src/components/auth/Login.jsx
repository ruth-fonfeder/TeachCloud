import React, { useState } from "react";
import { login } from "../../api/authApi";
import { useAuth } from "../../hooks/useAuth";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState(null);
  const { loginUser } = useAuth();
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(null);
    try {
      const data = await login({ email, password });
      loginUser(data.token);
      navigate("/dashboard"); // נווט לדשבורד לאחר התחברות
    } catch (err) {
      setError(err.message);
    }
  };

  return (
    <div className="container">
    <form onSubmit={handleSubmit}>
      <h2>התחברות</h2>
      <input
        type="email"
        placeholder="אימייל"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        required
      />
      <input
        type="password"
        placeholder="סיסמה"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        required
      />
      <button type="submit">התחבר</button>
      {error && <p style={{ color: "red" }}>{error}</p>}
    </form>
    </div>
  );
};

export default Login;

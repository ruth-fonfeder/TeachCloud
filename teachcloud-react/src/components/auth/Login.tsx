import React, { useState } from "react";
import { login } from "../../api/authApi";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../hooks/useAuth"; // ✅ הוספנו

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();
  const { loginUser } = useAuth(); // ✅ הוספנו

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setError(null);

    console.log("Trying to login with:", { email, password });

    try {
      const res = await login({ email, password });
      console.log("Login response:", res);

      // ✅ עדכון ה־Context
      loginUser(res.token, res.role, res.fullName);

      // ניווט לפי תפקיד
      if (res.role === "Student") navigate("/student-area");
      else if (res.role === "Teacher") navigate("/teacher-area");
      else if (res.role === "Admin") navigate("/admin-area");
      else navigate("/");
    } catch (err) {
      console.error("Login error:", err);
      setError("אימייל או סיסמה שגויים");
    }
  };

  return (
    <div className="container" style={{ maxWidth: "400px", margin: "auto", direction: "rtl" }}>
      <form onSubmit={handleSubmit}>
        <h2 style={{ textAlign: "center" }}>התחברות</h2>

        <input
          type="email"
          placeholder="אימייל"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
          style={{ width: "100%", padding: "10px", margin: "8px 0" }}
        />

        <input
          type="password"
          placeholder="סיסמה"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
          style={{ width: "100%", padding: "10px", margin: "8px 0" }}
        />

        <button type="submit" style={{ width: "100%", padding: "10px", marginTop: "10px" }}>
          התחבר
        </button>

        {error && <p style={{ color: "red", textAlign: "center" }}>{error}</p>}
      </form>
    </div>
  );
};

export default Login;

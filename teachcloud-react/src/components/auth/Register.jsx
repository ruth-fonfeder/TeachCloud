import React, { useState } from "react";
import { register } from "../../api/authApi";
import { useNavigate } from "react-router-dom";

const Register = () => {
  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState(""); // ברירת מחדל ריקה
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(null);
    try {
      const numericRole = parseInt(role);
      const userType = numericRole === 2 ? "Student" : "Teacher"; // לפי enum שציינתי קודם

      const res = await register({
        fullName,
        email,
        password,
        role: numericRole,
        userType,
      });

      if (res.exists) {
        navigate("/");
      } else {
        navigate("/login");
      }
    } catch (err) {
      setError("התרחשה שגיאה בהרשמה");
    }
  };

  return (
    <div className="container" style={{ maxWidth: "400px", margin: "auto", direction: "rtl" }}>
      <form onSubmit={handleSubmit}>
        <h2 style={{ textAlign: "center" }}>הרשמה</h2>

        <input
          type="text"
          placeholder="שם מלא"
          value={fullName}
          onChange={(e) => setFullName(e.target.value)}
          required
          style={{ width: "100%", padding: "10px", margin: "8px 0", borderRadius: "4px" }}
        />

        <input
          type="email"
          placeholder="אימייל"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
          style={{ width: "100%", padding: "10px", margin: "8px 0", borderRadius: "4px" }}
        />

        <input
          type="password"
          placeholder="סיסמה"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
          style={{ width: "100%", padding: "10px", margin: "8px 0", borderRadius: "4px" }}
        />

        <select
          value={role}
          onChange={(e) => setRole(e.target.value)}
          required
          style={{ width: "100%", padding: "10px", margin: "8px 0", borderRadius: "4px" }}
        >
          <option value="" disabled hidden>בחר תפקיד</option>
          <option value="2">תלמיד</option>
          <option value="1">מורה</option>
        </select>

        <button type="submit" style={{ width: "100%", padding: "10px", marginTop: "10px", borderRadius: "4px" }}>
          הרשם
        </button>

        {error && <p style={{ color: "red", textAlign: "center" }}>{error}</p>}
      </form>
    </div>
  );
};

export default Register;

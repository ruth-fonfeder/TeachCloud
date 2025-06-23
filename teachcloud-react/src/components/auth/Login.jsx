// import React, { useState } from "react";
// import { login } from "../../api/authApi";
// import { useAuth } from "../../hooks/useAuth";
// import { useNavigate } from "react-router-dom";

// const Login = () => {
//   const [email, setEmail] = useState("");
//   const [password, setPassword] = useState("");
//   const [error, setError] = useState(null);
//   const { loginUser } = useAuth();
//   const navigate = useNavigate();

//   const handleSubmit = async (e) => {
//     e.preventDefault();
//     setError(null);
//     try {
//       const data = await login({ email, password });
//       loginUser(data.token);
//       navigate("/dashboard"); // נווט לדשבורד לאחר התחברות
//     } catch (err) {
//       setError(err.message);
//     }
//   };

//   return (
//     <div className="container">
//     <form onSubmit={handleSubmit}>
//       <h2>התחברות</h2>
//       <input
//         type="email"
//         placeholder="אימייל"
//         value={email}
//         onChange={(e) => setEmail(e.target.value)}
//         required
//       />
//       <input
//         type="password"
//         placeholder="סיסמה"
//         value={password}
//         onChange={(e) => setPassword(e.target.value)}
//         required
//       />
//       <button type="submit">התחבר</button>
//       {error && <p style={{ color: "red" }}>{error}</p>}
//     </form>
//     </div>
//   );
// };

// export default Login;

// import React, { useState } from "react";
// import { login } from "../../api/authApi";
// import { useNavigate } from "react-router-dom";

// const Login = () => {
//   const [email, setEmail] = useState("");
//   const [password, setPassword] = useState("");
//   const [error, setError] = useState(null);
//   const navigate = useNavigate();

//   const handleSubmit = async (e) => {
//     e.preventDefault();
//     setError(null);
//     try {
//       const res = await login({ email, password });

//       // שמירה ב-localStorage
//       localStorage.setItem("token", res.token || ""); // אם יש token
//       localStorage.setItem("role", res.role);
//       localStorage.setItem("fullName", res.fullName);

//       navigate("/dashboard"); // נווט לדף הראשי של המשתמש
//     } catch (err) {
//       setError("אימייל או סיסמה שגויים");
//     }
//   };

//   return (
//     <div className="container" style={{ maxWidth: "400px", margin: "auto", direction: "rtl" }}>
//       <form onSubmit={handleSubmit}>
//         <h2 style={{ textAlign: "center" }}>התחברות</h2>

//         <input
//           type="email"
//           placeholder="אימייל"
//           value={email}
//           onChange={(e) => setEmail(e.target.value)}
//           required
//           style={{ width: "100%", padding: "10px", margin: "8px 0" }}
//         />

//         <input
//           type="password"
//           placeholder="סיסמה"
//           value={password}
//           onChange={(e) => setPassword(e.target.value)}
//           required
//           style={{ width: "100%", padding: "10px", margin: "8px 0" }}
//         />

//         <button type="submit" style={{ width: "100%", padding: "10px", marginTop: "10px" }}>
//           התחבר
//         </button>

//         {error && <p style={{ color: "red", textAlign: "center" }}>{error}</p>}
//       </form>
//     </div>
//   );
// };

// export default Login;


import React, { useState } from "react";
import { login } from "../../api/authApi";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(null);
    try {
      const res = await login({ email, password });

      // שמירה ב-localStorage
      localStorage.setItem("token", res.token || "");
      localStorage.setItem("role", res.role);
      localStorage.setItem("fullName", res.fullName);

      // ניווט לפי תפקיד
      if (res.role === "Student") navigate("/student-area");
      else if (res.role === "Teacher") navigate("/teacher-area");
      else if (res.role === "Admin") navigate("/admin-area");
      else navigate("/"); // fallback
    } catch (err) {
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

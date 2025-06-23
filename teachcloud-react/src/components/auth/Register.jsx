// import React, { useState } from "react";
// import { register } from "../../api/authApi";
// import { useNavigate } from "react-router-dom";

// const Register = () => {
//   const [email, setEmail] = useState("");
//   const [password, setPassword] = useState("");
//   const [error, setError] = useState(null);
//   const navigate = useNavigate();

//   const handleSubmit = async (e) => {
//     e.preventDefault();
//     setError(null);
//     try {
//       await register({ email, password });
//       navigate("/login");
//     } catch (err) {
//       setError(err.message);
//     }
//   };

//   return (
//     <div className="container">
//     <form onSubmit={handleSubmit}>
//       <h2>הרשמה</h2>
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
//       <button type="submit">הרשם</button>
//       {error && <p style={{ color: "red" }}>{error}</p>}
//     </form>
//     </div>
//   );
// };

// export default Register;

import React, { useState } from "react";
import { register } from "../../api/authApi";
import { useNavigate } from "react-router-dom";

const Register = () => {
  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(null);
    try {
      const res = await register({ fullName, email, password });

      if (res.exists) {
        // אם המשתמש כבר קיים - לדף הבית
        navigate("/");
      } else {
        // אחרת - לדף התחברות
        navigate("/login");
      }
    } catch (err) {
      setError("התרחשה שגיאה בהרשמה");
    }
  };

  return (
    <div className="container">
    <form onSubmit={handleSubmit}>
      <h2>הרשמה</h2>
      <input
        type="text"
        placeholder="שם מלא"
        value={fullName}
        onChange={(e) => setFullName(e.target.value)}
        required
      />
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
      <button type="submit">הרשם</button>
      {error && <p style={{ color: "red" }}>{error}</p>}
    </form>
    </div>
  );
};

export default Register;

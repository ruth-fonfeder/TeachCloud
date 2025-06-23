// import React from "react";
// import { Routes, Route, Navigate } from "react-router-dom";
// import Login from "../components/auth/Login";
// import Register from "../components/auth/Register";
// import Home from "../pages/Home";
// import Dashboard from "../pages/Dashboard";
// import NotFound from "../pages/NotFound.jsx";
// import { useAuth } from "../hooks/useAuth";

// const PrivateRoute = ({ children }) => {
//   const { token } = useAuth();
//   return token ? children : <Navigate to="/login" replace />;
// };

// const AppRoutes = () => {
//   return (
//     <Routes>
//       <Route path="/" element={<Home />} />
//       <Route path="/login" element={<Login />} />
//       <Route path="/register" element={<Register />} />
//       <Route
//         path="/dashboard"
//         element={
//           <PrivateRoute>
//             <Dashboard />
//           </PrivateRoute>
//         }
//       />
//       <Route path="*" element={<NotFound />} />
//     </Routes>
//   );
// };

// export default AppRoutes;

import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Login from "../components/auth/Login";
import Register from "../components/auth/Register";
import Home from "../pages/Home";
import NotFound from "../pages/NotFound";
import StudentArea from "../pages/StudentArea";
import TeacherArea from "../pages/TeacherArea";
import AdminArea from "../pages/AdminArea";
import { useAuth } from "../hooks/useAuth";

// קומפוננטת Route פרטית שמגנה על עמודים
const PrivateRoute = ({ children }) => {
  const { token } = useAuth();
  return token ? children : <Navigate to="/login" replace />;
};

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />

      {/* אזורים אישיים מוגנים לפי תפקיד */}
      <Route
        path="/student-area"
        element={
          <PrivateRoute>
            <StudentArea />
          </PrivateRoute>
        }
      />
      <Route
        path="/teacher-area"
        element={
          <PrivateRoute>
            <TeacherArea />
          </PrivateRoute>
        }
      />
      <Route
        path="/admin-area"
        element={
          <PrivateRoute>
            <AdminArea />
          </PrivateRoute>
        }
      />

      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};

export default AppRoutes;

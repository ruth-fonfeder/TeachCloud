import React, {  ReactNode } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Home from "../pages/Home";
import NotFound from "../pages/NotFound";
import StudentArea from "../pages/StudentArea";
import AdminArea from "../pages/AdminArea";
import TeacherArea from "../pages/TeacherArea";
import TeacherCoursesPage from "../pages/Teachers/TeacherCoursesPage";
import { useAuth } from "../hooks/useAuth";
import Login from "../components/auth/Login";
import Register from "../components/auth/Register";
import GroupCoursesPage from "../pages/Teachers/GroupCoursesPage";
import TeacherGroupsPage from "../pages/Teachers/TeacherGroupsPage";


// קומפוננטת Route פרטית שמגנה על עמודים
const PrivateRoute = ({ children }: { children: ReactNode }) => {
  const { token } = useAuth();
  return token ? children : <Navigate to="/login" replace />;
};

const AppRoutes = () => {
  return (
    // <Routes>
    //   {/* דפים ציבוריים */}
    //   <Route path="/" element={<Home />} />
    //   <Route path="/login" element={<Login />} />
    //   <Route path="/register" element={<Register />} />

    //   {/* דפים מוגנים */}
    //   <Route
    //     path="/student-area"
    //     element={
    //       <PrivateRoute>
    //         <StudentArea />
    //       </PrivateRoute>
    //     }
    //   />
    //   <Route
    //     path="/admin-area"
    //     element={
    //       <PrivateRoute>
    //         <AdminArea />
    //       </PrivateRoute>
    //     }
    //   />
    //   <Route
    //     path="/teacher-area"
    //     element={
    //       <PrivateRoute>
    //         <TeacherArea />
    //       </PrivateRoute>
    //     }
    //   />
    //   <Route
    //     path="/teacher-area/courses"
    //     element={
    //       <PrivateRoute>
    //         <TeacherCoursesPage />
    //       </PrivateRoute>
    //     }
    //   />

    //   {/* דף 404 */}
    //   <Route path="*" element={<NotFound />} />
    // </Routes>

    <Routes>
  {/* דפים ציבוריים */}
  <Route path="/" element={<Home />} />
  <Route path="/login" element={<Login />} />
  <Route path="/register" element={<Register />} />

  {/* דפים מוגנים */}
  <Route
    path="/student-area"
    element={
      <PrivateRoute>
        <StudentArea />
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
  <Route
    path="/teacher-area"
    element={
      <PrivateRoute>
        <TeacherArea />
      </PrivateRoute>
    }
  />
  <Route
    path="/teacher-area/courses"
    element={
      <PrivateRoute>
        <TeacherCoursesPage />
      </PrivateRoute>
    }
  />
  <Route
    path="/teacher-area/groups"
    element={
      <PrivateRoute>
        <TeacherGroupsPage />
      </PrivateRoute>
    }
  />
  <Route
    path="/teacher-area/groups/:groupId/courses"
    element={
      <PrivateRoute>
        <GroupCoursesPage />
      </PrivateRoute>
    }
  />

  {/* דף 404 */}
  <Route path="*" element={<NotFound />} />
</Routes>

  );
};

export default AppRoutes;

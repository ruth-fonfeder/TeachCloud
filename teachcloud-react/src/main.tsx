
// import React from "react";
// import { createRoot } from "react-dom/client";
// import App from "./App";
// import "./index.css";
// import { AuthProvider } from "./context/AuthContext";


// const rootElement = document.getElementById("root");
// if (rootElement) {
//   createRoot(rootElement).render(
//     <React.StrictMode>
//        <AuthProvider>
//        <App />
//        </AuthProvider>
//     </React.StrictMode>
//   );
// } else {
//   console.error("Root element not found");
// // אם האלמנט root לא נמצא, יש להציג הודעת שגיאה
// if (!rootElement) {
//   throw new Error("אלמנט root לא נמצא בדף");
// }

import React from "react";
import { createRoot } from "react-dom/client";
import App from "./App";
import "./index.css";
import { AuthProvider } from "./context/AuthContext";

const rootElement = document.getElementById("root");

if (!rootElement) {
  throw new Error("אלמנט root לא נמצא בדף");
}

createRoot(rootElement).render(
  <React.StrictMode>
    <AuthProvider>
      <App />
    </AuthProvider>
  </React.StrictMode>
);

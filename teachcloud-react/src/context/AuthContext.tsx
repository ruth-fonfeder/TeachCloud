// import React, { createContext, useState, useEffect } from "react";

// export const AuthContext = createContext();

// export const AuthProvider = ({ children }) => {
//   const [token, setToken] = useState(localStorage.getItem("token"));
//   const [role, setRole] = useState(localStorage.getItem("role"));
//   const [fullName, setFullName] = useState(localStorage.getItem("fullName"));
//   const [isAuthenticated, setIsAuthenticated] = useState(!!token);

//   useEffect(() => {
//     if (token) {
//       localStorage.setItem("token", token);
//       setIsAuthenticated(true);
//     } else {
//       localStorage.removeItem("token");
//       setIsAuthenticated(false);
//     }

//     if (role) localStorage.setItem("role", role);
//     else localStorage.removeItem("role");

//     if (fullName) localStorage.setItem("fullName", fullName);
//     else localStorage.removeItem("fullName");
//   }, [token, role, fullName]);

//   const loginUser = (newToken, newRole, newFullName) => {
//     setToken(newToken);
//     setRole(newRole);
//     setFullName(newFullName);
//   };

//   const logoutUser = () => {
//     setToken(null);
//     setRole(null);
//     setFullName(null);
//   };

//   return (
//     <AuthContext.Provider value={{ token, role, fullName, isAuthenticated, loginUser, logoutUser }}>
//       {children}
//     </AuthContext.Provider>
//   );
// };


// import React, {
//   createContext,
//   useState,
//   useEffect,
//   ReactNode,
//   FC,
// } from "react";

// // נגדיר את הממשק של הקונטקסט
// interface AuthContextType {
//   token: string | null;
//   role: string | null;
//   fullName: string | null;
//   isAuthenticated: boolean;
//   loginUser: (token: string, role: string, fullName: string) => void;
//   logoutUser: () => void;
// }

// // ברירת מחדל כדי ש־createContext לא יתלונן
// export const AuthContext = createContext<AuthContextType>({
//   token: null,
//   role: null,
//   fullName: null,
//   isAuthenticated: false,
//   loginUser: () => {},
//   logoutUser: () => {},
// });

// // טיפוס לפרופס של AuthProvider
// interface AuthProviderProps {
//   children: ReactNode;
// }

// export const AuthProvider: FC<AuthProviderProps> = ({ children }) => {
//   const [token, setToken] = useState<string | null>(
//     localStorage.getItem("token")
//   );
//   const [role, setRole] = useState<string | null>(
//     localStorage.getItem("role")
//   );
//   const [fullName, setFullName] = useState<string | null>(
//     localStorage.getItem("fullName")
//   );
//   const [isAuthenticated, setIsAuthenticated] = useState<boolean>(!!token);

//   useEffect(() => {
//     if (token) {
//       localStorage.setItem("token", token);
//       setIsAuthenticated(true);
//     } else {
//       localStorage.removeItem("token");
//       setIsAuthenticated(false);
//     }

//     if (role) localStorage.setItem("role", role);
//     else localStorage.removeItem("role");

//     if (fullName) localStorage.setItem("fullName", fullName);
//     else localStorage.removeItem("fullName");
//   }, [token, role, fullName]);

//   const loginUser = (newToken: string, newRole: string, newFullName: string) => {
//     setToken(newToken);
//     setRole(newRole);
//     setFullName(newFullName);
//   };

//   const logoutUser = () => {
//     setToken(null);
//     setRole(null);
//     setFullName(null);
//   };

//   return (
//     <AuthContext.Provider
//       value={{
//         token,
//         role,
//         fullName,
//         isAuthenticated,
//         loginUser,
//         logoutUser,
//       }}
//     >
//       {children}
//     </AuthContext.Provider>
//   );
// };


import React, {
  createContext,
  useState,
  useEffect,
  ReactNode,
  FC,
  useContext,
} from "react";

// טיפוסים של הקונטקסט
interface AuthContextType {
  token: string | null;
  role: string | null;
  fullName: string | null;
  isAuthenticated: boolean;
  loginUser: (token: string, role: string, fullName: string) => void;
  logoutUser: () => void;
}

// יצירת הקונטקסט עם ערכים ברירת מחדל
export const AuthContext = createContext<AuthContextType>({
  token: null,
  role: null,
  fullName: null,
  isAuthenticated: false,
  loginUser: () => {},
  logoutUser: () => {},
});

// טיפוס לפרופס של AuthProvider
interface AuthProviderProps {
  children: ReactNode;
}

export const AuthProvider: FC<AuthProviderProps> = ({ children }) => {
  const [token, setToken] = useState<string | null>(
    localStorage.getItem("token")
  );
  const [role, setRole] = useState<string | null>(
    localStorage.getItem("role")
  );
  const [fullName, setFullName] = useState<string | null>(
    localStorage.getItem("fullName")
  );
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(!!token);

  useEffect(() => {
    if (token) {
      localStorage.setItem("token", token);
      setIsAuthenticated(true);
    } else {
      localStorage.removeItem("token");
      setIsAuthenticated(false);
    }

    role
      ? localStorage.setItem("role", role)
      : localStorage.removeItem("role");

    fullName
      ? localStorage.setItem("fullName", fullName)
      : localStorage.removeItem("fullName");
  }, [token, role, fullName]);

  const loginUser = (newToken: string, newRole: string, newFullName: string) => {
    setToken(newToken);
    setRole(newRole);
    setFullName(newFullName);
  };

  const logoutUser = () => {
    setToken(null);
    setRole(null);
    setFullName(null);
  };

  return (
    <AuthContext.Provider
      value={{ token, role, fullName, isAuthenticated, loginUser, logoutUser }}
    >
      {children}
    </AuthContext.Provider>
  );
};

// קריאה נוחה לקונטקסט
export const useAuth = () => useContext(AuthContext);

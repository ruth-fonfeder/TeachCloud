// import { useContext } from "react";
// import { AuthContext } from "../context/AuthContext";

// export const useAuth = () => {
//   return useContext(AuthContext);
// };


import { useContext } from "react";
import { AuthContext } from "../context/AuthContext";

// לא צריך להוסיף טיפוסים ידניים כאן, כי הם נלקחים אוטומטית מה־AuthContext
export const useAuth = () => useContext(AuthContext);

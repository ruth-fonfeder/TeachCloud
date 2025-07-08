// import axios from "axios";
// import { CreateGroupPayload, Group } from "../types/groupTypes";
// export const getTeacherGroups = async (): Promise<Group[]> => {
//   const response = await axios.get("/api/teachers/my/groups");
//   return response.data;
// };

// export const createGroup = async (payload: CreateGroupPayload): Promise<Group> => {
//   const response = await axios.post("/api/teachers/my/groups", payload);
//   return response.data;
// };

// export const deleteGroup = async (id: number): Promise<void> => {
//   await axios.delete(`/api/groups/${id}`);
// };


// import axios from "axios";
// import { CreateGroupPayload, Group } from "../types/groupTypes";

// export const getTeacherGroups = async (token: string): Promise<Group[]> => {
//   const response = await axios.get("/api/teachers/my/groups", {
//     headers: {
//       Authorization: `Bearer ${token}`,
//     },
//   });
//   return response.data;
// };

// export const createGroup = async (token: string, payload: CreateGroupPayload): Promise<Group> => {
//   const response = await axios.post("/api/teachers/my/groups", payload, {
//     headers: {
//       Authorization: `Bearer ${token}`,
//     },
//   });
//   return response.data;
// };

// export const deleteGroup = async (token: string, id: number): Promise<void> => {
//   await axios.delete(`/api/groups/${id}`, {
//     headers: {
//       Authorization: `Bearer ${token}`,
//     },
//   });
// };



// src/api/groupApi.ts


import axios from "axios";
import { Group } from "../types/groupTypes";

const API_URL = import.meta.env.VITE_API_URL;

export const getTeacherGroups = async (token: string): Promise<Group[]> => {
  const res = await axios.get(`${API_URL}/api/teacher/my/groups`, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });
  return res.data;
};

export const createGroup = async (token: string, payload: { name: string; courseId: number }): Promise<Group> => {
  const res = await axios.post(`${API_URL}/api/group`, payload, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });
  return res.data;
};

export const deleteGroup = async (token: string, id: number): Promise<void> => {
  await axios.delete(`${API_URL}/api/group/${id}`, {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });
};

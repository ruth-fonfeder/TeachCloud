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

export const createGroup = async (token: string, payload: { name: string }): Promise<Group> => {
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

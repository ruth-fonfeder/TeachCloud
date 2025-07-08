export type Group = {
    id: number;
    name: string;
    courseId: number;
    courseName: string;
  };
  
  export type CreateGroupPayload = {
    name: string;
    courseId: number;
  };
  
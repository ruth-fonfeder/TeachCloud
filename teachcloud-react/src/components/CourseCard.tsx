type Course = {
  name: string;
  description?: string;
};

const CourseCard = ({ course }: { course: Course }) => {
  return (
    <div className="border rounded p-4 shadow-sm bg-white">
      <h3 className="text-lg font-semibold">{course.name}</h3>
      <p className="text-sm text-gray-600">תיאור: {course.description}</p>
    </div>
  );
};
export default CourseCard;
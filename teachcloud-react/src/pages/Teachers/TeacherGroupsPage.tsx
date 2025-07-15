import React,{ useEffect, useState } from "react";
import { Group } from "../../types/groupTypes";
import { getTeacherGroups, createGroup, deleteGroup } from "../../api/groupApi";
import GroupCard from "../../components/GroupCard";
import { useAuth } from "../../hooks/useAuth";

const TeacherGroupsPage = () => {
  const { token } = useAuth();
  const [groups, setGroups] = useState<Group[]>([]);
  const [newGroupName, setNewGroupName] = useState("");
  const [showCreateForm, setShowCreateForm] = useState(false); // מצב פתיחת הטופס

  useEffect(() => {
    if (!token) return;
    loadGroups();
  }, [token]);

  const loadGroups = async () => {
    try {
      if (!token) return;
      const data = await getTeacherGroups(token);
      console.log("📥 קבוצות שהתקבלו מהשרת:", data);
      setGroups(data);
    } catch (error) {
      console.error("שגיאה בטעינת קבוצות", error);
    }
  };
  

  const handleCreate = async () => {
    if (!newGroupName.trim() || !token) return;
  
    const payload = {
      name: newGroupName,
      // courseId: 1, // ⚠️ שימי לב שה־ID הזה חייב להיות קיים ב־DB!
    };
    console.log("📤 שולחת קבוצה חדשה לשרת:", JSON.stringify(payload, null, 2));
    console.log("🔑 token לפני השליחה:", token);



    
  
    try {
      const newGroup = await createGroup(token, payload);
      console.log("✅ קיבלתי קבוצה חדשה מהשרת:", newGroup);
  
      setGroups([...groups, newGroup]);
      setNewGroupName("");
      setShowCreateForm(false); // סוגר את הטופס אחרי יצירה מוצלחת
    } catch (error) {

      console.error("❌ שגיאה בשליחת קבוצה לשרת", error);
    }
  };
  

  const handleDelete = async (id: number) => {
    if (!window.confirm("האם למחוק את הקבוצה?") || !token) return;

    try {
      await deleteGroup(token, id);
      setGroups(groups.filter((g) => g.id !== id));
    } catch (error) {
      console.error("שגיאה במחיקת קבוצה", error);
    }
  };

  return (
    <div>
      <h1 >😎 קבוצות הלימוד שלי</h1>

      <button
        onClick={() => {
          setShowCreateForm((prev) => {
        const next = !prev;
        if (!next) setNewGroupName(""); // מנקה את הקלט כשסוגרים
        return next;
          });
        }}
        style={{
          position: "fixed",
          top: "20px",
          right: "20px",
          backgroundColor: "#fe5ca8",
          color: "white",
          padding: "10px 20px",
          borderRadius: "8px",
          zIndex: 9999,
          display: "inline-block",
          width: "auto",
          maxWidth: "none",
        }}
      >
        {showCreateForm ? "✖️" : "➕ הוספת קבוצה"}
      </button>

      {showCreateForm && (
        <div className="container">
          <input
        type="text"
        placeholder="שם קבוצה חדשה"
        value={newGroupName}
        onChange={(e) => setNewGroupName(e.target.value)}
          />
          <button
        onClick={handleCreate}
        className="bg-green-600 text-white px-4 py-2 rounded hover:bg-green-700"
          >
        יצירה
          </button>
        </div>
      )}

      <div>
        {groups.map((group) => (
          <GroupCard key={group.id} group={group} onDelete={handleDelete} />
        ))}
      </div>
    </div>
  );
};

export default TeacherGroupsPage;
 
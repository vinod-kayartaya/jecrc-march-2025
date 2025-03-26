import React, { useState } from "react";
import { useDispatch } from "react-redux";

const TodoForm = () => {
  const [taskText, setTaskText] = useState("");
  const dispatch = useDispatch();

  const handleSubmit = (e) => {
    e.preventDefault();
    const taskText1 = taskText.trim();
    if (!taskText1) return;

    dispatch({ type: "ADD_TODO", payload: taskText1 });

    setTaskText("");
  };

  return (
    <>
      <h3>Add a new task</h3>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={taskText}
          onChange={(e) => setTaskText(e.target.value)}
          name="q"
          className="form-control"
          autoFocus
        />
      </form>
    </>
  );
};

export default TodoForm;

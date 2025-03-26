import React from "react";
import { useDispatch } from "react-redux";
import Swal from "sweetalert2";
import { toast } from "react-toastify";

const TodoItem = ({ task }) => {
  const dispatch = useDispatch();

  const deleteTodo = () => {
    // dispatch an action object, which has type='DELETE_TODO' and
    // payoad = task.id

    Swal.fire({
      title: "Are you sure to delete this task?",
      showDenyButton: true,
      confirmButtonText: "Yes",
      denyButtonText: "No",
    }).then((result) => {
      if (result.isConfirmed) {
        dispatch({ type: "DELETE_TODO", payload: task.id });
        toast.success("Task deleted!");
      }
    });
  };

  return (
    <li style={{ cursor: "pointer" }} className="list-group-item" key={task.id}>
      <span onClick={() => {}}>
        {task.completed ? <del>{task.text}</del> : <span>{task.text}</span>}
      </span>

      {/* When this button is clicked, we have to "dispatch" an action object */}
      <button
        onClick={deleteTodo}
        className="btn btn-link float-end text-danger"
      >
        <i className="bi bi-trash"></i>
      </button>
    </li>
  );
};

export default TodoItem;

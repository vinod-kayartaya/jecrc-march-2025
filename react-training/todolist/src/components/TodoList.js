import { useDispatch, useSelector } from "react-redux";
import TodoItem from "./TodoItem";
import Swal from "sweetalert2";
import { toast } from "react-toastify";

function TodoList() {
  // by doing the following, we are making this component, subscribed to
  // the store; any change of state in the redux store, will make this
  // component rerender itself
  const { tasks } = useSelector((state) => state.todoReducer);
  const dispatch = useDispatch();

  const deleteAllTasks = () => {
    Swal.fire({
      title: "Are you sure to delete all tasks?",
      showDenyButton: true,
      confirmButtonText: "Yes",
      denyButtonText: "No",
    }).then((result) => {
      if (result.isConfirmed) {
        dispatch({ type: "DELETE_ALL_TASKS" });
      }
    });
  };

  const deleteCompletedTasks = () => {
    Swal.fire({
      title: "Are you sure to delete completed tasks?",
      showDenyButton: true,
      confirmButtonText: "Yes",
      denyButtonText: "No",
    }).then((result) => {
      if (result.isConfirmed) {
        dispatch({ type: "DELETE_COMPLETED_TASKS" });
        toast.success("Completed tasks deleted!");
      }
    });
  };

  return (
    <>
      {tasks.length > 0 ? (
        <h3>Here are the tasks:</h3>
      ) : (
        <h3>You don't have any tasks!</h3>
      )}

      <div>
        {tasks.length === 0 || (
          <button
            onClick={deleteAllTasks}
            className="btn btn-link"
            style={{ paddingLeft: "0" }}
          >
            Delete all tasks
          </button>
        )}

        {1 > 0 && (
          <button onClick={deleteCompletedTasks} className="btn btn-link">
            Delete completed tasks
          </button>
        )}
      </div>

      {1 > 0 && (
        <div>
          <input
            type="checkbox"
            id="hideCompletedTasksCheckbox"
            value={false}
            checked={false}
            onChange={() => {}}
          />
          <label
            htmlFor="hideCompletedTasksCheckbox"
            style={{ cursor: "pointer" }}
            className="form-label ms-2"
          >
            Hide completed tasks ({1})
          </label>
        </div>
      )}
      <ul className="list-group">
        {tasks.map((t) => {
          if (false && t.completed) return;
          return <TodoItem task={t} />;
        })}
      </ul>
    </>
  );
}

export default TodoList;

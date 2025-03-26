const initialState = {
  tasks: [
    { id: 1, text: "Learn React", completed: false },
    { id: 2, text: "Attend global connect (cg)", completed: true },
    { id: 3, text: "Finish day 1 assignment", completed: true },
    { id: 4, text: "Take rest", completed: false },
  ],
};

// this function is always called by redux.
// when this is function is called, redux passes 2 parameters
// 1. the current state
// 2. an object called "action", which usually has two properties
//      1. type (for example, 'ADD_TODO', 'DELETE_TODO', 'SORT_TODO', 'TOGGLE_TODO')
//      2. payload (used for mutating the current state, based on the type)
// our job in the reducer is to mutate the state based on the action.type and
// return the new state back to the store.
// Whenever the state in the store changes, all components will be re-rendered
function todoReducer(state = initialState, action) {
  if (action.type === "ADD_TODO") {
    // action.payload is assumed to be a todoText
    const newTask = { id: Date.now(), text: action.payload, completed: false };
    return { tasks: [...state.tasks, newTask] };
  }

  if (action.type === "DELETE_TODO") {
    // action.payload is assumed to be the id of the task to be deleted
    const remainingTasks = state.tasks.filter((t) => t.id !== action.payload);
    return { tasks: remainingTasks };
  }

  if (action.type === "DELETE_ALL_TASKS") {
    return { tasks: [] };
  }

  if (action.type === "DELETE_COMPLETED_TASKS") {
    return { tasks: [...state.tasks.filter((t) => !t.completed)] };
  }
  return state;
}

export default todoReducer;

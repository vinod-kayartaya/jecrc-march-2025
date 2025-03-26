import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";

const root = ReactDOM.createRoot(document.getElementById("root"));

const title = "Learn React and Redux";
const subtitle = "by building a simple todo-appliation";
const year = 2025;
const org = "Capgemini";

root.render(<App title={title} subtitle={subtitle} year={year} org={org} />);

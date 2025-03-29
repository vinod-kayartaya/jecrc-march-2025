import logo from "./logo.svg";
import "./App.css";
import { useState } from "react";
import HeaderFc from "./components/HeaderFc";
import LoginForm from "./components/LoginForm";

function App() {
  const [headerShown, setHeaderShown] = useState(true);

  const toggleHeader = () => {
    setHeaderShown(!headerShown);
  };

  return (
    <div>
      <button onClick={toggleHeader}>
        {headerShown ? "Hide" : "Show"} header
      </button>
      {headerShown && <HeaderFc />}

      <LoginForm />
    </div>
  );
}

export default App;

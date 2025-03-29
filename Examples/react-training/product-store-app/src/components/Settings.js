import React from "react";
import { Link, Outlet } from "react-router-dom";

const Settings = () => {
  return (
    <>
      <Link className="btn btn-secondary" to="login">
        Login
      </Link>
      <Link className="btn btn-secondary" to="register">
        Register
      </Link>
      <div>
        <Outlet />
      </div>
    </>
  );
};

export default Settings;

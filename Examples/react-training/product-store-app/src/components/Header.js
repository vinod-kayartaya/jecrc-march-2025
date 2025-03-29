import React from "react";
import { Link } from "react-router-dom";

const Header = () => {
  return (
    <>
      <div className="alert alert-primary">
        <div className="container">
          <h1>Product catalog app</h1>
        </div>
      </div>

      <div className="container">
        <Link to="/" className="btn btn-primary">
          Home
        </Link>
        <Link to="/products" className="btn btn-primary">
          Products
        </Link>
        <Link to="/about" className="btn btn-primary">
          About us
        </Link>
        <Link to="/settings" className="btn btn-primary">
          Settings
        </Link>
      </div>
    </>
  );
};

export default Header;

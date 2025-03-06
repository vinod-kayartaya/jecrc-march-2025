import React from "react";
import Header from "./Header";
import Footer from "./Footer";
import { Outlet } from "react-router-dom";

const Layout = () => {
  return (
    <>
      <Header />
      <div className="container" style={{ minHeight: "500px" }}>
        {/* this is the place for components to be loaded based on the URL segment */}
        <Outlet>
          <h3>Welcome to the product catalog application</h3>
          <p className="lead">
            This is a sample application to explore react-routing
          </p>
        </Outlet>
      </div>
      <Footer />
    </>
  );
};

export default Layout;

import Header from "./components/Header";
import Footer from "./components/Footer";
import ClickCounter from "./components/ClickCounter";
import { useState } from "react";
import ContactList from "./components/ContactList";

function App() {
  return (
    <div>
      <Header />
      <div
        className="container"
        style={{
          minHeight: "500px",
        }}
      >
        <div className="row">
          <div className="col-6">
            <ContactList />
          </div>
          <div className="col-6">
            <h3>Contact form will be placed here</h3>
          </div>
        </div>
      </div>
      <Footer />
    </div>
  );
}

export default App;

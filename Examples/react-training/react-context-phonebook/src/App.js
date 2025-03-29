import React from "react";
import { ContactProvider } from "./context/ContactContext";
import AddContact from "./components/AddContact";
import ContactList from "./components/ContactList";
import Header from "./components/Header";

function App() {
  return (
    <ContactProvider>
      <div className="container py-5">
        <Header />
        <div className="row">
          <div className="col-md-4">
            <AddContact />
          </div>
          <div className="col-md-8">
            <ContactList />
          </div>
        </div>
      </div>
    </ContactProvider>
  );
}

export default App;

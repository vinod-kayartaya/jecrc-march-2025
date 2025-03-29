import React from "react";
import { useContacts } from "../context/ContactContext";

const Count = () => {
  const { contacts } = useContacts();
  return (
    <p className="lead text-center">You have {contacts.length} contacts</p>
  );
};

export default Count;

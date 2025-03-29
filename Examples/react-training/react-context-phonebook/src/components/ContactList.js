import React from "react";
import { useContacts } from "../context/ContactContext";
import ContactCard from "./ContactCard";
import Count from "./Count";

const ContactList = () => {
  const { contacts } = useContacts();

  if (contacts.length === 0) {
    return (
      <div className="alert alert-info" role="alert">
        No contacts found. Add some contacts to get started!
      </div>
    );
  }

  return (
    <div>
      <h3 className="mb-4">Contacts</h3>
      {contacts.map((contact) => (
        <ContactCard key={contact.id} contact={contact} />
      ))}

      <Count />
    </div>
  );
};

export default ContactList;

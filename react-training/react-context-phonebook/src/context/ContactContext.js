import React, { createContext, useContext, useState } from 'react';

// Create context
const ContactContext = createContext(undefined);

// Default contacts
const defaultContacts = [
  {
    id: '1',
    name: 'John Doe',
    email: 'john.doe@example.com',
    phone: '555-123-4567'
  },
  {
    id: '2',
    name: 'Jane Smith',
    email: 'jane.smith@example.com',
    phone: '555-987-6543'
  }
];

// Create provider component
export const ContactProvider = ({ children }) => {
  const [contacts, setContacts] = useState(defaultContacts);

  const addContact = (contact) => {
    const newContact = {
      ...contact,
      id: Date.now().toString(),
    };
    setContacts(prevContacts => [...prevContacts, newContact]);
  };

  const deleteContact = (id) => {
    setContacts(prevContacts => prevContacts.filter(contact => contact.id !== id));
  };

  return (
    <ContactContext.Provider value={{ contacts, addContact, deleteContact }}>
      {children}
    </ContactContext.Provider>
  );
};

// Create custom hook
export const useContacts = () => {
  const context = useContext(ContactContext);
  if (context === undefined) {
    throw new Error('useContacts must be used within a ContactProvider');
  }
  return context;
}; 
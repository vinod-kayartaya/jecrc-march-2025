import React from 'react';
import { useContacts } from '../context/ContactContext';

const ContactCard = ({ contact }) => {
  const { deleteContact } = useContacts();
  
  return (
    <div className="card mb-3">
      <div className="card-body">
        <div className="d-flex justify-content-between align-items-center">
          <h5 className="card-title">{contact.name}</h5>
          <button
            className="btn btn-link text-danger"
            onClick={() => deleteContact(contact.id)}
          >
            <i className="bi bi-trash"></i>
          </button>
        </div>
        <p className="card-text mb-1">
          <strong>Email:</strong> {contact.email}
        </p>
        <p className="card-text">
          <strong>Phone:</strong> {contact.phone}
        </p>
      </div>
    </div>
  );
};

export default ContactCard; 
import React, { useState, useRef } from "react";

const ContactForm = ({ addContact }) => {
  const [contact, setContact] = useState({
    name: "",
    email: "",
    phone: "",
    city: "",
  });
  const nameRef = useRef();

  // const changeHandler = (e) => {
  //   let { name, value } = e.target;
  //   setContact({ ...contact, [name]: value });
  // };

  const changeHandler = ({ target: { name, value } }) => {
    setContact({ ...contact, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    addContact(contact);
    // clear the content of the form elements
    setContact({
      name: "",
      email: "",
      phone: "",
      city: "",
    });
    // focus on the name field
    nameRef.current.focus();
  };

  return (
    <div className="mt-3">
      <h3>Add New Contact</h3>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label htmlFor="name" className="form-label">
            Name
          </label>
          <input
            ref={nameRef}
            autoFocus
            type="text"
            className="form-control"
            id="name"
            name="name"
            value={contact.name}
            onChange={changeHandler}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="email" className="form-label">
            Email
          </label>
          <input
            type="email"
            className="form-control"
            id="email"
            name="email"
            value={contact.email}
            onChange={changeHandler}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="phone" className="form-label">
            Phone
          </label>
          <input
            type="tel"
            className="form-control"
            id="phone"
            name="phone"
            value={contact.phone}
            onChange={changeHandler}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="city" className="form-label">
            City
          </label>
          <input
            type="text"
            className="form-control"
            id="city"
            name="city"
            value={contact.city}
            onChange={changeHandler}
          />
        </div>
        <button type="submit" className="btn btn-primary">
          Add Contact
        </button>
      </form>
    </div>
  );
};

export default ContactForm;

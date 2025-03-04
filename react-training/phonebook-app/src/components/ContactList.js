import React, { useState } from "react";

const initailContacts = [
  {
    id: 1,
    name: "Vinod",
    email: "vinod@vinod.co",
    city: "Bangalore",
    avatar: "https://avatars.githubusercontent.com/u/109946821?v=4",
  },
  { id: 2, name: "John", email: "john@xmpl.com", city: "Dallas", avatar: null },
  {
    id: 3,
    name: "Jane",
    email: "jane@xmpl.com",
    city: "New York",
    avatar: "",
  },
  {
    id: 4,
    name: "Shyam",
    email: "shyam@xmpl.com",
    city: "Shivamogga",
    avatar: null,
  },
];

const ContactList = () => {
  const [contacts, setContacts] = useState(initailContacts);

  const deleteContact = (id) => {
    if (!window.confirm("Are you sure?")) return;

    const remainingContacts = contacts.filter((c) => c.id !== id);
    setContacts(remainingContacts);
  };

  const contactsJsx = contacts.map((c) => (
    <tr className="contactRow" key={c.id}>
      <td>{c.id}</td>
      <td>
        <img
          style={{ height: "50px", width: "50px", borderRadius: "50%" }}
          src={c.avatar ? c.avatar : "/default-profile.png"}
          alt={c.name}
          title={c.name}
          className="img-thumbnail"
        />{" "}
        {c.name}
      </td>
      <td>{c.email}</td>
      <td>{c.city}</td>
      <td>
        <button
          onClick={() => deleteContact(c.id)}
          className="btnDeleteContact btn btn-link text-danger bi bi-person-x-fill"
        ></button>
      </td>
    </tr>
  ));

  return (
    <div>
      <table className="table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Email</th>
            <th>City</th>
            <th></th>
          </tr>
        </thead>
        <tbody>{contactsJsx}</tbody>
      </table>
    </div>
  );
};

export default ContactList;

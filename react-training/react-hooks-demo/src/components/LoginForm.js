import React, { useEffect, useState } from "react";

const LoginForm = () => {
  const [name, setName] = useState("");
  const [city, setCity] = useState("");

  console.log("LoginForm component rendered at", new Date());

  useEffect(() => {
    console.log("LoginForm is now mounted");
  }, []);

  useEffect(() => {
    console.log("Some state changed in component at", new Date());
  });

  //   useEffect(() => {
  //     console.log("useEffect for `name` called");
  //   }, [name]);

  //   useEffect(() => {
  //     console.log("useEffect for `city` called");
  //   }, [city]);

  return (
    <>
      <h3>Login required</h3>

      <form>
        <div>
          {" "}
          <label htmlFor="name">Name: </label>
          <input
            type="text"
            name="name"
            id="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </div>
        <div>
          {" "}
          <label htmlFor="city">City: </label>
          <input
            type="text"
            city="city"
            id="city"
            value={city}
            onChange={(e) => setCity(e.target.value)}
          />
        </div>
      </form>
    </>
  );
};

export default LoginForm;

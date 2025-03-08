import React, { useEffect, useState } from "react";

const App = () => {
  console.log("App component is rendered at", new Date());
  const [products, setProducts] = useState([]);

  // this hook is a lifecycle methods;
  // [] indicates that this has to be executed only once
  // equivalent of "componentDidMount" lifecycle method of class components

  useEffect(() => {
    fetch("https://fakestoreapi.com/products")
      .then((resp) => resp.json())
      .then((products) => setProducts(products));
  }, []); // the effect (callback function) is executed exactly once when the
  // component is loaded for the first time.

  return (
    <>
      <h3>Product list</h3>

      <ul>
        {products.map((p) => (
          <li key={p.id}>{p.title}</li>
        ))}
      </ul>
    </>
  );
};

export default App;

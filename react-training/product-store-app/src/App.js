import { BrowserRouter, Route, Routes } from "react-router-dom";
import Layout from "./components/Layout";
import ProductCatalog from "./components/ProductCatalog";
import About from "./components/About";
import Login from "./components/Login";
import Register from "./components/Register";
import Settings from "./components/Settings";

// npm install react-router-dom

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route path="products" element={<ProductCatalog />} />
          <Route path="about" element={<About />} />
          <Route path="settings" element={<Settings />}>
            <Route path="login" element={<Login />} />
            <Route path="register" element={<Register />} />
          </Route>

          <Route
            path="*"
            element={
              <div>
                <h3 className="text-warning">OOPS!</h3>
                <p className="lead">
                  the page you are trying to access is not valid.
                </p>
              </div>
            }
          />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;

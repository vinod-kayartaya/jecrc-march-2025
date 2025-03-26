const Header = function ({ title, subtitle }) {
  return (
    <>
      <div className="alert alert-info">
        <div className="container">
          <h1>{title}</h1>
        </div>
      </div>
      <div className="container">
        <p className="lead">{subtitle}</p>
      </div>
    </>
  );
};

export default Header;

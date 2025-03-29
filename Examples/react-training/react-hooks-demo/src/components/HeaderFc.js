import React, { useEffect, useState } from "react";

const HeaderFc = () => {
  // the component method itself is equivalent of render() method class component
  console.log("HeaderFC rendered at", new Date());

  const [currentTime, setCurrentTime] = useState(new Date().toISOString());
  // this is a lifecycle method
  // useEffect(() => {}, []);

  // useEffect takes 1 or 2 parameters
  // 1st one is called the side-effect to be executed
  // 2nd is the list of dependencies

  // method-1
  // useEffect(()=>{}, [])  // empty array for dependencies
  // the effect is execued exactly once when the component is mounted (after the UI is produced)

  // method-2
  // useEffect(()=>{})
  // executed everytime there is any change in state or props of this component

  // method-3
  // useEffect(()=>{}, [x, y]) // the effect is executed only when x or y changes

  // equivalent of componentDidMount
  useEffect(() => {
    console.log("HeaderFc component mounted successfully");
    const intervalId = setInterval(() => {
      setCurrentTime(new Date().toISOString());
    }, 1000);

    // this effect can return a value
    // which has to be a function, which is equivalent of componentWillUnmount()

    return () => {
      console.log("HeaderFc component unmounted successfully");
      clearInterval(intervalId);
    };
  }, []);

  return (
    <>
      <h1>Functional component example</h1>
      <h3>{currentTime}</h3>
    </>
  );
};

export default HeaderFc;

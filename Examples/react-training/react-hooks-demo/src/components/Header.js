import React, { Component } from "react";

export default class Header extends Component {
  constructor() {
    super();
    console.log("Header() constructor called at", new Date());
  }

  componentDidMount() {
    console.log("Header.componentDidMount() called at", new Date());
  }

  componentWillUnmount() {
    console.log("Header.componentWillUnmount() called at", new Date());
  }

  // this is a life-cycle method of the class component
  // which is executed whenver the component is rendered
  render() {
    console.log("Header.render() called at", new Date());
    return <h1>Hooks demo</h1>;
  }
}

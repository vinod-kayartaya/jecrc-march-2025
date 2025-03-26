import { Component } from "react";

export default class Footer extends Component {
  // a class component must implement a function called 'render'
  // which must return a JSX

  render() {
    return (
      <div className="text-center">
        &copy; {this.props.year || 2025} - All rights reserved by{" "}
        <a href="https://vinod.co">{this.props.org || "Learn with Vinod"}</a>
      </div>
    );
  }
}

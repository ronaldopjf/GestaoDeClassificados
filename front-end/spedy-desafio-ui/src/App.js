import React, { Component } from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";

import AddClassified from "./components/add-classified.component";
import Classified from "./components/classified.component";
import ClassifiedsList from "./components/classifieds-list.component";

class App extends Component {
  render() {
    return (
      <Router>
        <nav className="navbar navbar-expand navbar-dark bg-dark">
          <Link to={"/classifieds"} className="navbar-brand">
            Spedy
          </Link>
          <div className="navbar-nav mr-auto">
            <li className="nav-item">
              <Link to={"/classifieds"} className="nav-link">
                Home
              </Link>
            </li>
          </div>
        </nav>

        <div className="container mt-3">
          <Switch>
            <Route exact path={["/", "/classifieds"]} component={ClassifiedsList} />
            <Route exact path="/add" component={AddClassified} />
            <Route path="/classifieds/:id" component={Classified} />
          </Switch>
        </div>
      </Router>
    );
  }
}

export default App;
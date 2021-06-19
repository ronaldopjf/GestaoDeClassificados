import React, { Component } from "react";
import { connect } from "react-redux";
import Moment from 'moment';
import { Link } from "react-router-dom";

import { retrieveClassifieds, findClassifiedsByTitle, deleteAllClassifieds } from "../actions/classifieds";

class ClassifiedsList extends Component {
    constructor(props) {
        super(props);
        this.onChangeSearchTitle = this.onChangeSearchTitle.bind(this);
        this.refreshData = this.refreshData.bind(this);
        this.setActiveClassified = this.setActiveClassified.bind(this);
        this.findByTitle = this.findByTitle.bind(this);
        this.removeAllClassifieds = this.removeAllClassifieds.bind(this);

        this.state = {
            currentClassified: null,
            currentIndex: -1,
            searchTitle: "",
        };
    }

    componentDidMount() {
        this.props.retrieveClassifieds();
    }

    onChangeSearchTitle(e) {
        const searchTitle = e.target.value;

        this.setState({
            searchTitle: searchTitle,
        });
    }

    refreshData() {
        this.setState({
            currentClassified: null,
            currentIndex: -1,
        });
    }

    setActiveClassified(classified, index) {
        this.setState({
            currentClassified: classified,
            currentIndex: index,
        });
    }

    removeAllClassifieds() {
        this.props
            .deleteAllClassifieds()
            .then((response) => {
                console.log(response);
                this.refreshData();
            })
            .catch((e) => {
                console.log(e);
            });
    }

    findByTitle() {
        this.refreshData();

        this.props.findClassifiedsByTitle(this.state.searchTitle);
    }

    render() {
        Moment.locale('pt-br');
        const { searchTitle, currentIndex } = this.state;
        const { classifieds } = this.props;
        classifieds.sort((a, b) => b.date > a.date ? 1 : -1);

        return (
            <div className="list row">
                <div className="col-md-8">
                    <div className="input-group mb-3">
                        <input
                            type="text"
                            className="form-control"
                            placeholder="Pesquisa por título..."
                            value={searchTitle}
                            onChange={this.onChangeSearchTitle}
                        />
                        <div className="input-group-append">
                            <button
                                className="btn btn-secondary"
                                type="button"
                                onClick={this.findByTitle}
                            >
                                Procurar
                            </button>
                        </div>
                    </div>
                </div>
                <div className="list row">
                    <div className="col-md-6">
                        <h4>Classificados</h4>
                    </div>
                    <div className="col-md-6 d-flex flex-row-reverse">
                        <Link
                            to="/Add"
                            className="btn btn-sm"
                            style={{ backgroundColor: "gray" }}>
                            + Novo classificado
                        </Link>
                    </div>
                </div>
                {classifieds && classifieds.map((classified, index) => (
                    <div
                        className="card d-flex justify-content-center"
                        style={{ width: "18rem", backgroundColor: "gray", margin: "1em" }}
                        className={"list-group-item " + (index === currentIndex ? "active" : "")}
                        onClick={() => this.setActiveClassified(classified, index)}
                        key={index}
                    >
                        <div className="card-body">
                            <h5 className="card-title classified-title">{classified.title}</h5>
                            <h6 className="card-subtitle mb-2">{Moment(classified.date).format("DD/MM/YYYY")}</h6>
                            <p className="card-text">{classified.description}</p>

                            <Link
                                to={"/classifieds/" + classified.id}
                                className="btn btn-sm btn-dark"
                            >
                                Ações
                            </Link>
                        </div>
                    </div>
                ))}

                <p style={{ backgroundColor: "gray", margin: "1em" }}>
                    <strong>
                        {classifieds.filter(member => member).length} classificados
                    </strong>
                </p>

            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        classifieds: state.classifieds,
    };
};

export default connect(mapStateToProps, { retrieveClassifieds, findClassifiedsByTitle, deleteAllClassifieds, })(ClassifiedsList);
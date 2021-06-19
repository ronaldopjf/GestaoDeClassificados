import React, { Component } from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";

import { createClassified } from "../actions/classifieds";

class AddClassified extends Component {
    constructor(props) {
        super(props);
        this.onChangeTitle = this.onChangeTitle.bind(this);
        this.onChangeDescription = this.onChangeDescription.bind(this);
        this.saveClassified = this.saveClassified.bind(this);
        this.newClassified = this.newClassified.bind(this);

        this.state = {
            id: null,
            title: "",
            description: "",
            date: null,
            active: null,
            published: false,
            submitted: false
        };
    }

    onChangeTitle(e) {
        this.setState({
            title: e.target.value,
        });
    }

    onChangeDescription(e) {
        this.setState({
            description: e.target.value,
        });
    }

    saveClassified() {
        const { title, description } = this.state;

        this.props
            .createClassified(title, description)
            .then((data) => {
                this.setState({
                    id: data.id,
                    title: data.title,
                    description: data.description,
                    date: data.date,
                    active: data.active,
                    published: data.published,
                    submitted: true
                });
                console.log(data);
            })
            .catch((e) => {
                console.log(e);
            });
    }

    newClassified() {
        this.setState({
            id: null,
            title: "",
            description: "",
            date: null,
            active: null,
            published: false,
            submitted: false
        });
    }

    render() {
        return (
            <div className="submit-form">
                <h4>Adicionar classificado</h4>
                {this.state.submitted ? (
                    <div>
                        <h4>Registro realizado com sucesso!</h4>
                        <button className="btn btn-success" onClick={this.newClassified}>
                            Adicionar
                        </button>
                    </div>
                ) : (
                    <div>
                        <div className="form-group">
                            <label htmlFor="title">Título</label>
                            <input
                                type="text"
                                className="form-control"
                                id="title"
                                name="title"
                                placeholder="Entre com o título..."
                                required
                                value={this.state.title}
                                onChange={this.onChangeTitle}
                            />
                        </div>

                        <div className="form-group">
                            <label htmlFor="description">Descrição</label>
                            <input
                                type="text"
                                className="form-control"
                                id="description"
                                name="description"
                                placeholder="Entre com a descrição..."
                                required
                                value={this.state.description}
                                onChange={this.onChangeDescription}
                            />
                        </div>

                        <Link
                            to="/"
                            className="btn btn-sm btn-warning"
                            style={{ margin: ".5em" }}
                        >
                            Voltar
                        </Link>
                        <button
                            type="submit"
                            className="btn btn-sm btn-success"
                            style={{ margin: ".5em" }}
                            onClick={this.saveClassified}
                        >
                            Enviar
                        </button>
                    </div>
                )}
            </div>
        );
    }
}

export default connect(null, { createClassified })(AddClassified);
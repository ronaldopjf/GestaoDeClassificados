import React, { Component } from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";

import { updateClassified, deleteClassified } from "../actions/classifieds";
import ClassifiedService from "../services/classified.service";

class Classified extends Component {
    constructor(props) {
        super(props);
        this.onChangeTitle = this.onChangeTitle.bind(this);
        this.onChangeDescription = this.onChangeDescription.bind(this);
        this.getClassified = this.getClassified.bind(this);
        this.updateStatus = this.updateStatus.bind(this);
        this.updateContent = this.updateContent.bind(this);
        this.removeClassified = this.removeClassified.bind(this);

        this.state = {
            currentClassified: {
                id: null,
                title: "",
                description: "",
                date: null,
                active: null,
                published: false
            },
            message: "",
        };
    }

    componentDidMount() {
        this.getClassified(this.props.match.params.id);
    }

    onChangeTitle(e) {
        const title = e.target.value;

        this.setState(function (prevState) {
            return {
                currentClassified: {
                    ...prevState.currentClassified,
                    title: title,
                },
            };
        });
    }

    onChangeDescription(e) {
        const description = e.target.value;

        this.setState((prevState) => ({
            currentClassified: {
                ...prevState.currentClassified,
                description: description,
            },
        }));
    }

    getClassified(id) {
        ClassifiedService.get(id)
            .then((response) => {
                this.setState({
                    currentClassified: response.data,
                });
                console.log(response.data);
            })
            .catch((e) => {
                console.log(e);
            });
    }

    updateStatus(status) {
        var data = {
            id: this.state.currentClassified.id,
            title: this.state.currentClassified.title,
            description: this.state.currentClassified.description,
            date: this.state.currentClassified.date,
            active: this.state.currentClassified.active,
            published: status
        };

        this.props
            .updateClassified(this.state.currentClassified.id, data)
            .then((reponse) => {
                console.log(reponse);

                this.setState((prevState) => ({
                    currentClassified: {
                        ...prevState.currentClassified,
                        published: status,
                    },
                }));

                this.setState({ message: "O status foi atualizado com sucesso!" });
            })
            .catch((e) => {
                console.log(e);
            });
    }

    updateContent() {
        this.props
            .updateClassified(this.state.currentClassified.id, this.state.currentClassified)
            .then((reponse) => {
                console.log(reponse);

                this.setState({ message: "O classificado foi atualizado com sucesso!" });
            })
            .catch((e) => {
                console.log(e);
            });
    }

    removeClassified() {
        this.props
            .deleteClassified(this.state.currentClassified.id)
            .then(() => {
                this.props.history.push("/classifieds");
            })
            .catch((e) => {
                console.log(e);
            });
    }

    render() {
        const { currentClassified } = this.state;

        return (
            <div>
                {currentClassified ? (
                    <div className="edit-form">
                        <h4>Classificado</h4>
                        <form>
                            <div className="form-group">
                                <label htmlFor="title">Título</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    id="title"
                                    value={currentClassified.title}
                                    onChange={this.onChangeTitle}
                                />
                            </div>
                            <div className="form-group">
                                <label htmlFor="description">Descrição</label>
                                <input
                                    type="text"
                                    className="form-control"
                                    id="description"
                                    value={currentClassified.description}
                                    onChange={this.onChangeDescription}
                                />
                            </div>

                            <div className="form-group">
                                <label>
                                    <strong>Status:</strong>
                                </label>{' '}
                                {currentClassified.published ? "Publicado" : "Pendente"}
                            </div>
                        </form>

                        <Link
                            to="/"
                            className="btn btn-sm btn-warning"
                            style={{ margin: ".5em" }}
                        >
                            Voltar
                        </Link>
                        {currentClassified.published ? (
                            <button
                                className="btn btn-sm btn-primary"
                                style={{ margin: ".5em" }}
                                onClick={() => this.updateStatus(false)}
                            >
                                Cancelar Publicação
                            </button>
                        ) : (
                            <button
                                className="btn btn-sm btn-primary"
                                style={{ margin: ".5em" }}
                                onClick={() => this.updateStatus(true)}
                            >
                                Publicar
                            </button>
                        )}
                        <button
                            className="btn btn-sm btn-danger"
                            style={{ margin: ".5em" }}
                            onClick={this.removeClassified}
                        >
                            Excluir
                        </button>
                        <button
                            type="submit"
                            className="btn btn-sm btn-success"
                            style={{ margin: ".5em" }}
                            onClick={this.updateContent}
                        >
                            Atualizar
                        </button>
                        <p style={{ color: "green" }}>{this.state.message}</p>
                    </div>
                ) : (
                    <div>
                        <br />
                        <p>Por favor, clique em um classificado...</p>
                    </div>
                )
                }
            </div>
        );
    }
}

export default connect(null, { updateClassified, deleteClassified })(Classified);
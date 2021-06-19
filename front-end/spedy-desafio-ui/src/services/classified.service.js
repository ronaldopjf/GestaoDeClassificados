import http from "../http-common";

class ClassifiedService {
    getAll() {
        return http.get("/classified");
    }

    get(id) {
        return http.get(`/classified/${id}`);
    }

    create(data) {
        return http.post("/classified", data);
    }

    update(id, data) {
        return http.put("/classified", data);
    }

    delete(id) {
        return http.delete(`/classified/${id}`);
    }

    deleteAll() {
        return http.delete(`/classified`);
    }

    findByTitle(title) {
        return http.get(`/classified/title/${title}`, null);
    }
}

export default new ClassifiedService();
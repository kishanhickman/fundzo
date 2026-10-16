import axios from "axios";

const API_URL = "https://fundzoapi.azurewebsites.net/api/Authenticate/";

const register = (username, email, password, firstName, lastName, country, zipCode) => {
    return axios.post(API_URL + "register", {
        username,
        email,
        password,
        firstName,
        lastName,
        country,
        zipCode,
    });
};

const login = (username, password) => {
    return axios.post(API_URL + "login", {
        username,
        password,
    })
    .then((response) => {
        if (response.data.token) {
            localStorage.setItem("user", JSON.stringify(response.data));
        }
        return response.data;
    });
};

const logout = () => {
    localStorage.removeItem("user");
};

const exportedObject = {
    register,
    login,
    logout,
}

export default exportedObject;
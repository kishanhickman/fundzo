import http from "./http-common";

const getAllCategories = () => {
    return http.get("/Admin/Category");
};

const getAllOrganisations = () => {
    return http.get("/Admin/Organisation");
};

const getAllCurrencies = () => {
    return http.get("/Admin/Currency");
};

const getAllCountries = () => {
    return http.get("/Admin/Country");
};

const AdminService = {
    getAllCategories,
    getAllOrganisations,
    getAllCurrencies,
    getAllCountries,
};

export default AdminService;
import http from "./http-common";

const create = data => {
    return http.post("/Fundraiser", data);
};

const getAllFundraisers = () => {
    return http.get("/Fundraiser");
};

const getAllFundraiserTypes = () => {
    return http.get("/Fundraiser/FundraiserType");
};

const updateFundraiser = (id, staticMediaId, fundraiserMediaId, data) => {
    return http.put(`/Fundraiser/${id}?staticMediaId=${staticMediaId}&fundraiserMediaId=${fundraiserMediaId}`, data);
};

const FundraiserService = {
    create,
    getAllFundraisers,
    getAllFundraiserTypes,
    updateFundraiser,
};

export default FundraiserService;
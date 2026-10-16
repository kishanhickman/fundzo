import http from "./http-common";

const getUserById = (id) => {
    return http.get(`/User/${id}`);
};

const FundraiserService = {
    getUserById,
};

export default FundraiserService;
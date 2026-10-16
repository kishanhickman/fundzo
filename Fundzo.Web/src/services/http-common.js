import axios from "axios";

export default axios.create({
    baseURL: "https://fundzoapi.azurewebsites.net/api",
    headers: {
        "Content-type": "application/json"
    }
});

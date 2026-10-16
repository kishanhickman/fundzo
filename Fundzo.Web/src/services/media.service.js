import http from "./http-common";

export const uploadFile = (files) => {
    const formData = new FormData();

    formData.append("files", files);

    return http.post("/StaticMedia/UploadFile", formData, {
        headers: {
            "Content-Type": "multipart/form-data",
        }
    });
};
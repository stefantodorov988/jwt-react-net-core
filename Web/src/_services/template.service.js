export const templateService = {
    getValues,
};

function getValues() {
    return window.api.get("/values")
        .then(values => {
            return values;
        });
}
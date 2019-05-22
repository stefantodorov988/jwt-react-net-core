export const statisticsService = {
    getStatistics,
    alertVisit,
};

function getStatistics() {
    return window.api.get("/statistics")
        .then(values => {
            return values;
        });
}
function alertVisit(ip){
    return window.api.post("/statistics/alertvisit",{ip : ip}).
        then(result =>{
            return result
        })
}
app.service("APIService", function ($http) {
    this.getEmpl = function () {
        return $http.get("api/Employees")
    }
});

app.service("customerAppService", function ($http) {

    //Get all customers
    this.getCustomers = function () {
        return $http.get("../Home/RetrieveAllCustomers");
    };

    //Get customer by id
    this.getCustomer = function (customerId) {
        var response = $http({
            method: "post",
            url: "../Home/GetCustomerByID",
            params: {
                id: JSON.stringify(customerId)
            }
        });
        return response;
    }

    //Update customer details
    this.updateCustomer = function (customer) {
        var response = $http({
            method: "post",
            url: "../Home/UpdateCustomer",
            data: JSON.stringify(customer),
            dataType: "json"
        });
        return response;
    }

    //Add new customer
    this.addCustomer = function (customer) {
        var response = $http({
            method: "post",
            url: "../Home/AddCustomer",
            data: JSON.stringify(customer),
            dataType: "json"
        });
        return response;
    }

    //Delete customer
    this.deleteCustomer = function (customerId) {
        var response = $http({
            method: "post",
            url: "../Home/DeleteCustomer",
            params: {
                id: JSON.stringify(customerId)
            }
        });
        return response;
    }
});
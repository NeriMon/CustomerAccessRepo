app.controller("customerAccessCtrl", function ($scope, $filter, customerAppService) {
    $scope.divCustomer = false;
    RetrieveAllCustomers();
   
    //Get all customers
    function RetrieveAllCustomers() {
        debugger;
        var getCustomerData = customerAppService.getCustomers();
        getCustomerData.then(function (customer) {
            $scope.customers = customer.data;
        }, function () {
            alert('Error in getting customer records.');
        });
    }
   
    //Onclick of edit button
    $scope.EditCustomer = function (customer) {
        var getCustomerData = customerAppService.getCustomer(customer.ID);
        getCustomerData.then(function (_customer) {
            $scope.customer = _customer.data;
            $scope.CustomerID = customer.ID;
            $scope.LastName = customer.LastName;
            $scope.FirstName = customer.FirstName;
            $scope.BirthDate = $filter('jsDate')(customer.BirthDate, "yyyy-MM-dd");
            $scope.Action = "Update";
            $scope.divCustomer = true;
        }, function () {
            alert('Error in getting customer record.');
        });
    }

    //Add/Update Customer
    $scope.AddUpdateCustomer = function () {
        var Customer = {
            ID : $scope.CustomerID,
            LastName: $scope.LastName,
            FirstName: $scope.FirstName,
            BirthDate: $scope.BirthDate
        };
        var getCustomerAction = $scope.Action;

        if (getCustomerAction == "Update") {
            var getCustomerData = customerAppService.updateCustomer(Customer);
            getCustomerData.then(function (msg) {
                RetrieveAllCustomers();
                alert(msg.data);
                $scope.divCustomer = false;
            }, function () {
                alert('Error in updating customer record.');
            });
        } else {
            var getCustomerData = customerAppService.addCustomer(Customer);
            getCustomerData.then(function (msg) {
                RetrieveAllCustomers();
                alert(msg.data);
                $scope.divCustomer = false;
            }, function () {
                alert('Error in adding customer record.');
            });
        }
    }

    //Delete customer
    $scope.DeleteCustomer = function (customer) {
        var getCustomerData = customerAppService.deleteCustomer(customer.ID);
        getCustomerData.then(function (msg) {
            alert(msg.data);
            RetrieveAllCustomers();
        }, function () {
            alert('Error in deleting customer record.');
        });
    }

    $scope.AddCustomerDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divCustomer = true;
        $scope.CustomerID = 0; //Set id to 0 for add
    }

    //Clear Add/Update form fields
    function ClearFields() {
        $scope.customerId = "";
        $scope.LastName = "";
        $scope.FirstName = "";
        $scope.BirthDate = "";
    }

    //Onclick on cancel button in Add/Update function
    $scope.Cancel = function () {
        $scope.divCustomer = false;
    };

    /*
    *   Datepicker 
    */
    $scope.today = function () {
        $scope.BirthDate = new Date();
    };
    $scope.today();

    $scope.clear = function () {
        $scope.BirthDate = null;
    };

    $scope.inlineOptions = {
        customClass: getDayClass,
        minDate: new Date(),
        showWeeks: true
    };

    $scope.dateOptions = {
        startingDay: 1
    };

    $scope.toggleMin = function () {
        $scope.inlineOptions.minDate = $scope.inlineOptions.minDate ? null : new Date();
        $scope.dateOptions.minDate = $scope.inlineOptions.minDate;
    };

    $scope.toggleMin();

    $scope.openDatepicker = function () {
        $scope.datepicker.opened = true;
    };


    $scope.setDate = function (year, month, day) {
        $scope.dt = new Date(year, month, day);
    };

    $scope.formats = ['MMMM dd, yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'longDate'];
    $scope.format = $scope.formats[0];
    $scope.altInputFormats = ['M!/d!/yyyy'];

    $scope.datepicker = {
        opened: false
    };
 
    var tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);
    var afterTomorrow = new Date();
    afterTomorrow.setDate(tomorrow.getDate() + 1);
    $scope.events = [
      {
          date: tomorrow,
          status: 'full'
      },
      {
          date: afterTomorrow,
          status: 'partially'
      }
    ];

    function getDayClass(data) {
        var date = data.date,
          mode = data.mode;
        if (mode === 'day') {
            var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

            for (var i = 0; i < $scope.events.length; i++) {
                var currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                if (dayToCheck === currentDay) {
                    return $scope.events[i].status;
                }
            }
        }

        return '';
    }

    
});

//Format date displayed
app.filter("jsDate", function () {
    return function (x) {
        return new Date(parseInt(x.substr(6)));
    }
});

//On delete click
app.directive('ngReallyClick', [
    function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                element.bind('click', function () {
                    var message = attrs.ngReallyMessage;
                    if (message && confirm(message)) {
                        scope.$apply(attrs.ngReallyClick);
                    }
                });
            }
        }
    }]);

//Set focus on input on Add/Edit click
app.directive('showFocus', function ($timeout) {
    return function (scope, element, attrs) {
        scope.$watch(attrs.showFocus,
          function (newValue) {
              $timeout(function () {
                  newValue && element[0].focus();
              });
          }, true);
    };
});


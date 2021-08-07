

var ServiceURL = "/Home/";

var app = angular.module("SearchContact", []);


app.service("SearchContactService", function ($http) {


    this.PostToService = function (param, MethodName) {
        var response = $http({
            method: "post",
            url: ServiceURL + MethodName,
            data: JSON.stringify(param),
            dataType: "json"
        });
        return response;
    }

});


app.controller("FindContactController", function ($scope, $log, SearchContactService) {

    $scope.IsData = false;
    $scope.PageNo = 1;
    $scope.TotalPages = 1;
    $scope.PerPage = 1000;
    $scope.IsPaging = false;
    $scope.SelectedFields;
    $scope.SelectionID = 0;


    $scope.fn_GetCountryList = function () {

        var ResponseRegistration = SearchContactService.PostToService("", "GetCountryList");
        ResponseRegistration.then(function (msg) {
            $scope.CountryList = msg.data.classobject;
        }, function (msg) {

            console.log('Error: fn_GetCountriesList ');
        });
    }

    $scope.fn_GetStateList = function () {

        var ResponseRegistration = SearchContactService.PostToService("", "GetStateList");
        ResponseRegistration.then(function (msg) {
            $scope.StateList = msg.data.classobject;
        }, function (msg) {

            console.log('Error: GetStateList ');
        });
    }

    $scope.fn_GetPostalList = function () {

        var ResponseRegistration = SearchContactService.PostToService("", "GetPostalList");
        ResponseRegistration.then(function (msg) {
            $scope.PostalList = msg.data.classobject;
        }, function (msg) {

            console.log('Error: GetStateList ');
        });
    }

    $scope.fn_GetJobFunctionList = function () {

        var ResponseRegistration = SearchContactService.PostToService("", "GetJobFunctionList");
        ResponseRegistration.then(function (msg) {
            $scope.JobFunctionList = msg.data.classobject;
            $log.log($scope.JobFunction);
        }, function (msg) {

            console.log('Error: GetStateList ');
        });
    }

    $scope.fn_GetAccuracyList = function () {

        var ResponseRegistration = SearchContactService.PostToService("", "GetAccuracyList");
        ResponseRegistration.then(function (msg) {
            $scope.AccuracyList = msg.data.classobject;
        }, function (msg) {

            console.log('Error: GetStateList ');
        });
    }

    $scope.fn_GetIndustriesList = function () {

        var ResponseRegistration = SearchContactService.PostToService("", "GetIndustriesList");
        ResponseRegistration.then(function (msg) {
            $scope.IndustriesList = msg.data.classobject;
        }, function (msg) {

            console.log('Error: GetStateList ');
        });
    }

    $scope.fn_GetEmplooyesList = function () {

        var ResponseRegistration = SearchContactService.PostToService("", "GetEmplooyesList");
        ResponseRegistration.then(function (msg) {
            $scope.EmployeesList = msg.data.classobject;
        }, function (msg) {

            console.log('Error: GetStateList ');
        });
    }

    $scope.fn_GetRevenueList = function () {

        var ResponseRegistration = SearchContactService.PostToService("", "GetRevenueList");
        ResponseRegistration.then(function (msg) {
            $scope.RevenueList = msg.data.classobject;
        }, function (msg) {

            console.log('Error: GetStateList ');
        });
    }

    $scope.fn_GetSICList = function () {

        var ResponseRegistration = SearchContactService.PostToService("", "GetSICList");
        ResponseRegistration.then(function (msg) {
            $scope.SICList = msg.data.classobject;
        }, function (msg) {

            console.log('Error: GetStateList ');
        });
    }

    $scope.fn_GetCityList = function () {


        var StateIDs = "";
        angular.forEach($scope.State, function (value, key) {
            StateIDs += value.StateID + ",";
        });



        var param =
            {
                StateID: StateIDs
            };

        var ResponseRegistration = SearchContactService.PostToService(param, "GetCityList");
        ResponseRegistration.then(function (msg) {
            $scope.CityList = null;
            $scope.CityList = msg.data.classobject;
        }, function (msg) {

            console.log('Error: GetStateList ');
        });
    }

    $scope.fn_GetCountyList = function () {


        var StateIDs = "";
        angular.forEach($scope.State, function (value, key) {
            StateIDs += value.StateID + ",";
        });


        var param =
            {
                StateID: StateIDs
            };

        var ResponseRegistration = SearchContactService.PostToService(param, "GetCountyList");
        ResponseRegistration.then(function (msg) {
            $scope.CountyList = null;
            $scope.CountyList = msg.data.classobject;
        }, function (msg) {

            console.log('Error: GetStateList ');
        });
    }

    $scope.fn_Findcontact = function () {


        swal({
            title: "Wait",
            text: "Please wait your request is processing...",
            button: false
        });

        // state
        var StateIDs = "";
        angular.forEach($scope.State, function (value, key) {
            StateIDs += value.StateID + ",";
        });

        // City
        var City = "";
        angular.forEach($scope.City, function (value, key) {

            $log.log("cty" + value.CityID);
            City += value.StateID + ",";
        });


        // County
        var County = "";
        angular.forEach($scope.County, function (value, key) {
            County += value.StateID + ",";
        });


        // Postal
        var Postal = "";
        angular.forEach($scope.Postal, function (value, key) {
            Postal += value.ID + ",";
        });



        // JobFuntion
        var JobFuntion = "";
        angular.forEach($scope.JobFunction, function (value, key) {
            JobFuntion += value.ID + ",";
        });

        // Accuracy
        var AccuracyIds = "";
        debugger;
        angular.forEach($scope.Accuracy, function (value, key) {
            AccuracyIds += value.ID + ",";
        });

        // SICCode
        var SICCode = "";
        angular.forEach($scope.SCode, function (value, key) {
            SICCode += value.Code + ",";
        });

        // Industries
        var Industries = "";
        angular.forEach($scope.Industries, function (value, key) {
            Industries += value.ID + ",";
        });


        // Industries
        var Employees = "";
        angular.forEach($scope.Employees, function (value, key) {
            Employees += value.ID + ",";
        });

        // Industries
        var Revenue = "";
        angular.forEach($scope.Revenue, function (value, key) {
            Revenue += value.ID + ",";
        });



        var param =
            {
                Title: $scope.Title,
                Email: $scope.Email,
                FirstName: $scope.FirstName,
                LastName: $scope.LastName,
                Phone1: $scope.Phone1,
                Phone2: $scope.Phone2,
                Street: $scope.Street,
                Website: $scope.Website,
                Organization: $scope.Organization,
                COrganization: $scope.COrganization,
                country: $scope.Country,
                State: $scope.State,
                City: $scope.City,
                Postal: $scope.Postal,
                JobFunction: $scope.JobFunction,
                Accuracy: $scope.Accuracy,
                SCode: $scope.SCode,
                Industries: $scope.Industries,
                Employees: $scope.Employees,
                Revenue: $scope.Revenue,
                County: $scope.County,
                PageNo: $scope.PageNo,
                PerPage: $scope.PerPage,
                StateIds: StateIDs,
                City: City,
                County: County,
                Postal: Postal,
                JobFuntion: JobFuntion,
                AccuracyIds: AccuracyIds,
                SICCode: SICCode,
                Industries: Industries,
                Employees: Employees,
                Revenue: Revenue
            };

        $scope.SelectedFields = JSON.stringify(param);



        var ResponseRegistration = SearchContactService.PostToService(param, "GetContactList");
        ResponseRegistration.then(function (msg) {

            if (msg.data.RCode == 1) {
                $scope.ContactList = msg.data.classobject.contactMaster;
                if ($scope.ContactList.length > 0) {
                    swal("Success", "congratulations found contact(s)", "success");
                    $scope.IsData = true;
                    $scope.TotalContacts = msg.data.classobject.TotalContact;
                    if (msg.data.classobject.TotalContact > $scope.PerPage) {
                        $scope.TotalPages = Math.ceil(msg.data.classobject.TotalContact / $scope.PerPage);
                        $scope.IsPaging = true;
                    }


                }

                if ($scope.ContactList.length == 0) {
                    swal("error", "System unable to find any record(s) against selected search criteria. Please try new search", "error");
                }

            }

            if (msg.data.RCode == 0) {
                swal("error", "System unable to process your request please find error details " + msg.data.RMessage, "error");
            }



        }, function (msg) {
            console.log(msg);
            swal("error", "Exception! Please check console", "error");
        });
    }

    $scope.fn_GetSelectedSearchList = function () {

        var ResponseRegistration = SearchContactService.PostToService("", "GetSelectedSearchList");
        ResponseRegistration.then(function (msg) {
            $scope.SelectedSearchList = msg.data.classobject;
        }, function (msg) {

            console.log('Error: fn_GetCountriesList ');
        });
    }

    $scope.fn_NewSearch = function () {

        $scope.IsData = false;
        $scope.fn_RefreshAllFields();
        $scope.fn_GetSelectedSearchList();
        $scope.SelectionID = 0;
    }

    $scope.fn_BackToSearch = function () {

        $scope.IsData = false;
    }

    $scope.fn_SaveExistingSearch = function () {

        if ($scope.SelectionID > 0) {
            $scope.fn_SaveSelectedSearch("");
        }
        else {
            swal("Please enter search name:", {
                content: "input",
            }).then((value) => {
                $scope.fn_SaveSelectedSearch(value);

            });
        }



    }

    $scope.fn_RefreshAllFields = function () {

        $scope.Title = "";
        $scope.Email = "";
        $scope.FirstName = "";
        $scope.LastName = "";
        $scope.Phone1 = "";
        $scope.Phone2 = "";
        $scope.Street = "";
        $scope.Website = "";
        $scope.Organization = "";
        $scope.COrganization = "";
        $scope.Country = "";
        $scope.State = "";
        $scope.City = "";
        $scope.Postal = "";
        $scope.JobFunction = "";
        $scope.Accuracy = "";
        $scope.SCode = "";
        $scope.Industries = "";
        $scope.Employees = "";
        $scope.Revenue = "";
        $scope.County = "";

    }

    $scope.exportData = function () {

        console.log($scope.ContactList);


        var opts = [{ sheetid: 'Search Results', header: true }];

        alasql('SELECT * INTO XLSX("WorkbookData.xlsx",?) FROM ?', [opts, [$scope.ContactList]]);



    };


    $scope.fn_DeleteContacts = function () {



        // state
        var ContactIds = "";
        angular.forEach($scope.ContactList, function (value, key) {
            ContactIds += value.ContactID + ",";
        });

        var param =
            {
                Contactids: ContactIds

            };

        var ResponseRegistration = SearchContactService.PostToService(param, "DeleteContacts");
        ResponseRegistration.then(function (msg) {

            if (msg.data.RCode == 1) {
                swal("Success", "Deleted Successfully.", "success");
                $log.info("Deleted Successfully. ");
                $scope.fn_Findcontact();

            }
            else {
                swal("error", "Something went wrong! Not saved!", "error");
            }

        });

    }

    $scope.fn_GetNextPage = function () {

        if ($scope.TotalPages > 1) {

            if ($scope.TotalPages == $scope.PageNo) {
                swal("error", "No more page!", "error");
            }
            else {
                $scope.PageNo = $scope.PageNo + 1;
                $scope.fn_Findcontact();
            }


        }
        else {
            swal("error", "No more page!", "error");
        }


    }

    $scope.fn_GetPreviousPage = function () {

        if ($scope.TotalPages > 1 && $scope.PageNo >= 1) {

            if ($scope.IsPaging == false) {
                swal("error", "No more page!", "error");
            }
            else {
                $scope.PageNo = $scope.PageNo - 1;
                $scope.fn_Findcontact();
            }

        }
        else {
            swal("error", "No more page!", "error");
        }


    }

    $scope.fn_SaveSelectedSearch = function (Name) {

        var param =
            {
                ID: $scope.SelectionID,
                Name: Name,
                Details: $scope.SelectedFields
            };

        var ResponseRegistration = SearchContactService.PostToService(param, "SaveSelection");
        ResponseRegistration.then(function (msg) {

            if (msg.data.RCode == 1) {
                if ($scope.SelectionID > 0) {
                    swal("Success", "updated Successfully.", "success");
                }
                else {
                    swal("Success", "Saved Successfully.", "success");
                }

            }
            else {
                swal("error", "Something went wrong! Not saved!", "error");
            }

        });

    }

    $scope.fn_DeleteSearchCriteria = function (SearchID) {

        var param =
            {
                ID: SearchID

            };

        var ResponseRegistration = SearchContactService.PostToService(param, "DeleteSearchCriteria");
        ResponseRegistration.then(function (msg) {

            if (msg.data.RCode == 1) {
                swal("Success", "Deleted Successfully.", "success");
                $scope.fn_GetSelectedSearchList();
            }
            else {
                swal("error", "Something went wrong! Not saved!", "error");
            }

        });

    }

    $scope.fn_GetSelectedSearch = function (SearchID) {

        var param =
            {
                ID: SearchID

            };

        var ResponseRegistration = SearchContactService.PostToService(param, "GetSelectedSearchByID");
        ResponseRegistration.then(function (msg) {

            if (msg.data.RCode == 1) {
                swal("Success", "Selected Successfully.", "success");
                debugger;
                var obj = JSON.parse(msg.data.classobject.Details);
                $scope.Title = obj.Title;
                $scope.Email = obj.Email
                $scope.FirstName = obj.FirstName;
                $scope.LastName = obj.LastName;
                $scope.Phone1 = obj.Phone1;
                $scope.Phone2 = obj.Phone2;
                $scope.Street = obj.Street;
                $scope.Website = obj.Website;
                $scope.Organization = obj.Organization;
                $scope.COrganization = obj.COrganization;
                $scope.State = obj.State;
                $scope.Postal = obj.Postal;
                $scope.City = obj.City;
                $scope.County = obj.County;
                $scope.JobFunction = obj.JobFunction;
                $scope.Accuracy = obj.Accuracy;
                $scope.SICCode = obj.SICCode;
                $scope.Industries = obj.Industries;
                $scope.Employees = obj.Employees;
                $scope.Revenue = obj.Revenue;
                $scope.SelectionID = msg.data.classobject.ID;

            }
            else {
                swal("error", "Something went wrong! Not saved!", "error");
            }

        });

    }





});
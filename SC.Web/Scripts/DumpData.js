

var ServiceURL = "/Home/";

var app = angular.module("SearchContact", []);


app.service("SearchContactService", function ($http) {


    this.PostToService = function (param, MethodName) {
        var response = $http({
            method: "post",
            url: MethodName,
            data: JSON.stringify(param),
            dataType: "json"
        });
        return response;
    }



});


app.controller("SearchContactController", function ($scope, SearchContactService) {


    $scope.UploadData = function () {


        swal({
            title: "Wait",
            text: "Please wait your request is processing...",
            button: false
        });

        var data = new FormData();
        var files = $("#fileInput").get(0).files;

        if (files.length > 0) {
            data.append("HelpSectionImages", files[0]);
        }

        $.ajax({
            url: ServiceURL + "UploadData",
            type: "POST",
            processData: false,
            contentType: false,
            data: data,
            success: function (response) {
                debugger;
                if (response.RCode == 1) {
                    swal("Success", "Please wait your request is processing for reading CSV data", "success");
                    $scope.ProcessedData();
                }
                if (response.RCode == 0) {
                    swal("error", "System unable to process the request, please see the error " + response.RMessage, "error");
                }


            },
            error: function (er) {
                console.log(er);
                console.log("System unable to process your request please try again later, data is not uploading");
            }

        });
    }

    $scope.ProcessedData = function () {



        var ResponseRegistration = SearchContactService.PostToService("", "ProcessedData");
        ResponseRegistration.then(function (msg) {

            if (msg.data.RCode == 1) {
                debugger;
                swal("Success", msg.data.RMessage, "success");
            }
            else {
                swal("error", "Something went wrong! Not saved!", "error");
            }

        });




    }

    $scope.fn_GetTotalContacts = function () {


        var ResponseRegistration = SearchContactService.PostToService("", "GetTotalContactsCount");
        ResponseRegistration.then(function (msg) {

            if (msg.data.RCode == 1) {
                debugger;
                $scope.TotalContacts = msg.data.classobject;
            }
            else {
                swal("error", "Something went wrong! Not saved!", "error");
            }

        });

    }

}); 
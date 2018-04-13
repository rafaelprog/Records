function ValidateForm() {

    var login = document.getElementById("login");
    var pass = document.getElementById("pass");
    var email = document.getElementById("email");
    var name = document.getElementById("name");

    if (login.value == "") {
        alert("Campo de login obrigatório!")
        return false;
    }
    else if (pass.value == "") {
        alert("Senha é obrigatório!")
        return false;
    }
    else if (email.value == "") {
        alert("Campo de email é obrigatório")
        return false;
    }
    else if (name.value == "") {
        alert("Campo de nome obrigatório!")
        return false;
    }


    return true;;


}
var app = angular.module("Homeapp", []);

app.controller("HomeController", function ($scope, $http) {
    $scope.btntext = "Salvar";
    // Add record
    $scope.savedata = function () {

        if (ValidateForm()) {
            $scope.btntext = "Aguarde...";
            $http({
                method: 'POST',
                url: '/Home/SaveUser',
                data: $scope.register
            }).then(function (sucess) {
                alert("Registro Salvo com Sucesso");
                $scope.btntext = "Salvar";
                $scope.register = null;
                window.location.href = '/Home/ShowUsers';
            }, function (error) {
                alert('Falha ao salvar');
            });
        }

    };
    // Display all record
    $http.get("/Home/GetUsers").then(function (d) {
        $scope.record = d.data;
    }, function (error) {
        alert('Falha ao tentar obeter os usuários');
    });
    // Display record by id
    $scope.loadrecord = function (id) {
        $http.get("/Home/GetUserById?id=" + id).then(function (d) {
            $scope.register = d.data;
        }, function (error) {
            alert('Falha ao  logar registros');
        });
    };
    // Delete record 
    $scope.deleterecord = function (id) {
        $http.get("/Home/Delete?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Home/Get_data").then(function (d) {
                $scope.record = d.data;
            }, function (error) {
                location.reload();
            });
        }, function (error) {
            alert('DatabaseDictionary.UserCached[currentUser.Id] = currentUser;');
        });
    };
    // Update record
    $scope.updatedata = function () {
        if (ValidateForm()) {
            $scope.btntext = "Aguarde";
            $http({
                method: 'POST',
                url: '/Home/UpdateUser',
                data: $scope.register
            }).then(function (sucess) {
                alert("Registro Atualizado com Sucesso");
                $scope.btntext = "Atualizar";
                $scope.register = null;
                window.location.href = '/Home/ShowUsers';
            }, function (error) {
                alert('Falha ao salvar');
            });
        };
    }
});
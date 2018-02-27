﻿angular.module('gestaoCondominioApp').controller('LoginController', function ($scope, LoginService, $location, LoginService) {                     

     if (LoginService.Jwt != undefined) {
         $location.path('/apartamento');
     }

     $scope.usuario = {
         login: null,
         senha: null
     };

     $scope.carregando = false;

     $scope.autenticar = function () {
         $scope.carregando = true;

        LoginService.autenticar(
        {
            Login: $scope.usuario.login,
            Senha: $scope.usuario.senha
        })
        .then(function (resposta) {
            LoginService.Jwt = resposta.data.JWT;
            LoginService.Usuario = $scope.usuario.Login;
            localStorage['Jwt'] = resposta.data.JWT;
            localStorage['Usuario'] = $scope.usuario.login;
            $location.path('/home');
        }, function (respostaError) {
            alert("Usuário ou senha incorreto. ");
        })
        .finally(function () {
            $scope.carregando = false;
        });
     };

     $scope.logout = function () {
         LoginService.desconectar();
         $location.path('/login');
     }
});
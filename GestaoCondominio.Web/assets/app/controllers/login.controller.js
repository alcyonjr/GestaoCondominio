﻿angular.module('gestaoCondominioApp').controller('LoginController', function ($scope, $location, UsuarioService) {                     

     if (UsuarioService.Jwt != undefined) {
         $location.path('/apartamento');
     }

     $scope.usuario = {
         login: null,
         senha: null
     };

     $scope.carregando = false;

     $scope.autenticar = function () {
        $scope.carregando = true;
        UsuarioService.autenticar(
        {
            Login: $scope.usuario.login,
            Senha: $scope.usuario.senha
        }).then(function (resposta) {
            UsuarioService.Jwt = resposta.data.JWT;
            UsuarioService.Usuario = $scope.usuario.Login;
            localStorage['Jwt'] = resposta.data.JWT;
            localStorage['Usuario'] = $scope.usuario.login;
            $location.path('/home');
        }).finally(function () {
            $scope.carregando = false;
        });
     };

     $scope.logout = function () {
         UsuarioService.desconectar();
         $location.path('/login');
     }
});
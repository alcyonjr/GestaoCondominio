﻿angular.module('gestaoCondominioApp').controller('UsuarioController', function ($scope, UsuarioService) {         

    $scope.novoUsuario = {};
    $scope.usuarios = [];

    $scope.cadastrar = function () {
        UsuarioService.cadastrar($scope.novoUsuario).then(function (respostaCadastro) {
            $scope.usuarios.push($scope.novoUsuario);                      
        }).catch(function (erro) {

        });
    }

    UsuarioService.listar().then(function(dados)
    {
        $scope.usuarios = dados
    }); 

    $scope.excluirSelecionado = function (usuario) {
        UsuarioService.excluir(usuario).then(function (resposta) {
            const index = $scope.usuarios.indexOf(usuario);
            $scope.usuarios.splice(index, 1);            
        }).catch(function (erro) {

        });
    }    
});
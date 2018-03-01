﻿angular.module('gestaoCondominioApp').controller('UsuarioController', function ($scope, UsuarioService, $uibModal, ngToast) {         

    $scope.novoUsuario = {};
    $scope.usuarios = [];
    $scope.aguardandoLista = true;
    $scope.carregando = false;
    $scope.searchUsuario = '';

    $scope.cadastrar = function () {
        $scope.carregando = true;
        UsuarioService.cadastrar($scope.novoUsuario).then(function (resposta) {                                
            ngToast.create('Cadastrado realizado com sucesso!');
            listar();
            limparFormulario();
        }).finally(function () {
            $scope.modalInstance.dismiss();
            $scope.carregando = false;
        });       
    }    
     
    function listar() {
        UsuarioService.listar().then(function (resposta) {
            $scope.usuarios = resposta.data
        }).finally(function () {
            $scope.aguardandoLista = false;
        });
    }

    UsuarioService.listar()
        .then(function (resposta) {
            $scope.usuarios = resposta.data
        }).finally(function () {
            $scope.aguardandoLista = false;
        });

    $scope.excluirSelecionado = function (usuario) {
        UsuarioService.excluir(usuario).then(function (resposta) {
            listar();   
            ngToast.create('Exclusão realizada com sucesso!');  
        });
    }   

    $scope.abrirModal = function () {
        $scope.modalInstance = $uibModal.open({
            templateUrl: 'usuario.modal.cadastro.html',
            scope: $scope
        });
    }

    $scope.fecharModal = function () {
        $scope.modalInstance.dismiss();
    };    

    function limparFormulario() {
        $scope.novoUsuario = {};        
    }
});
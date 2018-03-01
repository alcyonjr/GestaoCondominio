﻿angular.module('gestaoCondominioApp').controller('MoradorController', function ($scope, MoradorService, ApartamentoService, $uibModal, ngToast, $filter) {

    $scope.novoMorador = {}; 
    $scope.edicaoMorador = {};
    $scope.moradores = [];
    $scope.aguardandoLista = true;
    $scope.carregando = false;
    $scope.searchMorador = '';
   
    $scope.cadastrar = function () {
        $scope.carregando = true;        
        MoradorService.cadastrar($scope.novoMorador).then(function (resposta) {                
            ngToast.create('Cadastrado realizado com sucesso!');                
            listar();
            limparFormulario();
        }).finally(function () {
            $scope.modalInstance.dismiss();
            $scope.carregando = false;
        });
    }

    $scope.atualizar = function () {
        $scope.carregando = true;
        MoradorService.atualizar($scope.edicaoMorador).then(function (resposta) {            
            ngToast.create('Atualização realizado com sucesso!');                
            listar();
            limparFormulario();
        }).finally(function () {
            $scope.modalInstance.dismiss();
            $scope.carregando = false;
        });
    }

    function listar() {
        MoradorService.listar().then(function (resposta) {
            $scope.moradores = resposta.data
        }).finally(function () {
            $scope.aguardandoLista = false;
        });
    }

    MoradorService.listar().then(function (resposta) {
        $scope.moradores = resposta.data
    }).finally(function () {
        $scope.aguardandoLista = false;
    });

    ApartamentoService.listar().then(function (resposta) {
        $scope.apartamentos = resposta.data
    }).finally(function () {
        $scope.aguardandoLista = false;
    });

    $scope.atualizarSelecionado = function (morador) {
        $scope.edicaoMorador = morador;
        $scope.edicaoMorador.dataNascimento = new Date(morador.dataNascimento); 
        $scope.modalInstance = $uibModal.open({
            templateUrl: 'morador.modal.editar.html',
            scope: $scope
        });
    }

    $scope.excluirSelecionado = function (morador) {
        MoradorService.excluir(morador).then(function (resposta) {          
            ngToast.create('Exclusão realizada com sucesso!');          
            listar();
        }).catch(function (erro) {

        });
    }

    $scope.abrirModal = function () {
        $scope.modalInstance = $uibModal.open({
            templateUrl: 'morador.modal.cadastro.html',
            scope: $scope
        });
    }

    $scope.fecharModal = function () {
        $scope.modalInstance.dismiss();
    };

    function limparFormulario () {
        $scope.novoMorador = {};
        $scope.edicaoMorador = {};
    }
});
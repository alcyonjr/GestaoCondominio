﻿angular.module('gestaoCondominioApp').controller('ApartamentoController', function ($scope, ApartamentoService, MoradorService, $uibModal, ngToast) {         

    $scope.novoApartamento = {};
    $scope.editApartamento = {};
    $scope.apartamentos = [];
    $scope.aguardandoLista = true;
    $scope.carregando = false;
    $scope.searchApartamento = '';

    $scope.cadastrar = function () {
        $scope.carregando = true;
        ApartamentoService.cadastrar($scope.novoApartamento).then(function (resposta) {
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
        ApartamentoService.atualizar($scope.editApartamento).then(function (resposta) {
            ngToast.create('Atualização realizada com sucesso!');
            listar();
            limparFormulario();
        }).finally(function () {
            $scope.modalInstance.dismiss();
            $scope.carregando = false;
        });
    }
    
    function listar() {
        ApartamentoService.listar().then(function (resposta) {
            $scope.apartamentos = resposta.data;
        }).finally(function () {
            $scope.aguardandoLista = false;
        });
    }

    ApartamentoService.listar().then(function (resposta) {
        $scope.apartamentos = resposta.data
    }).finally(function () {
        $scope.aguardandoLista = false;
    });

    $scope.excluirSelecionado = function (apartamento) {
        ApartamentoService.excluir(apartamento).then(function (resposta) {
            listar();
            ngToast.create('Exclusão realizada com sucesso!');
        });
    }
    
    $scope.atualizarSelecionado = function (apartamento) {
        $scope.editApartamento = apartamento;
        $scope.modalInstance = $uibModal.open({
            templateUrl: 'apartamento.modal.editar.html',
            scope: $scope
        });
    }

    $scope.abrirModalMoradores = function (apartamento) {
        MoradorService.listarPorApartamento(apartamento).then(function (resposta) {
            $scope.moradoresApartamento = resposta.data
        });            
        $scope.modalInstance = $uibModal.open({
            templateUrl: 'apartamento.modal.moradores.html',
            scope: $scope
        });
    }

    $scope.abrirModal = function () {
        $scope.modalInstance = $uibModal.open({
            templateUrl: 'apartamento.modal.cadastro.html',
            scope: $scope
        });
    }

    $scope.fecharModal = function () {
        $scope.modalInstance.dismiss();
    };      

    function limparFormulario() {
        $scope.novoApartamento = {};
        $scope.editApartamento = {};
    }

});
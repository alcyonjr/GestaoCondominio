﻿angular.module('gestaoCondominioApp').controller('MoradorController', function ($scope, MoradorService, ApartamentoService) {         

    $scope.novoMorador = {};
    $scope.apartamentoSeleciondo = {};
    $scope.moradores = [];

    MoradorService.listar().then(function (dados) {
        $scope.moradores = dados
    }); 

    ApartamentoService.listar().then(function (dados) {
        $scope.apartamentos = dados
    }); 

    $scope.cadastrar = function () {
        var morador = $scope.novoMorador;
        morador.apartamento = $scope.apartamentoSeleciondo[0];
        MoradorService.cadastrar($scope.novoMorador).then(function (respostaCadastro) {
            $scope.moradores.push($scope.novoMorador);     
        }).catch(function (erro) {

        });
    }
    
    $scope.excluirSelecionado = function (morador) {
        MoradorService.excluir(morador).then(function (resposta) {

        }).catch(function (erro) {

        });
    }    
});
﻿angular.module('gestaoCondominioApp').controller('ApartamentoController', function ($scope, ApartamentoService) {         

    $scope.novoApartamento;
    $scope.apartamentos = [];

    $scope.cadastrar = function () {
        ApartamentoService.cadastrar($scope.novoApartamento).then(function (respostaCadastro) {
            $scope.apartamentos.push($scope.novoApartamento);                      
        }).catch(function (erro) {

        });
    }

    ApartamentoService.listar().then(function(dados)
    {
        $scope.apartamentos = dados
    }); 

    $scope.excluirSelecionado = function (apartamento) {
        ApartamentoService.excluir(apartamento).then(function (resposta) {
            const index = $scope.apartamentos.indexOf(apartamento);
            $scope.apartamentos.splice(index, 1);            
        }).catch(function (erro) {

        });
    }    
});
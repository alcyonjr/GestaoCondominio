angular.module('gestaoCondominioApp').factory('ApartamentoService', function ($http, PropriedadesConstants) {
    
    var urlEndpoint = PropriedadesConstants.Endpoint + '/Apartamento/';

    return {
        listar: function () {
            return $http.get(urlEndpoint + "Consultar").then(function (response) {
                return response.data;
            });
        },

        cadastrar: function (novoApartamento) {
            return $http.post(urlEndpoint + "Cadastrar", novoApartamento).then(function (response) {
                return response.data;
            });
        },

        excluir: function (apartamento) {
            return $http.delete(urlEndpoint + "Excluir", { params: { id: apartamento.id } });
        }  

    };   
})
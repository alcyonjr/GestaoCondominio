angular.module('gestaoCondominioApp').factory('MoradorService', function ($http, PropriedadesConstants) {

    var urlEndpoint = PropriedadesConstants.Endpoint + '/Morador/';

    return {
        listar: function () {
            return $http.get(urlEndpoint + "Consultar").then(function (response) {
                return response.data;
            });
        },

        cadastrar: function (novoMorador) {
            return $http.post(urlEndpoint + "Cadastrar", novoMorador).then(function (response) {
                return response.data;
            });
        },

        excluir: function (morador) {            
            return $http.delete(urlEndpoint + "Excluir", { params: { id: morador.id } });
        }       

    };
});
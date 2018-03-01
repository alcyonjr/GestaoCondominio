angular.module('gestaoCondominioApp').factory('ApartamentoService', function ($http, PropriedadesConstants) {
    
    var urlEndpoint = PropriedadesConstants.Endpoint + 'Apartamento/';

    return {
        listar: function () {
            return $http.get(urlEndpoint + "Consultar");
        },

        cadastrar: function (novoApartamento) {
            return $http.post(urlEndpoint + "Cadastrar", novoApartamento);
        },

        excluir: function (apartamento) {
            return $http.delete(urlEndpoint + "Excluir", { params: { id: apartamento.id } });
        },  

        atualizar: function (apartamento) {
            return $http.put(urlEndpoint + "Atualizar", apartamento);
        }  

    };   
})
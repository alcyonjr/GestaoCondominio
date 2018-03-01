angular.module('gestaoCondominioApp').factory('MoradorService', function ($http, PropriedadesConstants) {

    var urlEndpoint = PropriedadesConstants.Endpoint + 'Morador/';

    return {
        listar: function () {
            return $http.get(urlEndpoint + "Consultar");
        },

        listarPorApartamento: function (apartamento) {            
            return $http.get(urlEndpoint + "ListarPorApartamento", { params: { idApartamento: apartamento.id } });                 
        },

        cadastrar: function (novoMorador) {
            return $http.post(urlEndpoint + "Cadastrar", novoMorador);
        },

        excluir: function (morador) {            
            return $http.delete(urlEndpoint + "Excluir", { params: { id: morador.id } });
        },       

        atualizar: function (morador) {
            return $http.put(urlEndpoint + "Atualizar", morador);
        }  
    };
});
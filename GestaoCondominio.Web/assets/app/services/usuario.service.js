angular.module('gestaoCondominioApp').factory('UsuarioService', function ($http, PropriedadesConstants) {

    var urlEndpoint = PropriedadesConstants.Endpoint + '/Usuario/';

    return {
        listar: function () {
            return $http.get(urlEndpoint + "Consultar").then(function (response) {
                return response.data;
            });
        },

        cadastrar: function (novoUsuario) {
            return $http.post(urlEndpoint + "Cadastrar", novoUsuario).then(function (response) {
                return response.data;
            });
        },

        excluir: function (usuario) {            
            return $http.delete(urlEndpoint + "Excluir", { params: { id: usuario.id } });
        }       

    };
});
angular.module('gestaoCondominioApp').factory('UsuarioService', function ($http, PropriedadesConstants) {

    var urlEndpoint = PropriedadesConstants.Endpoint + 'Usuario/';

    return {
        Jwt: localStorage['Jwt'],
        Usuario: localStorage['Usuario'],

        desconectar: function () {
            localStorage.clear();
            this.Jwt = undefined;
            this.Usuario = undefined;
        },

        autenticar: function (usuario) {
            return $http({
                method: 'POST',
                url: urlEndpoint + 'Autenticar',
                params: { login: usuario.Login, senha: usuario.Senha }
            });
        },

        listar: function () {
            return $http.get(urlEndpoint + "Consultar");
        },

        cadastrar: function (novoUsuario) {
            return $http.post(urlEndpoint + "Cadastrar", novoUsuario);
        },

        excluir: function (usuario) {            
            return $http.delete(urlEndpoint + "Excluir", { params: { id: usuario.id } });
        }       

    };
});
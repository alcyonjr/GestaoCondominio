angular.module('gestaoCondominioApp').factory('LoginService', function ($http, PropriedadesConstants) {
        
    return {
        Jwt: localStorage['Jwt'],
        Usuario: localStorage['Usuario'],
        desconectar: function () {
            localStorage.clear();
            this.Jwt = undefined;
            this.Usuario = undefined;
        },
        autenticar: function (usuario) {
            return $http.post(PropriedadesConstants.Endpoint + 'login/autenticar', usuario);
        }
    };
})
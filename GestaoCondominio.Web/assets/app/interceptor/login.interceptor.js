angular.module('gestaoCondominioApp')
    .factory('LoginInterceptor', function ($q, $injector, $location, PropriedadesConstants) {
        return {
            request: function (config) {
                const usuarioService = $injector.get('UsuarioService');
                if (config.url.startsWith(PropriedadesConstants.Endpoint)) {
                    if (usuarioService.Jwt != undefined) {
                        config.headers.Authorization = 'Bearer ' + usuarioService.Jwt;
                    }
                }
                return config;
            },
            responseError: function (config) {
                if (config.status == 401) {
                    const usuarioService = $injector.get('UsuarioService');
                    usuarioService.desconectar();
                    $location.path('/Login');
                    return;
                }
                return $q.reject(config);
            }
        };
    });
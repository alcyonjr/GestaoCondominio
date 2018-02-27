angular.module('gestaoCondominioApp')
    .factory('LoginInterceptor', function ($q, $injector, $location, PropriedadesConstants) {
        return {
            request: function (config) {
                const loginService = $injector.get('LoginService');
                if (config.url.startsWith(PropriedadesConstants.Endpoint)) {
                    if (loginService.Jwt != undefined) {
                        config.headers.Authorization = 'Bearer ' + loginService.Jwt;
                    }
                }
                return config;
            },
            responseError: function (config) {
                if (config.status == 401) {
                    const loginService = $injector.get('LoginService');
                    loginService.desconectar();
                    $location.path('/Login');
                    return;
                }
                return $q.reject(config);
            }
        };
    });
angular.module('gestaoCondominioApp')
    .factory('ExceptionInterceptor', function ($q, $injector, $location, PropriedadesConstants) {
        return {           
            responseError: function (config) {
                if (config.status == 400) {
                    const ngToast = $injector.get('ngToast');
                    ngToast.create(
                        {
                            className: 'info',
                            content: config.data.Mensagem
                        }                        
                    );  
                }
                return $q.reject(config);
            }
        };
    });
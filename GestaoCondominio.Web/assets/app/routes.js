angular.module('gestaoCondominioApp').config(function ($routeProvider,  $locationProvider, $httpProvider, PropriedadesConstants) {

    var viewBase = PropriedadesConstants.Endpoint + 'assets/app/templates/';    
    $httpProvider.interceptors.push('LoginInterceptor');

    $routeProvider.when('/apartamento', {
        templateUrl: viewBase + 'apartamento.htm',
        controller: 'ApartamentoController'
    });

   $routeProvider.when('/morador', {
        templateUrl: viewBase + 'morador.htm',
        controller: 'MoradorController'
    });

   $routeProvider.when('/usuario', {
       templateUrl: viewBase + 'usuario.htm',
       controller: 'UsuarioController'
   });

    $routeProvider.when('/login', {
        templateUrl: viewBase + 'login.htm',
        controller: 'LoginController'
    });

	$routeProvider.otherwise({ redirectTo: '/login' });
});
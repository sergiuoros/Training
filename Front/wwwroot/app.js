var app = angular.module('myApp', ['ui.router', 'ngDialog']);

app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/events');

    $stateProvider

        // HOME STATES AND NESTED VIEWS ========================================
        .state('events', {
            url: '/events',
            templateUrl: '/myApp/pages/events/events.html'
        })

        .state('login', {
            url: '/login',
            templateUrl: '/myApp/pages/login/login.html'
        })

        .state('eventsedit', {
            url: '/events/:id',
            templateUrl: '/myApp/pages/events/eventEdit/editevent.html',
            controller: 'EventEditController',
        })
        .state('eventsession', {
            url: '/eventsession/:id',
            templateUrl: '/myApp/pages/sessions/sessionevent.html',
           // controller: 'SessionController',
        })
    
});
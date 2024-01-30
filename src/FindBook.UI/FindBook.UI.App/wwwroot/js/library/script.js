var app = angular.module('myApp', []);
var panel = document.getElementById("admin-login");

app.controller('myCtrl', function($scope, $http) {
  $scope.jsonData = [];

  $http.get('../../assets/Json/AuthorAndTitles/library.json').then(function(response) {
    $scope.jsonData = response.data;
  }, function(error) {
    console.error('Veri çekme hatası:', error);
  });

  $scope.search = ''; // Arama için kullanılacak değişken, başlangıçta boş olarak tanımlanır

  $scope.filteredData = function() {
    return $scope.jsonData.filter(function(data) {
      return (
        data.Authors.toLowerCase().includes($scope.search.toLowerCase()) ||
        data.Titles.toLowerCase().includes($scope.search.toLowerCase()) ||
        data.Type.toLowerCase().includes($scope.search.toLowerCase())
      );
    });
  };
});

panel.addEventListener("click", function() {
  window.open("../admin/index.html", "_blank");
})



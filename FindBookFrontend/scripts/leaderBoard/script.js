// AngularJS uygulamasını başlatma
var app = angular.module('myApp', ['ngRoute']);

// Firebase'den veri almak için controller
app.controller('ScoreController', function($scope,$location) {
  // Firebase'e erişim sağlayacak kodları burada kullanabilirsiniz
  // Örnek olarak burada bir scoresRef oluşturulmuş gibi düşünelim

  const firebaseConfig = {
    apiKey: "AIzaSyCP4n6vjz7c46N47aRft0-J4LyVPvUSui8",
    authDomain: "findbook-23e68.firebaseapp.com",
    databaseURL:
      "https://findbook-23e68-default-rtdb.europe-west1.firebasedatabase.app",
    projectId: "findbook-23e68",
    storageBucket: "findbook-23e68.appspot.com",
    messagingSenderId: "677177090624",
    appId: "1:677177090624:web:bc2e38edf49993b58775a5",
    measurementId: "G-D8F97D7MPF",
  };
  
  firebase.initializeApp(firebaseConfig);
  
  // Veritabanı referansı alınması
  const database = firebase.database();
  
  // ScoresTable içindeki Scores'a erişim sağlama
  const scoresRef = database.ref("ScoresTable/Scores");

  scoresRef.once('value')
  .then(function(snapshot) {
    var scoresObj = snapshot.val();
    var scoresArray = [];

    // Objeyi diziye dönüştürme
    for (var key in scoresObj) {
      if (scoresObj.hasOwnProperty(key)) {
        scoresArray.push(scoresObj[key]);
      }
    }

    // Diziyi skor değerine göre sıralama
    scoresArray.sort(function(a, b) {
      return b.score - a.score;
    });

    // AngularJS ile HTML içeriğine bağlama
    $scope.scores = scoresArray;
    $scope.$apply(); // Değişiklikleri güncelleyin
  })
  .catch(function(error) {
    console.error('Veri okunurken hata oluştu:', error);
  });


});

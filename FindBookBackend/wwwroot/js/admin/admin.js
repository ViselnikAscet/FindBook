var app = angular.module('myApp', []);

app.controller('AdminController', function($scope ,$http,$window) {
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
    const database = firebase.database();


  // ScoresTable içindeki Scores'a erişim sağlama
  const scoresRef = database.ref("ScoresTable/Scores");

    // Veritabanı referansı alınması
    $scope.clear = function() {
        scoresRef.set({});
      };

});

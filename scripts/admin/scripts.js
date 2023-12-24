// AngularJS uygulamasını başlatma
var app = angular.module('myApp', ['ngRoute']);

// Firebase'den veri almak için controller
app.controller('ScoreController', function($scope) {

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
    const scoresRef = database.ref("AdminPanel/user-info");
    $scope.login = function() {
        console.log("BASILDI")
        var username = $scope.username;
        var password = $scope.password;

        // Kullanıcı adı ve şifreyle Firebase veritabanında karşılaştırma yapma
        const scoresRef = database.ref("AdminPanel/user-info");
        scoresRef.once('value').then(function(snapshot) {
            snapshot.forEach(function(childSnapshot) {
                var childData = childSnapshot.val();
                if (childData.username === username && childData.password === password) {
                    // Kullanıcı adı ve şifre doğru ise
                    $scope.uyari = "Giriş başarılı!";
                    // İlgili işlemleri yapabilirsiniz
                } else {
                    // Kullanıcı adı veya şifre yanlış ise
                    $scope.uyari = "Kullanıcı adı veya şifre yanlış!";
                }
            });
        });
    };


});

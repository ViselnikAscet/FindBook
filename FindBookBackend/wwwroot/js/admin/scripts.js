// AngularJS uygulamasını başlatma
var app = angular.module('myApp', []);

// Firebase'den veri almak için controller
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

    // Veritabanı referansı alınması
    $scope.login = function() {
        var email = $scope.email;
        var password = $scope.password;

        // Kullanıcı bilgilerini Firebase Realtime Database'den kontrol etme
        var usersRef = database.ref("AdminPanel/user-info");
        usersRef.once('value')
          .then(function(snapshot) {
            var userInfo = snapshot.val();
            var user = userInfo.mert; // Kullanıcı adı "mert" örneği

            if (user.email === email && user.password === password) {
                $window.location.href = '../../pages/admin/admin.html';              // Başarılı giriş, istediğiniz işlemleri yapabilirsiniz (örneğin yönlendirme)
            } else {
              console.log('Giriş başarısız. Kullanıcı adı veya şifre hatalı.');
              // Hatalı giriş durumunda kullanıcıya bildirim gösterebilirsiniz
            }
          })
          .catch(function(error) {
            console.error("Hata oluştu: ", error);
          });
      };

});

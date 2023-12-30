var app = angular.module('App', ['$scope', '$interval', 'ngResource']);
var isClickedOne = false;
var isClickedTwo = false;
var questionCount = 1;
var gamemode = "turk";
var categorize = "Roman";
var isClickedOne = false;
var isClickedTwo = false;
const quizdisplay = document.getElementById("display");

// Firebase'den veri almak için controller
app.controller('HomeController', ['$scope', '$interval', '$resource', '$location', '$http', function($scope, $interval, $resource, $location, $http) {

//FİREBASE
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
  
  
  // Scores'a yeni bir skor eklemek
  
  //FİREBASE
  


  $scope.switchLeft = function() {
    switchBtnRight.classList.remove("active-case");
    switchBtnmiddle.classList.remove("active-case");
    switchBtnLeft.classList.add("active-case");
    activeSwitch.style.left = "0%";
    gamemode = "turk";
    fetchData();
    console.log(gamemode);
  };

  $scope.switchMiddle = function() {
    switchBtnRight.classList.remove("active-case");
    switchBtnmiddle.classList.add("active-case");
    switchBtnLeft.classList.remove("active-case");
    activeSwitch.style.left = "33.3333%";
    gamemode = "global";
    fetchData();
    console.log("Yabancı");
  };

  $scope.switchRight = function() {
    switchBtnRight.classList.add("active-case");
    switchBtnmiddle.classList.remove("active-case");
    switchBtnLeft.classList.remove("active-case");
    activeSwitch.style.left = "66.6667%";
    gamemode = "mix";
    fetchData();
    console.log(gamemode);
  };

  $scope.switchLeft2 = function() {
    switchBtnRight.classList.remove("active2-case2");
    switchBtnLeft.classList.add("active2-case2");
    categorize = "Roman";
    activeSwitch2.style.left = "0%";
  };

  $scope.switchRight2 = function() {
    switchBtnRight.classList.add("active2-case2");
    switchBtnLeft.classList.remove("active2-case2");
    categorize = "Cocuk";
    activeSwitch2.style.left = "50%";
  };

  
  $scope.goLibrary = function() {
    window.open("./library/index.html", "_blank");
  };

  $scope.goScoreBoard = function() {
    window.open("./LeaderBoard/index.html", "_blank");
  };

  $scope.goToNext = function() {
    var myBar = document.getElementById('myBar');
    var wrapper = document.getElementById('wrapper');
    var scoreContainer = document.getElementById('scoreContainer');
    var countOfQuestion = document.getElementById('countOfQuestion');
    var scoreGoster = document.getElementById('scoreGoster');

    myBar.style.animation = "none";
    myBar.offsetHeight;
    myBar.style.animation = null;

    $scope.questionCount += 1;

    if ($scope.questionCount === $scope.quizArray.length) {
      wrapper.classList.add("hide");
      scoreContainer.classList.remove("hide");
      $scope.score = $scope.scoreCount * 10;

      var newScore = {
        username: $scope.adSoyadInput,
        score: $scope.score
      };

      scoresRef
        .push(newScore)
        .then(() => {
          console.log("Skor başarıyla eklendi!");
        })
        .catch((error) => {
          console.error("Skor eklenirken hata oluştu:", error);
        });

      $scope.userScore = "Senin skorun " + $scope.questionCount + " soruda " + $scope.score + " puan";
      $scope.score = 0;
    } else {
      $scope.score = $scope.scoreCount * 10;
      countOfQuestion.innerHTML = $scope.questionCount + ". Soru";
      scoreGoster.innerHTML = "Puan: " + $scope.score;
      $scope.score = 0;

      // Burada quizDisplay() ve diğer işlemler çağrılır

      // clearInterval(countdown);
      // timerDisplay();
      quizDisplay(questionCount);
      //count=11 (so that it starts with 10)
      count = 11;
      //clear interval for next question
      clearInterval(countdown);
      //display timer (start countdown)
      timerDisplay();
    }
  };  


  $scope.timerDisplay = function() {
    var count = 10; // İlgili süre
    var wrong = 3; // Yanlış sayısı
    var myBar = document.getElementById('myBar');
    var heart1 = document.getElementById('heart1');
    var heart2 = document.getElementById('heart2');
    var heart3 = document.getElementById('heart3');
    var wrapper = document.getElementById('wrapper');
    var scoreCount = 0; // Skor sayacı
    var score = 0; // Skor

    countdown = $interval(function() {
      count--;

      if (count === 0) {
        wrong--;

        $interval.cancel(countdown);
        displayNext(); // Fonksiyonunuzun adı

        myBar.style.animation = "none";
        myBar.offsetHeight;
        myBar.style.animation = null;

        if (wrong === 2) {
          heart1.className = "heartempty"; // heartempty sınıfının adı
          angular.element(heart1).addClass("shaking");
        } else if (wrong === 1) {
          heart2.className = "heartempty";
          angular.element(heart2).addClass("shaking");
        } else if (wrong === 0) {
          heart3.className = "heartempty";
          angular.element(heart3).addClass("shaking");

          setTimeout(function() {
            wrapper.classList.add("hide");
            score = scoreCount * 10;
            scoreContainer.classList.remove("hide");
            var newScore = {
              username: $scope.adSoyadInput, // AngularJS modeli kullanarak inputtan değeri alın
              score: score
            };

            // Servis çağrısı
            scoresRef
              .push(newScore)
              .then(() => {
                console.log("Skor başarıyla eklendi!");
              })
              .catch((error) => {
                console.error("Skor eklenirken hata oluştu:", error);
              });

            $scope.userScore = "Senin skorun " + $scope.questionCount + " soruda " + score + " puan";
            wrong = 3;
            score = 0;
          }, 400);
        }
      }
    }, 1000);
  };

  $scope.quizDisplay = function(questionCount) {
    var quizCards = angular.element(document.querySelectorAll(".container_mid"));
    quizCards.addClass("hide");
    quizCards.eq(questionCount).removeClass("hide");
  };

  $scope.quizCreator = function() {
    $scope.quizArray.sort(function() {
      return Math.random() - 0.5;
    });

    for (var i = 0; i < $scope.quizArray.length; i++) {
      var question = $scope.quizArray[i];

      question.options.sort(function() {
        return Math.random() - 0.5;
      });

      var div = document.createElement("div");
      div.classList.add("container_mid", "hide");
      $scope.countOfQuestion.innerHTML = $scope.questionCount + ". Soru";

      var question_DIV = document.createElement("p");
      question_DIV.classList.add("question");
      question_DIV.innerHTML = question.question;
      div.appendChild(question_DIV);

      var options = '';
      for (var j = 0; j < question.options.length; j++) {
        options += '<button class="option-div" ng-click="checker(\'' + question.options[j] + '\')">' + question.options[j] + '</button>';
      }
      div.innerHTML += options;
      $scope.quizContainer.appendChild(div);
    }
  };

  $scope.correctOption = '';

  $scope.checker = function(userOption) {
    var userSolution = userOption.innerText;
    var question = angular.element(document.getElementsByClassName("container_mid")[questionCount]);
    var options = question[0].querySelectorAll(".option-div");

    // Eğer kullanıcının seçtiği cevap, objede saklanan doğru seçenekle eşleşiyorsa
    if (userSolution === $scope.quizArray[questionCount].correct) {
      $scope.correctOption = $scope.quizArray[questionCount].correct;
      angular.element(userOption).addClass("correct");
      $scope.scoreCount++;
    } else {
      // Yanlış arka planı
      angular.element(userOption).addClass("inCorrect");
      $scope.wrong = $scope.wrong - 1;

      // Yanlış cevap verilirse kalp sayısını azaltma
      if ($scope.wrong == 2) {
        $scope.heart1.className = $scope.heartempty;
        angular.element(document.getElementById("heart1")).addClass("shaking");
      } else if ($scope.wrong == 1) {
        $scope.heart2.className = $scope.heartempty;
        angular.element(document.getElementById("heart2")).addClass("shaking");
      } else if ($scope.wrong == 0) {
        $scope.heart3.className = $scope.heartempty;
        angular.element(document.getElementById("heart3")).addClass("shaking");

        setTimeout(function () {
          $scope.wrapper.classList.add("hide");
          $scope.score = $scope.scoreCount * 10;
          $scope.scoreContainer.classList.remove("hide");
          var newScore = {
            username: $scope.adSoyadInput.value,
            score: $scope.score
          };
          $scope.scoresRef
            .push(newScore)
            .then(() => {
              console.log("Skor başarıyla eklendi!");
            })
            .catch((error) => {
              console.error("Skor eklenirken hata oluştu:", error);
            });
          $scope.userScore.innerHTML =
            "Senin skorun " + $scope.questionCount + " soruda " + $scope.score + " puan";
          $scope.wrong = 3;
          $scope.score = 0;
        }, 400);
      }

      // Doğru cevabı göstermek için yeşil (doğru) işaretleme
      options.forEach(function(element) {
        if (element.innerText == $scope.quizArray[$scope.questionCount].correct) {
          angular.element(element).addClass("correct");
        }
      });
    }

    // Zamanlayıcıyı durdur
    clearInterval($scope.countdown);
r 
    // Tüm seçenekleri devre dışı bırak
    options.forEach(function(element) {
      element.disabled = true;
    });
  };

  $scope.startGame = function() {
    startScreen.classList.add("hide");
    wrapper.classList.remove("hide");
    $scope.inital();  };

  $scope.goMenu = function() {
    if (adSoyadInput.value.trim() === "") {
      // Eğer input alanlarından biri boşsa, kullanıcıyı uyar
      alert("Skorunuzu Kaydedebilmemiz İçin Kullanıcı Adınızı Giriniz!");
    } else {
      user.classList.add("hide");
      startScreen.classList.remove("hide");
    }  
  };



  $scope.quizArray = [];

  $http.get('../../assets/Json/QuizData/RomanYerliQuiz.json').then(function(response) {
    $scope.quizArray = response.data;
  }, function(error) {
    console.error('Veri çekme hatası:', error);
  });




  $scope.fetchData = function() {
    if ($scope.categorize == "Roman" && $scope.gamemode == "turk") {
      $http.get("../../assets/Json/QuizData/RomanYerliQuiz.json")
        .then(function(response) {
          $scope.quizArray = response.data;
        });
    } else if ($scope.categorize == "Roman" && $scope.gamemode == "global") {
      $http.get("../../assets/Json/QuizData/RomanYabancıQuiz.json")
        .then(function(response) {
          $scope.quizArray = response.data;
        });
    } else if ($scope.categorize == "Roman" && $scope.gamemode == "mix") {
      var turkQuestions, globalQuestions;
      $http.get("../../assets/Json/QuizData/RomanYerliQuiz.json")
        .then(function(response) {
          turkQuestions = response.data;
          return $http.get("../../assets/Json/QuizData/RomanYabancıQuiz.json");
        })
        .then(function(response) {
          globalQuestions = response.data;
          var mixedQuestions = [];

          for (
            var i = 0;
            i < turkQuestions.length || i < globalQuestions.length;
            i++
          ) {
            if (turkQuestions[i]) mixedQuestions.push(turkQuestions[i]);
            if (globalQuestions[i]) mixedQuestions.push(globalQuestions[i]);
          }

          mixedQuestions.sort(function() {
            return Math.random() - 0.5;
          });
          $scope.quizArray = mixedQuestions.slice(0, 50);
        });
    } else if ($scope.categorize == "cocuk") {
      $http.get("../../assets/Json/QuizData/ChildQuizData.json")
        .then(function(response) {
          $scope.quizArray = response.data;
        });
    }
  };


  $scope.restartGame = function() {
    resetCardState(); // Reset the card state
    inital(); //call initial function
    wrapper.classList.remove("hide");
    scoreContainer.classList.add("hide");  
  };

  $scope.goToMenu = function() {
    scoreContainer.classList.add("hide");
    startScreen.classList.remove("hide");
  };




$scope.inital = function(){
  quizContainer.innerHTML = "";
  wrong = 3;
  questionCount = 1;
  scoreCount = 0;
  clearInterval(countdown);
  count = 11;
  timerDisplay();
  quizCreator();
  quizDisplay(questionCount);
  $scope.heart1.className = heartfull;
  $scope.heart2.className = heartfull;
  $scope.heart3.className = heartfull;
  var isClickedOne = false;
  var isClickedTwo = false;
  score = 0;
}


$scope.onLoad = function() {
  ular.element(document.getElementById('startScreen')).addClass('hide');
  angular.element(document.getElementById('wrapper')).addClass('hide');
  angular.element(document.getElementById('user')).removeClass('hide');
};


$scope.handleClickOne = function(cardNumber){
  if (!isClickedOne) {
    flipCard(cardNumber, ".card1");
    isClickedOne = true;

    let question =
      document.getElementsByClassName("container_mid")[questionCount];
    let options = question.querySelectorAll(".option-div");

    // Doğru cevabı bulma
    options.forEach((option) => {
      if (correctOption) {
        correctOption = option;
      }
    });

    // Doğru cevabı hariç tutarak seçenekleri karıştırma
    let optionsArray = [...options].filter(
      (option) => option !== correctOption
    );
    let shuffledOptions = optionsArray.sort(() => Math.random() - 0.5);

    // Son iki seçeneği kaldırma
    let optionsToRemove = shuffledOptions.slice(0, 2);
    optionsToRemove.forEach((option) => option.remove());
  }
}
$scope.handleClickTwo = function(cardNumber) {
  if (!isClickedTwo) {
    flipCard(cardNumber, ".card2");
    isClickedTwo = true;
  }
};


$scope.flipCard = function(cardNumber, cardClass){
  let card = document.querySelector(`${cardClass}`);
  if (card !== null) {
    card.classList.toggle("is-flipped");
  } else {
    console.error(
      `Element not found for ${cardClass}:nth-child(${cardNumber})`
    );
  }
}



$scope.resetCardState = function(){
  isClickedOne = false;
  isClickedTwo = false;
  // Remove the "is-flipped" class from all cards
  let flippedCards = document.querySelectorAll(".is-flipped");
  flippedCards.forEach((card) => card.classList.remove("is-flipped"));
}

}]);
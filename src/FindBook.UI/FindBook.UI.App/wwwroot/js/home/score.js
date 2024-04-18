angular.module('myApp', [])
.controller('ListController', function($scope) {
    $scope.wrongAnswers = [];
    $scope.items;
    $scope.init = function() {
        $scope.items = wrongAnswers.slice(); // wrongAnswers dizisini kopyalayarak items değişkenine atama
    };

    // AngularJS kapsamındaki items değişkenini JavaScript'teki wrongAnswers dizisiyle eşleştirme
    $scope.wrongAnswers.push({
        question: quizArray[questionCount].question,
        correctAnswer: quizArray[questionCount].correct,
        userAnswer: userSolution
    });
    

    // Yeni bir öğe eklemek için bu fonksiyonu kullanalım
    $scope.addItem = function() {
        var newItem = prompt("Yeni öğe adını girin:");
        if (newItem !== null && newItem !== '') {
            $scope.items.push(newItem);
        }
    };
});

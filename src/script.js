let heart1 = document.getElementById("heart1");
let heart2 = document.getElementById("heart2");
let heart3 = document.getElementById("heart3");
let scoreGoster = document.getElementById("scoreGoster");
let heartfull = "fa-solid fas fa-heart";
let heartempty = "fa-regular far fa-heart";
let heartanimation = "fa-solid fas fa-heart-crack";
let score = 0;
let wrong = 3;
const quizdisplay = document.getElementById("display");
let timeLeft = document.querySelector(".time-left");
let quizContainer = document.getElementById("container");
let nextBtn = document.getElementById("next-button");
let countOfQuestion = document.querySelector(".number-of-question");
let wrapper = document.getElementById("wrapper");
let displayContainer = document.getElementById("display-container");
let scoreContainer = document.querySelector(".score-container");
let restart = document.getElementById("restart");
let menu = document.getElementById("mainmenu");
let user = document.getElementById("user-info");
let userScore = document.getElementById("user-score");
let startScreen = document.querySelector(".start-screen");
let info = document.getElementById("go-info");
let startButton = document.getElementById("start-button");
let scoreCount = 0;
let count = 11;
let countdown;
let adSoyadInput = document.querySelector('input[placeholder="Ad Soyad"]');
let numaraInput = document.querySelector('input[placeholder="Numara"]');
var gamemode = "turk";
var categorize = "Roman";
("use strict");
var switchButton = document.querySelector(".switch-button");
var switchBtnmiddle = document.querySelector(".switch-button-case.middle");
var switchBtnRight = document.querySelector(".switch-button-case.right");
var switchBtnLeft = document.querySelector(".switch-button-case.left");
var activeSwitch = document.querySelector(".active");
var isClickedOne = false;
var isClickedTwo = false;
//

var switchButton2 = document.querySelector(".switch-button2");
var switchBtnRight2 = document.querySelector(".switch-button-case2.right2");
var switchBtnLeft2 = document.querySelector(".switch-button-case2.left2");
var activeSwitch2 = document.querySelector(".active2");

function switchLeft2() {
  switchBtnRight.classList.remove("active2-case2");
  switchBtnLeft.classList.add("active2-case2");
  categorize="Roman";
  activeSwitch2.style.left = "0%";
}

function switchRight2() {
  switchBtnRight.classList.add("active2-case2");
  switchBtnLeft.classList.remove("active2-case2");
  categorize="Cocuk";

  activeSwitch2.style.left = "50%";
}

switchBtnLeft2.addEventListener(
  "click",
  function () {
    switchLeft2();
    categorize="Roman"
    fetchData();

    console.log(categorize);
  },
  false
);

switchBtnRight2.addEventListener(
  "click",
  function () {
    switchRight2();
    categorize="cocuk"
    fetchData();
    console.log(categorize);
  },
  false
);


let myBar = document.getElementById("progressBar");
let questionCount = 1;

function switchLeft() {
  switchBtnRight.classList.remove("active-case");
  switchBtnmiddle.classList.remove("active-case");
  switchBtnLeft.classList.add("active-case");
  activeSwitch.style.left = "0%";
}

function switchRight() {
  switchBtnRight.classList.add("active-case");
  switchBtnmiddle.classList.remove("active-case");
  switchBtnLeft.classList.remove("active-case");
  activeSwitch.style.left = "66.6667%";
}

function switchMiddle() {
  switchBtnRight.classList.remove("active-case");
  switchBtnmiddle.classList.add("active-case");
  switchBtnLeft.classList.remove("active-case");
  activeSwitch.style.left = "33.3333%";
}


//

//

let quizArray = [];
fetch("../Json/QuizData/RomanYerliQuiz.json")
	  .then((response) => response.json())
	  .then((data) => {
		quizArray = data;
	  });
switchBtnLeft.addEventListener(
  "click",
  function () {
    switchLeft();
    gamemode = "turk";
    fetchData();

    console.log(gamemode);
  },
  false
);

switchBtnRight.addEventListener(
  "click",
  function () {
    switchRight();
    gamemode = "mix";
    fetchData();

    console.log(gamemode);
  },
  false
);
switchBtnmiddle.addEventListener(
  "click",
  function () {
    switchMiddle();
    gamemode = "global";
    fetchData();
    console.log("Yabancı");
  },
  false
);

function fetchData() {
  if (categorize == "Roman" && gamemode == "turk") {

	fetch("../Json/QuizData/RomanYerliQuiz.json")
	  .then((response) => response.json())
	  .then((data) => {
		quizArray = data;
	  });
  } else if (categorize == "Roman" && gamemode == "global") {
	fetch("../Json/QuizData/RomanYabancıQuiz.json")
	  .then((response) => response.json())
	  .then((data) => {
		quizArray = data;
	  });
  } else if (categorize == "Roman" && gamemode == "mix") {
	let turkQuestions, globalQuestions;
	fetch("../Json/QuizData/RomanYerliQuiz.json")
	  .then((response) => response.json())
	  .then((turkData) => {
		turkQuestions = turkData;
		return fetch("../Json/QuizData/RomanYabancıQuiz.json");
	  })
	  .then((response) => response.json())
	  .then((globalData) => {
		globalQuestions = globalData;
		let mixedQuestions = [];
  
		for (
		  let i = 0;
		  i < turkQuestions.length || i < globalQuestions.length;
		  i++
		) {
		  if (turkQuestions[i]) mixedQuestions.push(turkQuestions[i]);
		  if (globalQuestions[i]) mixedQuestions.push(globalQuestions[i]);
		}
  
		mixedQuestions.sort(() => Math.random() - 0.5);
		quizArray = mixedQuestions.slice(0, 50);
	  });
  } else if (categorize == "cocuk") {
	fetch("../Json/QuizData/ChildQuizData.json")
	  .then((response) => response.json())
	  .then((data) => {
		quizArray = data;
	  });
  }
}




// restart game
restart.addEventListener("click", () => {
  resetCardState(); // Reset the card state
  inital(); //call initial function
  wrapper.classList.remove("hide");
  scoreContainer.classList.add("hide");
});

// Back Main Menü

menu.addEventListener("click", () => {
  scoreContainer.classList.add("hide");
  startScreen.classList.remove("hide");
})
// Next button
nextBtn.addEventListener(
  "click",
  (displayNext = () => {
      myBar.style.animation = 'none';
      myBar.offsetHeight;
      myBar.style.animation = null;
      //increment questionCount
      questionCount += 1;
      //if last question
      if (questionCount == quizArray.length) {
          //hide question container and display score
          wrapper.classList.add("hide");
          scoreContainer.classList.remove("hide");
          score = scoreCount * 10;
          // user score
          userScore.innerHTML =
              "Senin skorun " + questionCount + " soruda " + score + " puan";
          score = 0;
      } else {
          //display questionCount
          score = scoreCount * 10;
          countOfQuestion.innerHTML = questionCount+". Soru"
          scoreGoster.innerHTML = "Puan: " + score;
          score = 0;
          // countOfQuestion.innerHTML = 
          //     questionCount + 1 + " of " + quizArray.length + " Question";

          //display Quiz
          quizDisplay(questionCount);
          //count=11 (so that it starts with 10)
          count = 11;
          //clear interval for next question
          clearInterval(countdown);
          //display timer (start countdown)
          timerDisplay();
      }
  })
);


// Timer
const timerDisplay = () => {
  countdown = setInterval(() => {
      count--;
      if (count == 0) {
          wrong--;
          //when countdown reaches 0 clearInterval and go to next question
          clearInterval(countdown);
          displayNext();

          myBar.style.animation = 'none';
          myBar.offsetHeight;
          myBar.style.animation = null;
          if (wrong == 2) {
              heart1.className = heartempty;
              document.getElementById('heart1').classList.add('shaking');
          }
          else if (wrong == 1) {
              heart2.className = heartempty;
              document.getElementById('heart2').classList.add('shaking');
          }
          else if (wrong == 0) {
              heart3.className = heartempty;
              document.getElementById('heart3').classList.add('shaking');

              setTimeout(function() {
                  wrapper.classList.add("hide");
                  score = scoreCount * 10;
                  scoreContainer.classList.remove("hide");
                  userScore.innerHTML =
                      "Senin skorun " + questionCount + " soruda " + score + " puan";
                  wrong = 3;
                  score = 0;
              }, 400);
          }
      }
  }, 1000);
};

//display quiz
const quizDisplay = (questionCount) => {
	let quizCards = document.querySelectorAll(".container_mid");
	//hide other cards
	quizCards.forEach((card) => {
		card.classList.add("hide");
	});
	//display current question card
	quizCards[questionCount].classList.remove("hide");
};
// Quiz creation
function quizCreator() {
  //randomly sort questions
  quizArray.sort(() => Math.random() - 0.5);
  //generate quiz
  for (let i of quizArray) {
    //randomly sort options
    i.options.sort(() => Math.random() - 0.5);
    //quiz card creation
    let div = document.createElement("div");
    div.classList.add("container_mid", "hide");
    //question number
    countOfQuestion.innerHTML = questionCount + ". Soru";

    //question
    let question_DIV = document.createElement("p");
    question_DIV.classList.add("question");
    question_DIV.innerHTML = i.question;
    div.appendChild(question_DIV);
    //options
    div.innerHTML += `
<button class="option-div" onclick="checker(this)">${i.options[0]}</button>
<button class="option-div" onclick="checker(this)">${i.options[1]}</button>
<button class="option-div" onclick="checker(this)">${i.options[2]}</button>
<button class="option-div" onclick="checker(this)">${i.options[3]}</button>

`;
    quizContainer.appendChild(div);
  }
}
// Check option is correct or not
function checker(userOption) {
  let userSolution = userOption.innerText;
  let question = document.getElementsByClassName("container_mid")[questionCount];
  let options = question.querySelectorAll(".option-div");
  //if user's clicked anaswer==correct option stored in object
  if (userSolution === quizArray[questionCount].correct) {
      //green background and score increment
      userOption.classList.add("correct");
      scoreCount++;
  } else {

      //red background
      userOption.classList.add("inCorrect");
      wrong = wrong - 1;
      if (wrong == 2) {
          heart1.className = heartempty;
          document.getElementById('heart1').classList.add('shaking');
      }
      else if (wrong == 1) {
          heart2.className = heartempty;
          document.getElementById('heart2').classList.add('shaking');
      }
      else if (wrong == 0) {
          heart3.className = heartempty;
          document.getElementById('heart3').classList.add('shaking');

          setTimeout(function() {
              wrapper.classList.add("hide");
              score = scoreCount * 10;
              scoreContainer.classList.remove("hide");
              userScore.innerHTML =
                  "Senin skorun " + questionCount + " soruda " + score + " puan";
              wrong = 3;
              score = 0;
          }, 400);
      }
      //for marking green(correct)
      options.forEach((element) => {
          if (element.innerText == quizArray[questionCount].correct) {
              element.classList.add("correct");
          }
      });
  }
  //clear interval(stop timer)
  clearInterval(countdown);
  //disabled all options
  options.forEach((element) => {
      element.disabled = true;
  });
}
//initial setup
function inital() {
  quizContainer.innerHTML = "";
  wrong = 3;
  questionCount = 1;
  scoreCount = 0;
  clearInterval(countdown);
  count = 11;
  timerDisplay();
  quizCreator();
  quizDisplay(questionCount);
  heart1.className = heartfull;
  heart2.className = heartfull;
  heart3.className = heartfull;
  var isClickedOne = false;
  var isClickedTwo = false;
  score = 0;
}
// when user click on start button
info.addEventListener("click", () => {

  startScreen.classList.add("hide");
  wrapper.classList.remove("hide");
  user.classList.add("hide");
});

startButton.addEventListener("click", () => {

  if (adSoyadInput.value.trim() === '' || numaraInput.value.trim() === '') {
    // Eğer input alanlarından biri boşsa, kullanıcıyı uyar
    alert('Ad Soyad ve Numara alanları boş bırakılamaz!');
  } else {
  user.classList.add("hide");
  wrapper.classList.add("hide");
  startScreen.classList.remove("hide");
  inital();
  }
})


//hide quiz and display start screen
window.onload = () => {
  startScreen.classList.add("hide");
  wrapper.classList.add("hide");
  user.classList.remove("hide");
};

// Bir kere tıklama için kullanılan flag


function handleClickOne(cardNumber) {
  if (!isClickedOne) {
      flipCard(cardNumber, '.card1');
      isClickedOne = true;
  }
}

function handleClickTwo(cardNumber) {
  if (!isClickedTwo) {
      flipCard(cardNumber, '.card2');
      isClickedTwo = true;
  }
}

function flipCard(cardNumber, cardClass) {
  let card = document.querySelector(`${cardClass}`);
  if (card !== null) {
    card.classList.toggle("is-flipped");
  } else {
    console.error(`Element not found for ${cardClass}:nth-child(${cardNumber})`);
  }
}

function resetCardState() {
  isClickedOne = false;
  isClickedTwo = false;
  // Remove the "is-flipped" class from all cards
  let flippedCards = document.querySelectorAll(".is-flipped");
  flippedCards.forEach(card => card.classList.remove("is-flipped"));
}
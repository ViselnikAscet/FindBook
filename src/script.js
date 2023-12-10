// References
const quizdisplay = document.getElementById("display");
let timeLeft = document.querySelector(".time-left");
let quizContainer = document.getElementById("container");
let nextBtn = document.getElementById("next-button");
let countOfQuestion = document.querySelector(".number-of-question");
let wrapper = document.getElementById("wrapper");
let displayContainer = document.getElementById("display-container");
let scoreContainer = document.querySelector(".score-container");
let restart = document.getElementById("restart");
let userScore = document.getElementById("user-score");
let startScreen = document.querySelector(".start-screen");
let startButton = document.getElementById("start-button");
let scoreCount = 0;
let count = 11;
let countdown;
"use strict";
var switchButton = document.querySelector(".switch-button");
var switchBtnRight = document.querySelector(".switch-button-case.right");
var switchBtnLeft = document.querySelector(".switch-button-case.left");
var activeSwitch = document.querySelector(".active");
var gamemode = true;
let myBar = document.getElementById('progressBar');
let questionCount = 1;


function switchLeft() {
	switchBtnRight.classList.remove("active-case");
	switchBtnLeft.classList.add("active-case");
	activeSwitch.style.left = "0%";
}

function switchRight() {
	switchBtnRight.classList.add("active-case");
	switchBtnLeft.classList.remove("active-case");
	activeSwitch.style.left = "50%";
}

switchBtnLeft.addEventListener(
	"click",
	function () {
		switchLeft();
        gamemode=true;
		console.log("Yerli");

	},
	false
);

switchBtnRight.addEventListener(
	"click",
	function () {
		switchRight();
        gamemode=false;
		console.log("Yabancı");

	},
	false
);



let quizArray = [];
fetch('../Json/Data.json')
    .then(response => response.json())
    .then(data => {
        quizArray = data;
        // continue with your existing code here...
    });

switch(gamemode) {
	case true:
		fetch('../Json/Data.json')
			.then(response => response.json())
			.then(data => {
				quizArray = data;
				// continue with your existing code here...
    });

	case false:
		fetch('../Json/WordBookData.json')
			.then(response => response.json())
			.then(data => {
				quizArray = data;
				// continue with your existing code here...
    });


}
//Question and Options array
// Add questions, options and correct option in below format




// restart game
restart.addEventListener("click", () => {
	inital(); //call initial function
	wrapper.classList.remove("hide");
	scoreContainer.classList.add("hide");
});
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
			// user score
			userScore.innerHTML =
			"Skorunuz " +  questionCount + " soruda " + scoreCount + " doğru ";
		} else {
			//display questionCount
			countOfQuestion.innerHTML = questionCount+". Soru"
			// countOfQuestion.innerHTML = 
			// 	questionCount + 1 + " of " + quizArray.length + " Question";

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
		timeLeft.innerHTML = `${count}s`;
		if (count == 0) {
			//when countdown reaches 0 clearInterval and go to next question
			clearInterval(countdown);
			displayNext();
			myBar.style.animation = 'none';
            myBar.offsetHeight;
            myBar.style.animation = null;
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
		countOfQuestion.innerHTML = questionCount+ ". Soru"

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
	questionCount = 1;
	scoreCount = 0;
	clearInterval(countdown);
	count = 11;
	timerDisplay();
	quizCreator();
	quizDisplay(questionCount);
}
// when user click on start button
startButton.addEventListener("click", () => {
	startScreen.classList.add("hide");
	wrapper.classList.remove("hide");
	inital();
});
//hide quiz and display start screen
window.onload = () => {
	startScreen.classList.remove("hide");
	wrapper.classList.add("hide");
};
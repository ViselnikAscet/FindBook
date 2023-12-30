import { initializeApp } from "https://www.gstatic.com/firebasejs/10.7.1/firebase-app.js";
import { getAnalytics } from "https://www.gstatic.com/firebasejs/10.7.1/firebase-analytics.js";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
    apiKey: "AIzaSyCP4n6vjz7c46N47aRft0-J4LyVPvUSui8",
    authDomain: "findbook-23e68.firebaseapp.com",
    databaseURL: "https://findbook-23e68-default-rtdb.europe-west1.firebasedatabase.app",
    projectId: "findbook-23e68",
    storageBucket: "findbook-23e68.appspot.com",
    messagingSenderId: "677177090624",
    appId: "1:677177090624:web:bc2e38edf49993b58775a5",
    measurementId: "G-D8F97D7MPF"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const analytics = getAnalytics(app);
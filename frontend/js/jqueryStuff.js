const script = document.createElement("script"); // Create a <script> element
script.src = "https://code.jquery.com/jquery-3.4.1.min.js"; // Add a src attribute
document.head.appendChild( script ); // Append it to <head>
// When the script loads, and jQuery has been loaded, you are ready to go:
 
script.onload = function(){
 
 console.log("Loaded!");
 
 jQuery(function($){
 
 $("#menu").load("./menu.html");
 
 });
 
}
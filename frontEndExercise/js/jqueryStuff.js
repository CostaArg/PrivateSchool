const script = document.createElement("script");
script.src = "https://code.jquery.com/jquery-3.4.1.min.js";
document.head.appendChild(script);

script.onload = function() {
  jQuery(function($) {
    $("#menu").load("./menu.html");
  });
};
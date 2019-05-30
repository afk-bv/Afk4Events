var prevScrollpos = window.pageYOffset;
window.onscroll = function () {
    var currentScrollPos = window.pageYOffset;
    if (prevScrollpos > currentScrollPos) {
        document.getElementById("afk-nav").style.top = "0";
        document.getElementById("afk-nav").style.boxShadow = "0 2px 2px 0 rgba(0,0,0,.14),0 3px 1px -2px rgba(0,0,0,.2),0 1px 5px 0 rgba(0,0,0,.12)";
    } else {
        document.getElementById("afk-nav").style.top = (-($("#afk-nav").outerHeight())) + "px";
        document.getElementById("afk-nav").style.boxShadow = "none";
    }
    prevScrollpos = currentScrollPos;
}

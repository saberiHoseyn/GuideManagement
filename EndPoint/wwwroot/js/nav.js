//let NavItem = document.querySelectorAll("li.nav-item a.nav-link");

//NavItem.forEach(activeNav);

//function activeNav(item) {
//    item.addEventListener('Click', function (e) {
//        e.;
//        let NavItemActive = document.querySelector("li.nav-item active");
//        NavItemActive.classList.remove("active h4");
//        this.classList.add("active h4");
//    });
//};
//document.addEventListener('click', (e) => {
//    console.log(e.target);

//});




var btns =
    $("#navigation .navbar-nav .nav-link");

for (var i = 0; i < btns.length; i++) {
    btns[i].addEventListener("click",
        function () {
            var current = document
                .getElementsByClassName("active");

            current[0].className = current[0]
                .className.replace(" active", "");

            this.className += " active";
        });
}
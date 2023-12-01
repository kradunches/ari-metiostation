let navMain = document.querySelector('.main-header__top');
let navToggle = document.querySelector('.main-header__top__toggle');

navMain.classList.remove('main-header__top--nojs');

navToggle.addEventListener('click', function () {
    if (navMain.classList.contains('main-header__top--closed')) {
        navMain.classList.remove('main-header__top--closed');
        navMain.classList.add('main-header__top--opened');
    } else {
        navMain.classList.add('main-header__top--closed');
        navMain.classList.remove('main-header__top--opened');
    }
});
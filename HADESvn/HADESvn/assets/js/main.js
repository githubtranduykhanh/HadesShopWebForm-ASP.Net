let navadmin = document.querySelector('.navadmin');
let toggle = document.querySelector('.toggle');
let contents = document.querySelector('.contents');
toggle.onclick = function(){
    navadmin.classList.toggle('active')
    contents.classList.toggle('active')
}


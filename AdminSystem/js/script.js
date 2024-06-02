document.addEventListener("DOMContentLoaded", function () {
    const button = document.querySelector(".input-group button");
    button.addEventListener("mouseover", function () {
        this.style.backgroundColor = "#ff8c00";
    });
    button.addEventListener("mouseout", function () {
        this.style.backgroundColor = "#6a0dad";
    });
});

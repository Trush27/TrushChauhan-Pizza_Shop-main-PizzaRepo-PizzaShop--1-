document.addEventListener("DOMContentLoaded", function () {
    const togglePassword = document.querySelector("#togglePassword");
    const password = document.querySelector("#password");

    togglePassword.addEventListener("click", function () {

        const type = password.getAttribute("type") === "password" ? "text" : "password";
        password.setAttribute("type", type);

        this.classList.toggle("bi-eye");
    });
});
function addUser() {
    window.location.href = 'add-user.html';
}
function backToUsers() {
    window.location.href = 'users.html';
}
function editUser() {
    window.location.href = 'edit-user.html'
}

        
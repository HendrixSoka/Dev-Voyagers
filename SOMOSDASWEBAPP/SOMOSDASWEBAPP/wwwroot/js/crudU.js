document.getElementById("form-email").addEventListener("input", verificarCampos);
document.getElementById("form-pass").addEventListener("input", verificarCampos);
document.getElementById("form-nombre").addEventListener("input", verificarCampos);
function verificarCampos() {
    var usuario = document.getElementById("form-email").value;
    var contrasena = document.getElementById("form-pass").value;
    var contrasena = document.getElementById("form-nombre").value;
    var enlace = document.getElementById("enlace");

    if (usuario !== "" && contrasena !== "") {
        enlace.style.display = "block"; // mostrar el enlace cuando ambos campos estén llenos
    } else {
        enlace.style.display = "none"; // ocultar el enlace si uno o ambos campos están vacíos
    }
}


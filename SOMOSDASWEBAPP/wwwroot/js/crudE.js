document.getElementById("form-mail").addEventListener("input", verificarCampos);
document.getElementById("form-cell").addEventListener("input", verificarCampos);
document.getElementById("form-name").addEventListener("input", verificarCampos);
function verificarCampos() {
    var in1 = document.getElementById("form-mail").value;
    var in2 = document.getElementById("form-cell").value;
    var in3 = document.getElementById("form-name").value;
    var enlace = document.getElementById("enlace");

    if (in1 !== "" && in2 !== "" && in3 !== "") {
        enlace.style.display = "block"; // mostrar el enlace cuando ambos campos estén llenos
    } else {
        enlace.style.display = "none"; // ocultar el enlace si uno o ambos campos están vacíos
    }
}


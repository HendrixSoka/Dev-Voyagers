document.getElementById("form-dur").addEventListener("input", verificarCampos);
document.getElementById("form-tema").addEventListener("input", verificarCampos);
document.getElementById("form-docente").addEventListener("input", verificarCampos);
document.getElementById("form-cant").addEventListener("input", verificarCampos);
function verificarCampos() {
    var in1 = document.getElementById("form-dur").value;
    var in2 = document.getElementById("form-tema").value;
    var in3 = document.getElementById("form-docente").value;
    var in4 = document.getElementById("form-cant").value;
    var enlace = document.getElementById("enlace");

    if (in1 !== "" && in2 !== "" && in3 !== "" && in4 !== "" ) {
        enlace.style.display = "block"; // mostrar el enlace cuando ambos campos estén llenos
    } else {
        enlace.style.display = "none"; // ocultar el enlace si uno o ambos campos están vacíos
    }
}


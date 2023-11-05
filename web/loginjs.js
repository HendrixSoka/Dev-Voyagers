document.getElementById("miuser").addEventListener("input", verificarCampos);
document.getElementById("mipass").addEventListener("input", verificarCampos);

function verificarCampos() {
  var usuario = document.getElementById("miuser").value;
  var contrasena = document.getElementById("mipass").value;
  var enlace = document.getElementById("enlace");

  if (usuario !== "" && contrasena !== "") {
    enlace.style.display = "block"; // mostrar el enlace cuando ambos campos estén llenos
  } else {
    enlace.style.display = "none"; // ocultar el enlace si uno o ambos campos están vacíos
  }
}
// Selecciona todos los campos de entrada con la clase "input-field"
const inputFields = document.querySelectorAll('.input-field');

// Itera sobre los campos de entrada y agrega un controlador de eventos de cambio
inputFields.forEach(input => {
  input.addEventListener('input', () => {
    const placeholder = input.nextElementSibling; // Selecciona el elemento "placeholder" adyacente

    // Verifica si el campo de entrada tiene contenido
    if (input.value.trim() !== '') {
      placeholder.style.top = '-10px';
      placeholder.style.color = '#04AA6D';
      placeholder.style.backgroundColor = '#fff';
    } else {
      placeholder.style.top = '0';
      placeholder.style.color = ''; // Restablece el color predeterminado
      placeholder.style.backgroundColor = ''; // Restablece el color de fondo predeterminado
    }
  });
});

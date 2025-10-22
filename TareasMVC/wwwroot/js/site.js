function ejecutarAlertEliminar(URL){
    let contenedorBotones = document.getElementById("contenedor-botones");
    contenedorBotones.addEventListener("click", function (evento) {
        evento.stopPropagation();
        if (evento.target.tagName === "BUTTON") {
            let id = evento.target.getAttribute("data-id");
            let nombre = evento.target.getAttribute("data-nombre");
            console.log("Click", { id, nombre })
            confirmarAccion({
                callbackAceptar: () => {
                    borrarTerminal({ idTermineal: id, url: URL })
                },
                callbackCancelar: () => {
                    //.........
                }, titulo: `Desea eliminar el elemento ${nombre}`
            })
        }
    });
}

async function borrarTerminal({ idTermineal, url }) {
    
    //Llamada AJAX con POST y el ID en el cuerpo (data)
    $.ajax({
        // URL usa la convención clásica: /Terminales/Eliminar
        url: `${url}/Eliminar`,
        type: 'POST', //Usamos POST para que coincida con [HttpPost]
        data: { id: idTermineal }, //  Enviamos el ID en el cuerpo

        success: function (response) {
            

            if (response.success) {
                var filaEliminar = $('#fila-' + idTermineal);
                // Alerta de éxito final
                filaEliminar.fadeOut(400, function () {
                    $(this).remove();
                });

                Swal.fire(
                    '¡Eliminada!',
                    "Elemento correctamente eliminado",
                    'success'
                );
            } else {
                // Alerta de error del servidor
                Swal.fire(
                    'Error al Eliminar',
                   "Intento más tarde",
                    'error'
                );
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            Swal.fire(
                'Error de Conexión',
                'No se pudo completar la solicitud.',
                'error'
            );
        }
    })
}

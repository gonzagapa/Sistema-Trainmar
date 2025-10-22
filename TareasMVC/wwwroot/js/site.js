
async function borrarTerminal({idTermineal,url }) {
    // 🚀 CAMBIO CLAVE: Llamada AJAX con POST y el ID en el cuerpo (data)
    $.ajax({
        // URL usa la convención clásica: /Terminales/Eliminar
        url: `${url}/Eliminar`,
        type: 'POST', // 👈 Usamos POST para que coincida con [HttpPost]
        data: { id: idTermineal }, // 👈 Enviamos el ID en el cuerpo

        success: function (response) {

            if (response.success) {
                // Alerta de éxito final
                Swal.fire(
                    '¡Eliminada!',
                    response.message,
                    'success'
                );
            } else {
                // Alerta de error del servidor
                Swal.fire(
                    'Error al Eliminar',
                    response.message,
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

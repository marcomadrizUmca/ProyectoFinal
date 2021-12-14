///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmNuevoTipoCliente").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {

            Nombre: {
                required: true
            },

            Descripcion: {
                required: true,
                minlength: 8
                
            }
        }
    });
}

function creaValidaciones() {
    $("#frmModificaTipoCliente").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {

            Nombre: {
                required: true
            },

            Descripcion: {
                required: true,
                minlength: 8

            }
        }
    });
}
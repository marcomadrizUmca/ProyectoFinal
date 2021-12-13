///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmNuevoTipoCuenta").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {

            Nombre: {
                required: true
            },

            Codigo: {
                required: true,
                minlength: 8

            }
        }
    });
}

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmModificaTipoCuentas").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {

            Nombre: {
                required: true
            },

            Codigo: {
                required: true,
                minlength: 8

            }
        }
    });
}
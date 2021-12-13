///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmNuevaCuenta").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {

            Numero_Cuenta: {
                required: true,
                Number: true,
            },

            Codigo: {
                required: true,
                minlength: 8

            },

            Estado: {
                required: true
            }
        }
    });
}

function creaValidaciones() {
    $("#frmModificaCuenta").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {

            Numero_Cuenta: {
                required: true,
                Number: true,
            },

            Codigo: {
                required: true,
                minlength: 8

            },

            Estado: {
                required:true
            }

        }
    });
}
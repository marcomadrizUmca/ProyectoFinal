///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmNuevoMoneda").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {

            Nombre: {
                required: true
            },

            Tipo_Cambio: {
                required: true,
                minlength: 3,
                maxlength: 7
            },

            Codigo: {
                required: true
            }

        }
    });
}
///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmNuevoCliente").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {

            Cedula: {
                required: true,
                maxlength: 9
            },

            Genero: {
                required: true
            },

            Fecha_Nacimiento: {
                required: true,
            },

            Nombre: {
                required: true
            },

            Primer_Apellido: {
                required: true,
                minlength: 3,
                maxlength: 7
            },

            Segundo_Apellido: {
                required: true,
                minlength: 3,
                maxlength: 7
            },

            Direccion_Fisica: {
                required: true,
                minlength: 3,
                maxlength: 7
            },

            Telefono_Principal: {
                required: true,
                maxlength: 12
            },

            Correo_Electronico: {
                required: true,
                email: true
            },

            id_Tipo_Cliente: {
                required: true
            }

        }
    });

    function creaValidaciones() {
        $("#frmModificaCliente").validate({
            ///objeto que contiene "las condiciones" que el formulario
            ///debe cumplir para ser considerado válido
            rules: {

                Cedula: {
                    required: true,
                    maxlength: 9
                },

                Genero: {
                    required: true
                },

                Fecha_Nacimiento: {
                    required: true,
                },

                Nombre: {
                    required: true
                },

                Primer_Apellido: {
                    required: true,
                    minlength: 3,
                    maxlength: 7
                },

                Segundo_Apellido: {
                    required: true,
                    minlength: 3,
                    maxlength: 7
                },

                Direccion_Fisica: {
                    required: true,
                    minlength: 3,
                    maxlength: 7
                },

                Telefono_Principal: {
                    required: true,
                    maxlength: 12
                },

                Correo_Electronico: {
                    required: true,
                    email: true
                },

                id_Tipo_Cliente: {
                    required: true
                }

            }
        });


    }
}
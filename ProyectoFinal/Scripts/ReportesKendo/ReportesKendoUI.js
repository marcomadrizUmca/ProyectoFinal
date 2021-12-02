$(function () {
    obtenerRegistrosCuentas();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaCuentasLista()
function obtenerRegistrosCuentas() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/Cuentas/RetornaCuentasLista'
    var parametros = {};
    var funcion = creaGridKendo;
    ///ejecuta la función $.ajax utilizando un método genérico
    //para no declarar toda la instrucción siempre
    ejecutaAjax(urlMetodo, parametros, funcion);
}
///encargada de crear el grid de kendo y mostrar
//los datos obtenidos al llamar al método
// RetornaCuentasClientes
function creaGridKendo(data) {
    $("#divKendoGrid").kendoGrid({
        ///Asignar la fuente de datos al objeto
        ///Kendo Grid
        dataSource: {
            data: data.resultado,
            pageSize: 2
        },
        pageable: true,
        columns: [
            ///Cada columna se agrega por llaves
            {
                ///Propiedad de la fuente de datos a mostras
                field: 'NombreCliente',
                ///texto del encabezado
                title: 'Nombre del Cliente'
            },
            {
                field: 'ApellidoCliente',
                title: 'Primer Apellido'
            },
            {
                field: 'SegundoApellido',
                title: 'Segundo Apellido'
            },
            {
                field: 'Numero_Cuenta',
                title: 'Numero de Cuenta'
            },
            {
                field: 'NombreMonneda',
                title: 'Moneda'
            },

            {
                field: 'Saldo',
                title: 'Saldo'
            },
            {
                title: "Acciones",
                template: function (dataItem) {
                    return "<a href='Cuentas/CuentaModifica?Id_Cuenta=" + dataItem.Id_Cuenta +"'>Modificar</a>"
            }
            }
        ],
        filterable: true,
        toolbar: ["excel", "pdf"],
        excel: {
            fileName: "Lista de Cuentas.xlsx",
            filterable: true,
            allPages: true,
        },
        pdf: {
            fileName: "Lista de Cuentas.pdf",
            author: "UMCA",
            creator: "Marco Madriz Herrera",
            date: new Date(),

        }
    });
}
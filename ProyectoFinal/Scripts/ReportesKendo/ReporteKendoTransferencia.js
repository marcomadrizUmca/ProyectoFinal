$(function () {
    obtenerRegistrosCuentas();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaRetirosLista()
function obtenerRegistrosCuentas() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/Transferencias/RetornaTransferenciasLista'
    var parametros = {};
    var funcion = creaGridKendo;
    ///ejecuta la función $.ajax utilizando un método genérico
    //para no declarar toda la instrucción siempre
    ejecutaAjax(urlMetodo, parametros, funcion);
}
///encargada de crear el grid de kendo y mostrar
//los datos obtenidos al llamar al método
// RetornaRetirosLista
function creaGridKendo(data) {
    $("#divKendoGrid").kendoGrid({
        ///Asignar la fuente de datos al objeto
        ///Kendo Grid
        dataSource: {
            data: data.resultado,
            pageSize: 5
        },
        pageable: true,
        columns: [
            ///Cada columna se agrega por llaves
            {
                ///Propiedad de la fuente de datos a mostras
                field: 'cuentaOrigen',
                ///texto del encabezado
                title: 'Numero de Cuenta de Origen'
            },
            {
                field: 'cuentaDestino',
                title: 'Numero de Cuenta de Destino'
            },
            {
                field: 'Nombre',
                title: 'Nombre de la Moneda'
            },
            {
                field: 'Monto_Transferencia',
                title: 'Monto de la Transferencia'
            },
            {
                field: 'Detalle',
                title: 'Detalle'
            },

        ],
        filterable: true,
        toolbar: ["excel", "pdf"],
        excel: {
            fileName: "Lista de Transferencias.xlsx",
            filterable: true,
            allPages: true,
        },
        pdf: {
            fileName: "Lista de Transferencias.pdf",
            author: "UMCA",
            creator: "Marco Madriz Herrera",
            date: new Date(),

        }
    });
}
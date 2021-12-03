$(function () {
    obtenerRegistrosCuentas();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaCuentasLista()
function obtenerRegistrosCuentas() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/Retiros/RetornaRetirosLista'
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
                field: 'Numero_Cuenta',
                ///texto del encabezado
                title: 'Numero de Cuenta'
            },
            {
                field: 'NombreMoneda',
                title: 'Tipo de Moneda'
            },
            {
                field: 'Fecha',
                title: 'Fecha del Retiro'
            },
            {
                field: 'Monto_Retiro',
                title: 'Monto Retirado'
            },
  
        ],
        filterable: true,
        toolbar: ["excel", "pdf"],
        excel: {
            fileName: "Lista de Retiros.xlsx",
            filterable: true,
            allPages: true,
        },
        pdf: {
            fileName: "Lista de Retiros.pdf",
            author: "UMCA",
            creator: "Marco Madriz Herrera",
            date: new Date(),

        }
    });
}
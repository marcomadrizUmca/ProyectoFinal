$(function () {
    obtenerRegistrosDepositos();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaCuentasLista()
function obtenerRegistrosDepositos() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/Depositos/RetornaDepositosLista'
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
                field: 'Monto_Deposito',
                ///texto del encabezado
                title: 'Monto del Deposito'
            },
            {
                field: 'Numero_Cuenta',
                title: 'Numero de Cuenta'
            },
            {
                field: 'Nombre',
                title: 'Tipo de Moneda'
            },

        ],
        filterable: true,
        toolbar: ["excel", "pdf"],
        excel: {
            fileName: "Lista de Depositos.xlsx",
            filterable: true,
            allPages: true,
        },
        pdf: {
            fileName: "Lista de Depositos.pdf",
            author: "UMCA",
            creator: "Marco Madriz Herrera",
            date: new Date(),

        }
    });
}
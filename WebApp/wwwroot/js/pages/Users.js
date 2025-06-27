// js que maneja todo el comportamiento de la página de usuarios

//definir una clase JS, usando prototype

function UsersViewController() {

    this.ViewName = "Users";
    this.ApiEndPointName = "User";

    //Metodo constructor
    this.InitView = function () {

        console.log("User init view --> ok");
        this.LoadTable();
    }

    //Metodo para la carga de una tabla
    this.LoadTable = function () {

        //URL del API a invocar
        //https://localhost:7191/api/User/RetrieveAll

        var ca = new ControlActions();
        var service = this.ApiEndPointName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

        /*
          {
            "userCode": "aaguero",
            "name": "Allan",
            "email": "aaguero@ucenfotec.ac.cr",
            "password": "Cenfotec123!",
            "birthDate": "2025-06-07T11:57:40.89",
            "status": "AC",
            "id": 1,
            "created": "2025-06-07T17:57:42.293",
            "updated": "0001-01-01T00:00:00"
          }
        */

        var columns = [];
        columns[0] = { 'data': 'id' }
        columns[1] = { 'data': 'userCode' }
        columns[2] = { 'data': 'name' }
        columns[3] = { 'data': 'email' }
        columns[4] = { 'data': 'birthDate' }
        columns[5] = { 'data': 'status' }

        //Invocamos a datatable para convertir la tabla simple html en una tabla mas robusta
        $("#tblUsers").DataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns,
        });
    }
}

$(document).ready(function () {
    var vc = new UsersViewController();
    vc.InitView();
})
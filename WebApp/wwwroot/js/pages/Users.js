// js que maneja todo el comportamiento de la página de usuarios

//definir una clase JS, usando prototype

function UsersViewController() {

    this.ViewName = "Users";
    this.ApiEndPointName = "User";

    //Metodo constructor
    this.InitView = function () {

        console.log("User init view --> ok");
        this.LoadTable();

        //Asociar el evento de click al boton de crear
        $('#btnCreate').click(function () {
            var vc = new UsersViewController();
            vc.Create();
        });

        //Asociar el evento de click al boton de actualizar
        $('#btnUpdate').click(function () {
            var vc = new UsersViewController();
            vc.Update();
        });

        //Asociar el evento de click al boton de eliminar
        $('#btnDelete').click(function () {
            var vc = new UsersViewController();
            vc.Delete();
        });

        $('#btnRetrieveById').click(function () {
            var vc = new UsersViewController();
            vc.RetrieveById();
        });

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

        //asignar eventos de carga de datos o binding segun el clic en la tabla
        $('#tblUsers tbody').on('click', 'tr', function () {

            //extraemos la fila
            var row = $(this).closest('tr');

            //extraermos el dato
            //Esto nos devuelve el json de la fila seleccionada por el usuario
            //Segun la data devuelva por el API
            var userDTO = $('#tblUsers').DataTable().row(row).data();

            //Binding con el form
            $('#txtId').val(userDTO.id);
            $('#txtUserCode').val(userDTO.userCode);
            $('#txtName').val(userDTO.name);
            $('#txtEmail').val(userDTO.email);
            $('#txtStatus').val(userDTO.status);

            //fecha tiene un formato
            var onlyDate = userDTO.birthDate.split("T");
            $('#txtBirthDate').val(onlyDate[0]);
        })
    }

    this.Create = function () {
        var userDTO = {};
        //Atributos on valores default, que son controlados por el API
        userDTO.id = 0; //El API lo maneja como autoincremental
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01";

        //Atributos que el usuario debe ingresar
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.password = $('#txtPassword').val();


        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Create";

        ca.PostToAPI(urlService, userDTO, function () {
            //recargo de la tabla
            $('#tblUsers').DataTable().ajax.reload();
        })
    }

    this.Update = function () {

        var userDTO = {};
        //Atributos on valores default, que son controlados por el API
        userDTO.id = $('#txtId').val();
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01";

        //Atributos que el usuario debe ingresar
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.password = $('#txtPassword').val();

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Update";

        ca.PutToAPI(urlService, userDTO, function () {
            //recargo de la tabla
            $('#tblUsers').DataTable().ajax.reload();
        })
    }

    this.Delete = function () {

        var userDTO = {};

        //Atributos on valores default, que son controlados por el API
        userDTO.id = $('#txtId').val();
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01";

        //Atributos que el usuario debe ingresar
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.password = $('#txtPassword').val();

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Delete";

        ca.DeleteToAPI(urlService, userDTO, function () {
            //recargo de la tabla
            $('#tblUsers').DataTable().ajax.reload();
        })

    }

    this.RetrieveById = function () {
        var id = $('#txtSearchId').val();

        if (!id) {
            Swal.fire("Error", "Debe ingresar un ID válido", "warning");
            return;
        }

        var ca = new ControlActions();
        var urlService = ca.GetUrlApiService(this.ApiEndPointName + "/RetrieveById?id=" + id);

        $.ajax({
            url: urlService,
            type: "GET",
            success: function (userDTO) {
                $('#txtId').val(userDTO.id);
                $('#txtUserCode').val(userDTO.userCode);
                $('#txtName').val(userDTO.name);
                $('#txtEmail').val(userDTO.email);
                $('#txtStatus').val(userDTO.status);

                var onlyDate = userDTO.birthDate.split("T")[0];
                $('#txtBirthDate').val(onlyDate);
            },
            error: function (jqXHR) {
                if (jqXHR.status === 404) {
                    Swal.fire("No encontrado", "El usuario con ID " + id + " no existe.", "warning");
                } else {
                    Swal.fire("Error", "Error al recuperar el usuario: " + jqXHR.statusText, "error");
                }
            }
        });
    };
}

$(document).ready(function () {
    var vc = new UsersViewController();
    vc.InitView();
})
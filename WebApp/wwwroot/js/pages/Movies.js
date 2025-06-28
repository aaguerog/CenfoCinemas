// js que maneja todo el comportamiento de la página de peliculas

//definir una clase JS, usando prototype

function MoviesViewController() {

    this.ViewName = "Movies";
    this.ApiEndPointName = "Movie";

    //Metodo constructor
    this.InitView = function () {

        console.log("Movie init view --> ok");
        this.LoadTable();

        //Asociar el evento de click al boton de crear
        $('#btnCreate').click(function () {
            var vc = new MoviesViewController();
            vc.Create();
        });

        //Asociar el evento de click al boton de actualizar
        $('#btnUpdate').click(function () {
            var vc = new MoviesViewController();
            vc.Update();
        });

        //Asociar el evento de click al boton de eliminar
        $('#btnDelete').click(function () {
            var vc = new MoviesViewController();
            vc.Delete();
        });
    }

    //Metodo para la carga de una tabla
    this.LoadTable = function () {

        //URL del API a invocar
        //https://localhost:7191/api/Movie/RetrieveAll

        var ca = new ControlActions();
        var service = this.ApiEndPointName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(service);

        /*
          {
            "title": "The Matrix",
            "description": "A computer hacker learns from mysterious rebels ab",
            "releaseDate": "1999-03-31T00:00:00",
            "genre": "Sci-Fi",
            "director": "Lana Wachowski, Lilly Wachowsk",
            "id": 1,
            "created": "2025-06-08T18:57:16.387",
            "updated": "0001-01-01T00:00:00"
          }

            <th>Id</th>
            <th>Title</th>
            <th>Description</th>
            <th>ReleaseDate</th>
            <th>Genre</th>
            <th>Director</th>
        */

        var columns = [];
        columns[0] = { 'data': 'id' }
        columns[1] = { 'data': 'title' }
        columns[2] = { 'data': 'description' }
        columns[3] = { 'data': 'releaseDate' }
        columns[4] = { 'data': 'genre' }
        columns[5] = { 'data': 'director' }

        //Invocamos a datatable para convertir la tabla simple html en una tabla mas robusta
        $("#tblMovies").DataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns,
        });

        //Asingar eventos de carga de datos o binding segun el clic en la tabla
        $('#tblMovies tbody').on('click', 'tr', function () {

            //extraemos la fila

            var row = $(this).closest('tr');

            //extraemos el objeto de la fila
            var movieDTO = $("#tblMovies").DataTable().row(row).data();

            //Binding con el row
            $("#txtId").val(movieDTO.id);
            $("#txtTitle").val(movieDTO.title);
            $("#txtDescription").val(movieDTO.description);
            $("#txtGenre").val(movieDTO.genre);
            $("#txtDirector").val(movieDTO.director);

            //fecha tiene un formato
            var onlyDate = movieDTO.releaseDate.split("T");
            $("#txtReleaseDate").val(onlyDate[0]);
        })
    }

    this.Create = function () {

        var movieDTO = {};
        //Atributos on valores default, que son controlados por el API
        movieDTO.id = 0;
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        //Atributos que el usuario debe ingresar
        movieDTO.title = $("#txtTitle").val();
        movieDTO.description = $("#txtDescription").val();
        movieDTO.releaseDate = $("#txtReleaseDate").val();
        movieDTO.genre = $("#txtGenre").val();
        movieDTO.director = $("#txtDirector").val();

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Create";

        ca.PostToAPI(urlService, movieDTO, function () {
            //recargo de la tabla
            $("#tblMovies").DataTable().ajax.reload();
        });
    }

    this.Update = function () {

        var movieDTO = {};
        //Atributos on valores default, que son controlados por el API
        movieDTO.id = $("#txtId").val();
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        //Atributos que el usuario debe ingresar
        movieDTO.title = $("#txtTitle").val();
        movieDTO.description = $("#txtDescription").val();
        movieDTO.releaseDate = $("#txtReleaseDate").val();
        movieDTO.genre = $("#txtGenre").val();
        movieDTO.director = $("#txtDirector").val();

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Update";

        ca.PutToAPI(urlService, movieDTO, function () {
            //recargo de la tabla
            $("#tblMovies").DataTable().ajax.reload();
        });
    }

    this.Delete = function () {

        var movieDTO = {};
        //Atributos on valores default, que son controlados por el API
        movieDTO.id = $("#txtId").val();
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01";

        //Atributos que el usuario debe ingresar
        movieDTO.title = $("#txtTitle").val();
        movieDTO.description = $("#txtDescription").val();
        movieDTO.releaseDate = $("#txtReleaseDate").val();
        movieDTO.genre = $("#txtGenre").val();
        movieDTO.director = $("#txtDirector").val();

        //Enviar la data al API
        var ca = new ControlActions();
        var urlService = this.ApiEndPointName + "/Delete";

        ca.DeleteToAPI(urlService, movieDTO, function () {
            //recargo de la tabla
            $("#tblMovies").DataTable().ajax.reload();
        });
    }
}

$(document).ready(function () {
    var vc = new MoviesViewController();
    vc.InitView();
})
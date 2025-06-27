// js que maneja todo el comportamiento de la página de peliculas

//definir una clase JS, usando prototype

function MoviesViewController() {

    this.ViewName = "Movies";
    this.ApiEndPointName = "Movie";

    //Metodo constructor
    this.InitView = function () {

        console.log("Movie init view --> ok");
        this.LoadTable();
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
    }
}

$(document).ready(function () {
    var vc = new MoviesViewController();
    vc.InitView();
})
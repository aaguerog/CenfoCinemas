using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class MovieManager : BaseManager
    {
        /*
         * Metodo para la creacion de una película
         * Valida que el titulo de la película no esté registrado
         * Envia un correo electrónico a todos los usuarios con información del nuevo titulo disponible
         */

        public void Create(Movie movie)
        {
            try
            {
                //Validar que el título de la película no esté registrado

                var mCrud = new MovieCrudFactory();

                var mExist = mCrud.RetrieveByMovieTitle<Movie>(movie);

                if(mExist == null)
                {
                    mCrud.Create(movie);
                    //AHORA SIGUE EL ENVIO DE CORREO A TODOS LOS USUARIOS
                }
                else
                {
                    throw new Exception("El título de la película ya está registrado.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }
    }
}

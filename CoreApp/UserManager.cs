using CoreApp.Services;
using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class UserManager : BaseManager
    {
        /*
         * Metodo para la creacion de un usuario
         * Valida que el usuario sea mayor de 18 años
         * Valida que el codigo de un usuario este disponible
         * Valida que el correo electronico no este rgistrado
         * Envia un correo electronico de bienvenida
         */

        public void Create(User user)
        {
            try
            {
                //Validar la edad del usuario
                if (IsOver18(user))
                {
                    var uCrud = new UserCrudFactory();

                    //Consultamos en la BD si existe un usuario con el mismo código

                    var uExist = uCrud.RetrieveByUserCode<User>(user);

                    if (uExist == null)
                    {
                        //Consultamos si en la bd existe un usuario con ese email
                        uExist = uCrud.RetrieveByEmail<User>(user);

                        if (uExist == null)
                        {
                            uCrud.Create(user);
                            //AHORA SIGUE EL ENVIO DE CORREO

                            var emailService = new EmailService();
                            emailService.SendWelcomeEmail(user.Email, user.Name);

                            Console.WriteLine("Usuario creado exitosamente y correo de bienvenida enviado.");
                        }
                        else
                        {
                            throw new Exception("El correo electrónico ya está registrado.");
                        }
                    }
                    else
                    {
                        throw new Exception("El código de usuario no está disponible.");
                    }
                }
                else
                {
                    throw new Exception("El usuario debe ser mayor de 18 años.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        private bool IsOver18(User user)
        {
            var currentDate = DateTime.Now;
            int age = currentDate.Year - user.BirthDate.Year;

            if (user.BirthDate > currentDate.AddYears(-age).Date)
            {
                age--;
            }
            return age >= 18;
        }
    }
}

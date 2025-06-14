using DataAccess.DAOs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public abstract class CrudFactory

    //Clase padre/madre de los cruds
    //Define como se hacen cruds en la arquitectura

    {
        protected SqlDao _sqlDao;

        //Definir los metodos que forman parte del contrato
        // C = Create
        // R = Retrieve
        // U = Update
        // D = Delete

        public abstract void Create(BaseDTO baseDTO);
        public abstract void Update(BaseDTO baseDTO);
        public abstract void Delete(BaseDTO baseDTO);
        public abstract T Retrieve<T>();
        public abstract T RetrieveById<T>();
        public abstract List<T> RetrieveAll<T>();

    }
}

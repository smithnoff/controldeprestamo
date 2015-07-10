using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;
namespace CapaNegocio
{
    public class sesion
    {
        public persona query1;
        

        public IQueryable<persona> user(){
            CapaModelo.dbControlCobranzasEntities ob = new dbControlCobranzasEntities();

             var query = ob.personas;


             return query;
         
           
            
        }
    }


}

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
        

        public void user(){
            CapaModelo.dbControlCobranzasEntities ob = new dbControlCobranzasEntities();

             var query = ob.personas.Where(p => p.pkPersonaID == 23589144).FirstOrDefault();


             query1 = query;
         
           
            
        }
    }


}

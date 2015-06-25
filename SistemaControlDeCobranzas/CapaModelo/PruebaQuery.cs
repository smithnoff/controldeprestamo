using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
namespace CapaModelo
{
   public class PruebaQuery
    {
        dbControlCobranzasEntities dbControlCobranzasEntities1 = new dbControlCobranzasEntities();

        public List<SetUsuario> llenargrid(){

            dbControlCobranzasEntities1.ContextOptions.LazyLoadingEnabled = false;

            // ESTE ES UN SELECT PUEDES BUSCAR LOS CAMPOS RELACIONADOS TAMBIEN COMO UN INNER JOIN... MOLA VERDAD?
            
            var query = from usuario1 in dbControlCobranzasEntities1.usuarios
                        select new SetUsuario { Id = usuario1.pkUsuariosID, UserName = usuario1.asUsername, NAME=usuario1.persona.asNombre, PASSWORD= usuario1.asPassword, ROL= usuario1.rolUsuario.asDescripcion } ;

            //var query = dbControlCobranzasEntities1.usuarios.Where(p => p.pkUsuariosID == 1).ToList();

            return query.ToList();
                                     
            
           
        }

    }

  public class SetUsuario
   {
       public int Id { get; set; }
       public string UserName { get; set; }
       public string NAME { get; set; }
       public string PASSWORD { get; set; }
       public string ROL { get; set; }
      
   }
}

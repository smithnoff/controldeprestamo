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
        public usuarios tablaUsuario;
        public CapaModelo.dbCobranzasEntities ob;
        
        public IQueryable<usuarios> user()
        {
            ob = new dbCobranzasEntities();

            var query = ob.usuarios;
            
            return query;            
        }

        public IQueryable<Ubicacions> ciudades()
        {
            ob = new dbCobranzasEntities();

            var query = ob.Ubicacions;
            
            return query;
        }

        public void addCliente(string cedula, string nombre, string apellido, int codRol, int codUbicacion )
        {
            tablaUsuario = new usuarios();

            tablaUsuario.asCedula = cedula;
            tablaUsuario.asNombre = nombre;
            tablaUsuario.asApellido = apellido;
            tablaUsuario.fkRolUsuarioID = codRol;
            tablaUsuario.fkUbicacionID = codUbicacion;
            tablaUsuario.asUsername = null;
            tablaUsuario.asPassword = null;
            tablaUsuario.FechaCreacion = DateTime.Now;

            using (dbCobranzasEntities db = new dbCobranzasEntities())
            {
                db.AddTousuarios(tablaUsuario);
                db.SaveChanges();
            }

        }

        public void updateUsuarios(int id, string ced, string nom, string apel, int ubi)
        {
            ob = new dbCobranzasEntities();                 

            var u = ob.usuarios.Where(p => p.pkUsuariosID == id).FirstOrDefault();

            u.asCedula = ced;
            u.asNombre = nom;
            u.asApellido = apel;
            u.fkUbicacionID = ubi;              
            ob.SaveChanges();
                 
            
        }

        public void addUbicaciones(string ciudad)
        {
            Ubicacions u = new Ubicacions();
            u.asCiudades = ciudad;

            using (dbCobranzasEntities db = new dbCobranzasEntities())
            {
                db.AddToUbicacions(u);
                db.SaveChanges();
            }
            
        }

        public void updateUbicaciones(int id, string ciu)
        {
            ob = new dbCobranzasEntities();

            var u = ob.Ubicacions.Where(p => p.pkUbicacionID == id).FirstOrDefault();

            u.asCiudades = ciu;
            ob.SaveChanges();
        }
      
    }


}

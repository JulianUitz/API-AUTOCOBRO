using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nuevapicobro.Domain.Entities;

namespace nuevapicobro.Services.Features
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAllUsuarios();
        Usuario GetUsuarioById(Usuario usuario);
    }
    public class UsuarioService
    {
        private readonly DbPayUsContext _context;
        //lo que hago es aqui es pasarle la lectura de la badse de datos a los servicios para qye pueda leerlos 

        public UsuarioService(DbPayUsContext context)
        {
            _context = context;

        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            // Lógica para obtener todos los usuarios
            return _context.Usuarios.ToList();
            //me devuelve la lista de usuarios
        }

    }
}
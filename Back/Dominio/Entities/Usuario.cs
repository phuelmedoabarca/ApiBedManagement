using Domain.Excepcions;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario
    {
        public Usuario() { }
        public Usuario(Guid idUsuario, DocumentoIdentidad rut, string nombre, string contrasena, ContactoEmail email, Guid idRol) 
        {
            IdUsuario = idUsuario;
            Rut = rut;
            Nombre = nombre;
            Contrasena = contrasena;
            Email = email;
            IdRol = idRol;
        }
        public Guid IdUsuario { get; set; }
        public DocumentoIdentidad Rut { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public ContactoEmail Email { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Guid IdRol { get; set; }
        public static Usuario Create(Guid idUsuario, DocumentoIdentidad rut, string nombre, string contrasena, ContactoEmail email, Guid idRol) 
        {
            if ((string.IsNullOrEmpty(nombre)) || (string.IsNullOrEmpty(contrasena)))
                throw new BadRequestException("Debe ingresar todos los campos.");

            var usuario = new Usuario(idUsuario, rut, nombre, contrasena, email, idRol);
            usuario.FechaCreacion = DateTime.UtcNow;

            return usuario;
        }
        public void SetUsuario(string nombre, string contrasena, string email, Guid idRol)
        {
            var newEmail = new ContactoEmail(email);
            Nombre = nombre;
            Contrasena = contrasena;
            Email = newEmail;
            IdRol = idRol;
            FechaModificacion = DateTime.UtcNow;
        }
    }
}

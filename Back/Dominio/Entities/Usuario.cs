using Domain.Excepcions;
using Domain.ValueObject;

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

            byte[] contrasenaEncriptada = System.Text.Encoding.Unicode.GetBytes(contrasena);
            var passwordEnctiptada = Convert.ToBase64String(contrasenaEncriptada);

            var usuario = new Usuario(idUsuario, rut, nombre, passwordEnctiptada, email, idRol);
            usuario.FechaCreacion = DateTime.UtcNow;

            return usuario;
        }
        public void SetUsuario(string nombre, string contrasena, string email, Guid idRol)
        {
            if ((string.IsNullOrEmpty(nombre)) || (string.IsNullOrEmpty(contrasena)))
                throw new BadRequestException("Debe ingresar todos los campos.");

            byte[] contrasenaEncriptada = System.Text.Encoding.Unicode.GetBytes(contrasena);
            var passwordEnctiptada = Convert.ToBase64String(contrasenaEncriptada);

            var newEmail = new ContactoEmail(email);
            Nombre = nombre;
            Contrasena = passwordEnctiptada;
            Email = newEmail;
            IdRol = idRol;
            FechaModificacion = DateTime.UtcNow;
        }
    }
}

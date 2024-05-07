using Domain.Excepcions;
using Domain.ValueObject;
using System.Security.Cryptography;
using System.Text;

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
        public UsuarioRol Rol { get; set; }
        public static Usuario Create(Guid idUsuario, DocumentoIdentidad rut, string nombre, string contrasena, ContactoEmail email, Guid idRol) 
        {
            if ((string.IsNullOrEmpty(nombre)) || (string.IsNullOrEmpty(contrasena)))
                throw new BadRequestException("Debe ingresar todos los campos.");

            string hashedContrasena = HashPassword(contrasena);

            var usuario = new Usuario(idUsuario, rut, nombre, hashedContrasena, email, idRol);
            usuario.FechaCreacion = DateTime.UtcNow;

            return usuario;
        }
        public void SetUsuario(string nombre, string contrasena, string email, Guid idRol)
        {
            if ((string.IsNullOrEmpty(nombre)) || (string.IsNullOrEmpty(contrasena)))
                throw new BadRequestException("Debe ingresar todos los campos.");

            string hashedContrasena = HashPassword(contrasena);

            var newEmail = new ContactoEmail(email);
            Nombre = nombre;
            Contrasena = hashedContrasena;
            Email = newEmail;
            IdRol = idRol;
            FechaModificacion = DateTime.UtcNow;
        }
        public string ValidPassword(string contrasena)
        {
            var passwordHash = HashPassword(contrasena);
            return passwordHash;
        }
        private static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = sha256Hash.ComputeHash(passwordBytes);

                StringBuilder hexString = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    hexString.Append(b.ToString("x2"));
                }

                return hexString.ToString();
            }
        }
    }
}

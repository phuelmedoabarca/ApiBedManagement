﻿
namespace Application.Usuarios.Command.Delete
{
    public class UsuarioDeleteResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime FechaEliminacion { get; set; }
    }
}

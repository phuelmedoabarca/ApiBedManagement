﻿using Domain.Entities;
using Domain.Excepcions;
using Domain.Repositorio;
using Domain.ValueObject;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Usuarios.Command.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IConfiguration _configuration;
        public LoginHandler(IUsuarioRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var email = new ContactoEmail(request.Email);
            var usuario = await _repository.GetByEmailUsuario(email.Email);
            if (usuario is null)
                throw new NotFoundException($"usuario Email:{request.Email}");

            byte[] contrasenaEncriptada = System.Text.Encoding.Unicode.GetBytes(request.Contrasena);
            var passwordEnctiptada = Convert.ToBase64String(contrasenaEncriptada);
            if (passwordEnctiptada != usuario.Contrasena)
                throw new BadRequestException("Contraseña no valida.");

            var token = GenerateToken(usuario);

            return new LoginResponse
            {
                Token = token,
                FechaCreacion = DateTime.UtcNow
            };
        }
        private string GenerateToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim("UsuarioId", usuario.IdUsuario.ToString()),
                new Claim("RolId", usuario.IdRol.ToString())
            };

            var keyString = _configuration["Jwt:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = credentials,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }
    }
}

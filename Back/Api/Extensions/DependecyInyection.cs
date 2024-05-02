using Application.Ingresos.Command.Create;
using Application.Pacientes.Command.Create;
using Application.Pacientes.Command.Set;
using Application.Pacientes.Queries.GetByRutPaciente;
using Application.Pacientes.Queries.GetList;
using Application.Usuarios.Command.Create;
using Application.Usuarios.Command.Delete;
using Application.Usuarios.Command.Set;
using Application.Usuarios.Queries.GetByRutUsuario;
using Application.Usuarios.Queries.GetList;
using Domain.Entities;
using Domain.Repositorio;
using Infraestructura;
using MediatR;

namespace Api.Extensions
{
    public static class DependecyInyection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnidadRepository, UnidadRepository>();
            services.AddScoped<ISalaRepository, SalaRepository>();
            services.AddScoped<ICamaRepository, CamaRepository>();
            services.AddScoped<IComunaRepository, ComunaRepository>();
            services.AddScoped<IUsuarioRolRepository, UsuarioRolRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IIngresoRepository, IngresoRepository>();
        }
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<PacienteCreateCommand, PacienteCreateResponse>, PacienteCreateHandler>();
            services.AddScoped<IRequestHandler<PacienteSetCommand, PacienteSetResponse>, PacienteSetHandler>();
            services.AddScoped<IRequestHandler<GetListPacienteQuery, List<Paciente>>, GetListPacienteHandler>();
            services.AddScoped<IRequestHandler<GetByRutPacienteQuery, Paciente>, GetByRutPacienteHandler>();
            services.AddScoped<IRequestHandler<UsuarioCreateCommand, UsuarioCreateResponse>, UsuarioCreateHandler>();
            services.AddScoped<IRequestHandler<UsuarioDeleteCommand, UsuarioDeleteResponse>, UsuarioDeleteHandler>();
            services.AddScoped<IRequestHandler<UsuarioSetCommand, UsuarioSetResponse>, UsuarioSetHandler>();
            services.AddScoped<IRequestHandler<GetListUsuarioQuery, List<Usuario>>, GetListUsuarioHandler>();
            services.AddScoped<IRequestHandler<GetByRutUsuarioQuery, Usuario>, GetByRutUsuarioHandler>();
            services.AddScoped<IRequestHandler<IngresoCreateCommand, IngresoCreateResponse>, IngresoCreateHandler>();
        }
    }
}

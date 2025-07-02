using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.AuditoriaDtos;
using Application.DTOs.ClienteDtos;
using Application.DTOs.DetalleDtos;
using Application.DTOs.FacturaDtos;
using Application.DTOs.OrdenServicioDtos;
using Application.DTOs.RepuestoDtos;
using Application.DTOs.RolUsuarioDto;
using Application.DTOs.TipoServicioDtos;
using Application.DTOs.UsuarioDtos;
using Application.DTOs.VehiculoDtos;
using AutoMapper;
using Domain.Entities;

namespace ApiSgta.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Auditoria
            CreateMap<Auditoria, AuditoriaDto>()
                    .ForMember(dest => dest.UsuarioNombre, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nombre : null));
            CreateMap<CreateAuditoriaDto, Auditoria>();

            // Cliente
            CreateMap<Cliente, ClienteDto>().ReverseMap(); // coincide bien
            CreateMap<CreateClienteDto, Cliente>().ReverseMap();
            CreateMap<UpdateClienteDto, Cliente>();

            // DetalleOrden
            CreateMap<DetalleOrden, DetalleOrdenDto>()
                .ForMember(dest => dest.RepuestoNombre, opt => opt.MapFrom(src => src.Repuesto != null ? src.Repuesto.Nombre : null));
            CreateMap<CreateDetalleOrdenDto, DetalleOrden>();
            CreateMap<UpdateDetalleOrdenDto, DetalleOrden>();

            // Factura
            CreateMap<Factura, FacturaDto>().ReverseMap();
            CreateMap<CreateFacturaDto, Factura>();
            CreateMap<UpdateFacturaDto, Factura>();

            // OrdenServicio
            CreateMap<OrdenServicio, OrdenServicioDto>()
                .ForMember(dest => dest.VehiculoDescripcion, opt => opt.MapFrom(src => src.Vehiculo != null ? $"{src.Vehiculo.Marca} {src.Vehiculo.Modelo}" : null))
                .ForMember(dest => dest.TipoServicioNombre, opt => opt.MapFrom(src => src.TipoServicio != null ? src.TipoServicio.Nombre : null))
                .ForMember(dest => dest.UsuarioNombre, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nombre : null));
            CreateMap<CreateOrdenServicioDto, OrdenServicio>();
            CreateMap<UpdateOrdenServicioDto, OrdenServicio>();

            // Repuesto
            CreateMap<Repuesto, RepuestoDto>().ReverseMap();
            CreateMap<CreateRepuestoDto, Repuesto>().ReverseMap();
            CreateMap<UpdateRepuestoDto, Repuesto>();

            // RolUsuario
            CreateMap<RolUsuario, RolUsuarioDto>()
                .ForMember(dest => dest.UsuariosNombres, opt => opt.MapFrom(src => src.Usuarios != null ? src.Usuarios.Select(u => u.Nombre).ToList()! : new List<string>()));
            CreateMap<CreateRolUsuarioDto, RolUsuario>().ReverseMap();
            CreateMap<UpdateRolUsuarioDto, RolUsuario>();

            // TipoServicio
            CreateMap<TipoServicio, TipoServicioDto>()
                .ForMember(dest => dest.OrdenServiciosIds, opt => opt.MapFrom(src => src.OrdenServicios != null ? src.OrdenServicios.Select(o => o.Id).ToList() : new List<int>()));
            CreateMap<CreateTipoServicioDto, TipoServicio>().ReverseMap();
            CreateMap<UpdateTipoServicioDto, TipoServicio>();

            // Usuario
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.RolUsuarioNombre, opt => opt.MapFrom(src => src.RolUsuario != null ? src.RolUsuario.Nombre : null));
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<UpdateUsuarioDto, Usuario>();

            // Vehiculo
            CreateMap<Vehiculo, VehiculoDto>()
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.Cliente != null ? src.Cliente.Nombre : null));
            CreateMap<CreateVehiculoDto, Vehiculo>().ReverseMap();
            CreateMap<UpdateVehiculoDto, Vehiculo>();
        }
    }
}
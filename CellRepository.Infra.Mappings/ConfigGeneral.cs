using AutoMapper;
using CellRepository.ApplicationModels;
using CellRepository.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Infra.Mappings
{
    public static class ConfigGeneral
    {
        public static IProfileExpression OnConfigure(IProfileExpression cfg)
        {
            cfg.CreateMap<UserLoginDto, UserLoginEntity>();
            cfg.CreateMap<UserLoginEntity, UserLoginDto>();

            return cfg;
        }
    }
}

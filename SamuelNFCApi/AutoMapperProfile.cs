using SamuelNFCApi.Models.Business;
using SamuelNFCApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamuelNFCApi
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public static void Run() => AutoMapper.Mapper.Initialize(a => { a.AddProfile<AutoMapperProfile>(); });

        public AutoMapperProfile()
        {
            AllowNullDestinationValues = true;

            CreateMap<ClientPersonal, ClientPersonalDto>();
            CreateMap<ClientPersonalDto, ClientPersonal>();

            CreateMap<ClientSocial, ClientSocialDto>();
            CreateMap<ClientSocialDto, ClientSocial>();

        }
    }
}
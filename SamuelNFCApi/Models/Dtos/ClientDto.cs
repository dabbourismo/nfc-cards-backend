using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamuelNFCApi.Models.Dtos
{
    public class ClientDto
    {
        public ClientPersonalDto ClientPersonalDto { get; set; }
        public ClientSocialDto ClientSocialDto { get; set; }
    }
}
using SamuelNFCApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamuelNFCApi.Models.Business
{
    public class ClientPersonal
    {
        public int Id { get; set; }

      

        public string Username { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public bool NameIsHidden { get; set; }

        public string Email { get; set; }
        public bool EmailIsHidden { get; set; }


        public string City { get; set; }
        public bool CityIsHidden { get; set; }

        public string District { get; set; }
        public bool DistrictIsHidden { get; set; }

        public string Title { get; set; }
        public bool TitleIsHidden { get; set; }

        public string Company { get; set; }
        public bool CompanyIsHidden { get; set; }

        public string Address { get; set; }
        public bool AddressIsHidden { get; set; }

        public string Phone { get; set; }
        public bool PhoneIsHidden { get; set; }

        public string DescribeYourself { get; set; }
        public bool DescribeYourselfIsHidden { get; set; }

        public string YoutubeEmbededURL { get; set; }
        public bool YoutubeEmbededURLIsHidden { get; set; }


        public string Link { get; set; }
        public string SerialNumber { get; set; }

    }
}
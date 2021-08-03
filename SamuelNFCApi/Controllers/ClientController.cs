using AutoMapper.QueryableExtensions;
using SamuelNFCApi.Models.Business;
using SamuelNFCApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SamuelNFCApi.Controllers
{
    [System.Web.Http.RoutePrefix("api/client")]
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]
    public class ClientController : ApiController
    {
        private readonly AppDbContext context;
        public ClientController()
        {
            context = new AppDbContext();
        }


        [HttpGet]
        [Route("clientGet")]
        public async Task<ClientDto> ClientGet(string link)
        {
            var clientPersonal = await context.ClientsPersonal
                .ProjectTo<ClientPersonalDto>()
                .FirstOrDefaultAsync(x => x.Link == link);

            if (clientPersonal != null)
            {
                var clientSocial = await context.ClientsSocial.Where(x => x.ClientPersonalId == clientPersonal.Id)
               .ProjectTo<ClientSocialDto>()
               .FirstOrDefaultAsync();

                var client = new ClientDto()
                {
                    ClientPersonalDto = clientPersonal,
                    ClientSocialDto = clientSocial
                };
                return client;
            }

            return null;
        }

        [HttpGet]
        [Route("login")]
        public async Task<ClientDto> Login(string username, string password)
        {
            var clientPersonal = await context.ClientsPersonal
                .ProjectTo<ClientPersonalDto>()
                .FirstOrDefaultAsync(x => x.Username == username && x.Password == password);

            if (clientPersonal != null)
            {
                var clientSocial = await context.ClientsSocial.Where(x => x.ClientPersonalId == clientPersonal.Id)
               .ProjectTo<ClientSocialDto>()
               .FirstOrDefaultAsync();

                var client = new ClientDto()
                {
                    ClientPersonalDto = clientPersonal,
                    ClientSocialDto = clientSocial
                };
                return client;
            }

            return null;
        }


        [HttpGet]
        [Route("loginSerialOnly")]
        public async Task<ClientDto> LoginSerialOnly(string serial)
        {
            var clientPersonal = await context.ClientsPersonal
                .ProjectTo<ClientPersonalDto>()
                .FirstOrDefaultAsync(x => x.SerialNumber == serial);

            if (clientPersonal != null)
            {
                if (clientPersonal.Username != null && clientPersonal.Password != null)
                {
                    return null;
                }

                var clientSocial = await context.ClientsSocial.Where(x => x.ClientPersonalId == clientPersonal.Id)
                    .ProjectTo<ClientSocialDto>()
                    .FirstOrDefaultAsync();

                var client = new ClientDto()
                {
                    ClientPersonalDto = clientPersonal,
                    ClientSocialDto = clientSocial
                };

                return client;
            }

            return null;         
        }

        [HttpPost]
        [Route("ClientPersonalUpdate")]
        public async Task<HttpResponseMessage> ClientPersonalUpdate([FromBody] ClientPersonalDto clientPersonalDto)
        {

            var oldClientPersonal = await context.ClientsPersonal.FindAsync(clientPersonalDto.Id);

            oldClientPersonal.Username = clientPersonalDto.Username;
            oldClientPersonal.Password = clientPersonalDto.Password;

            oldClientPersonal.Name = clientPersonalDto.Name;
            oldClientPersonal.NameIsHidden = clientPersonalDto.NameIsHidden;

            oldClientPersonal.Email = clientPersonalDto.Email;
            oldClientPersonal.EmailIsHidden = clientPersonalDto.EmailIsHidden;

            oldClientPersonal.City = clientPersonalDto.City;
            oldClientPersonal.CityIsHidden = clientPersonalDto.CityIsHidden;

            oldClientPersonal.District = clientPersonalDto.District;
            oldClientPersonal.DistrictIsHidden = clientPersonalDto.DistrictIsHidden;

            oldClientPersonal.Title = clientPersonalDto.Title;
            oldClientPersonal.TitleIsHidden = clientPersonalDto.TitleIsHidden;

            oldClientPersonal.Company = clientPersonalDto.Company;
            oldClientPersonal.CompanyIsHidden = clientPersonalDto.CompanyIsHidden;

            oldClientPersonal.Address = clientPersonalDto.Address;
            oldClientPersonal.AddressIsHidden = clientPersonalDto.AddressIsHidden;

            oldClientPersonal.Phone = clientPersonalDto.Phone;
            oldClientPersonal.PhoneIsHidden = clientPersonalDto.PhoneIsHidden;

            oldClientPersonal.DescribeYourself = clientPersonalDto.DescribeYourself;
            oldClientPersonal.DescribeYourselfIsHidden = clientPersonalDto.DescribeYourselfIsHidden;


            oldClientPersonal.YoutubeEmbededURL = clientPersonalDto.YoutubeEmbededURL;
            oldClientPersonal.YoutubeEmbededURLIsHidden = clientPersonalDto.YoutubeEmbededURLIsHidden;


            await context.SaveChangesAsync();
            return Request.CreateResponse(HttpStatusCode.OK);

        }


        [HttpPost]
        [Route("ClientSocialUpdate")]
        public async Task<HttpResponseMessage> ClientSocialUpdate([FromBody] ClientSocialDto clientSocialDto)
        {

            var oldClientSocial = await context.ClientsSocial.FindAsync(clientSocialDto.Id);

            oldClientSocial.Id = clientSocialDto.Id;
            oldClientSocial.ClientPersonalId = clientSocialDto.ClientPersonalId;

            oldClientSocial.FacebookUrl = clientSocialDto.FacebookUrl;
            oldClientSocial.FacebookUrlFlyOn = clientSocialDto.FacebookUrlFlyOn;

            oldClientSocial.TwitterUrl = clientSocialDto.TwitterUrl;
            oldClientSocial.TwitterUrlFlyOn = clientSocialDto.TwitterUrlFlyOn;

            oldClientSocial.TikTokUrl = clientSocialDto.TikTokUrl;
            oldClientSocial.TikTokUrlFlyOn = clientSocialDto.TikTokUrlFlyOn;

            oldClientSocial.SlapUrl = clientSocialDto.SlapUrl;
            oldClientSocial.SlapUrlFlyOn = clientSocialDto.SlapUrlFlyOn;

            oldClientSocial.WhatsAppUrl = clientSocialDto.WhatsAppUrl;
            oldClientSocial.WhatsAppUrlFlyOn = clientSocialDto.WhatsAppUrlFlyOn;

            oldClientSocial.YouTubeUrl = clientSocialDto.YouTubeUrl;
            oldClientSocial.YouTubeUrlFlyOn = clientSocialDto.YouTubeUrlFlyOn;

            oldClientSocial.InstagramUrl = clientSocialDto.InstagramUrl;
            oldClientSocial.InstagramUrlFlyOn = clientSocialDto.InstagramUrlFlyOn;

            oldClientSocial.LinkedInUrl = clientSocialDto.LinkedInUrl;
            oldClientSocial.LinkedInUrlFlyOn = clientSocialDto.LinkedInUrlFlyOn;

            oldClientSocial.GoogleMapsUrl = clientSocialDto.GoogleMapsUrl;
            oldClientSocial.GoogleMapsUrlFlyOn = clientSocialDto.GoogleMapsUrlFlyOn;


            oldClientSocial.TelegramUrl = clientSocialDto.TelegramUrl;
            oldClientSocial.TelegramUrlFLyOn = clientSocialDto.TelegramUrlFLyOn;


            oldClientSocial.ClubhoseUrl = clientSocialDto.ClubhoseUrl;
            oldClientSocial.ClubhouseUrlFlyOn = clientSocialDto.ClubhouseUrlFlyOn;


            await context.SaveChangesAsync();
            return Request.CreateResponse(HttpStatusCode.OK);

        }



        [HttpPost]
        [Route("ClientsGenerate")]
        public async Task<HttpResponseMessage> ClientsGenerate(int numberOfRecords)
        {
            Random randomSerialGenerator = new Random();
            var randomSerialList = new List<int>();
            int randomSerial;

            var lastRecord = await context.ClientsPersonal.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            var databaseSerialList = await context.ClientsPersonal.Select(x => x.SerialNumber).ToListAsync();

            int j = 0;
            while (j < numberOfRecords)
            {
                randomSerial = randomSerialGenerator.Next(100000000, 999999999);
                if (!databaseSerialList.Contains(randomSerial.ToString()))
                {
                    randomSerialList.Add(randomSerial);
                    j++;
                }

            }
            string lastId;
            if (lastRecord != null)
            {
                lastId = string.IsNullOrEmpty(lastRecord.Link) ? "0" : lastRecord.Link.Substring(lastRecord.Link.LastIndexOf('/') + 1);
            }
            else
            {
                lastId = "0";
            }
            var clientPersonalList = new List<ClientPersonal>();
            var startIndex = Convert.ToInt32(lastId) + 1;
            var endIndex = numberOfRecords + Convert.ToInt32(lastId);
            int serialListindexCounter = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {

                var clientPersonal = new ClientPersonal()
                {
                    Link = $"https://jokar.org/showprofile/{i}",
                    SerialNumber = randomSerialList[serialListindexCounter].ToString()
                };
                clientPersonalList.Add(clientPersonal);
                serialListindexCounter++;
            }
            context.ClientsPersonal.AddRange(clientPersonalList);
            await context.SaveChangesAsync();


            foreach (var clientPersonal in clientPersonalList)
            {
                var clientSocial = new ClientSocial()
                {
                    ClientPersonalId = clientPersonal.Id
                };
                context.ClientsSocial.Add(clientSocial);
            }

            await context.SaveChangesAsync();
            return Request.CreateResponse(HttpStatusCode.OK);

        }


        [HttpPost]
        [Route("ProfilePicsUpload")]
        public async Task<HttpResponseMessage> ProfilePicsUpload(int userId)
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                         HttpContext.Current.Request.Files[0] : null;

            if (file != null)
            {
                FileUploader.UploadFTPFile(file.FileName
                           , userId
                           , file
                           , HttpContext.Current.Server.MapPath("~/ProfilePics"));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

        [HttpPost]
        [Route("PdfUpload")]
        public async Task<HttpResponseMessage> PdfUpload(int userId)
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                         HttpContext.Current.Request.Files[0] : null;

            if (file != null)
            {
                FileUploader.UploadFTPFile(file.FileName
                           , userId
                           , file
                           , HttpContext.Current.Server.MapPath("~/Pdfs"));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

    }
}

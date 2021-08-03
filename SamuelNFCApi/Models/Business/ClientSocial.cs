using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamuelNFCApi.Models.Business
{
    public class ClientSocial
    {
        public int Id { get; set; }

        public int ClientPersonalId { get; set; }
        public ClientPersonal ClientPersonal { get; set; }

        public string FacebookUrl { get; set; }
        public bool FacebookUrlFlyOn { get; set; }

        public string TwitterUrl { get; set; }
        public bool TwitterUrlFlyOn { get; set; }

        public string TikTokUrl { get; set; }
        public bool TikTokUrlFlyOn { get; set; }

        public string SlapUrl { get; set; }
        public bool SlapUrlFlyOn { get; set; }

        public string WhatsAppUrl { get; set; }
        public bool WhatsAppUrlFlyOn { get; set; }

        public string YouTubeUrl { get; set; }
        public bool YouTubeUrlFlyOn { get; set; }

        public string InstagramUrl { get; set; }
        public bool InstagramUrlFlyOn { get; set; }

        public string LinkedInUrl { get; set; }
        public bool LinkedInUrlFlyOn { get; set; }

        public string GoogleMapsUrl { get; set; }
        public bool GoogleMapsUrlFlyOn { get; set; }

        public string TelegramUrl { get; set; }
        public bool TelegramUrlFLyOn { get; set; }

        public string ClubhoseUrl { get; set; }
        public bool ClubhouseUrlFlyOn { get; set; }
    }
}
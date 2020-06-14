using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertAPI.Entities
{
    public class Campaign
    {
        public int IdCampaign { get; set; }
        public int IdClient { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float PricePerSquareMeter { get; set; }
        public int FromIdBuilding { get; set; }
        public int ToIdBuilding { get; set; }
        public virtual Client Clients { get; set; }
        public virtual Building Buildings { get; set; }
        public virtual ICollection<Banner> Banners { get; set; }
    }
}

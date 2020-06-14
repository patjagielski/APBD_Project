using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertAPI.Entities
{
    public class Banner
    {
       public int IdAdvertisement { get; set; }
        public int Name { get; set; }
        public float Price { get; set; }
        public int IdCampaign { get; set; }
        public float Area { get; set; }
        public virtual Campaign Campaign { get; set; }

    }
}

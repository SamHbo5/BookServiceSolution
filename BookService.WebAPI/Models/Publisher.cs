using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Models
{
    public class Publisher : EntityBase
    {
        public string Name { get; set; }

        public string Country { get; set; }
    }
}

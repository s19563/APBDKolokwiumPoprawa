using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumEF.Models.DTOs
{
    public class OrganizationDto
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumEF.Models.DTOs
{
    public class TeamDto
    {
        public int TeamID { get; set; }
        public int OrganizationID { get; set; }
        public string TeamName { get; set; }
        public string? TeamDescription { get; set; }
        public Organization Organization { get; set; }
        public ICollection<Membership> Memberships { get; set; }
    }
}

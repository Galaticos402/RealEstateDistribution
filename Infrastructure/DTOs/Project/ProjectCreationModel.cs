using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTOs.Project
{
    public class ProjectCreationModel
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string BuildingContractor { get; set; }
        public string Area { get; set; }
        public string Scale { get; set; }
        public string JuridicalStatus { get; set; }
        public string IntroPageLink { get; set; }
        public string ProjectStatus { get; set; }
    }
}

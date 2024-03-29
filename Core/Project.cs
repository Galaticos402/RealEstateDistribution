﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string BuildingContractor { get; set; }
        public string Area { get; set; }
        public string Scale { get; set; }
        public string JuridicalStatus { get; set; }
        public string IntroPageLink { get; set; }
        public string ProjectStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public int InvestorId { get; set; }
        public virtual List<Division> Divisions { get; set; }
        public virtual Investor Investor { get; set; }
    }
}

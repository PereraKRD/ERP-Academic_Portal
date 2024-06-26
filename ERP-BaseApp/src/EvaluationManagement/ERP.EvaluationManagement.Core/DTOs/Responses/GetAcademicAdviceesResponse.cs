﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.EvaluationManagement.Core.DTOs.Responses
{
    public class GetAcademicAdviceesResponse
    {
        public Guid StudentId { get; set; }
        public string RegistrationNum { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string AcademicAdvisorName { get; set; }
        public string BatchName { get; set; }
    }
}

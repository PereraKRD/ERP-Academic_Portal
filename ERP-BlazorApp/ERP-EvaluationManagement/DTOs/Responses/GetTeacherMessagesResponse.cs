﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_EvaluationManagement.DTOs.Responses
{
    public class GetTeacherMessagesResponse
    {
        public Guid RequestId { get; set; }
        public string Message { get; set; }
        public string SenderName { get; set; }
        public string RecieverName { get; set; }
    }
}

using HomeworkPeople.Data;
using System;
using System.Collections.Generic;

namespace HomeworkPeople.Models
{
    public class ErrorViewModel
    {
        public List<Person> People { get; set; }
        public string Message {get;set;}
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

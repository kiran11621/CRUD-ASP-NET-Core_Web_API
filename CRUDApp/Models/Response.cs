﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApp.Models
{
    public class Response
    {

        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public Employee Employee { get; set; }

        public List<Employee> listEmployee { get; set; }
    }
}

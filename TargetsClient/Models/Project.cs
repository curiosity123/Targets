﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetsClient
{
    public class Project
    {


        public Project()
        {
            Id = Guid.NewGuid();
            Steps = new List<Step>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public List<Step> Steps { get; set; }
        public override string ToString()
        {
            return Title;
        }

    }
    
}

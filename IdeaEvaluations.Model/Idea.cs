using System;
using System.Collections.Generic;
using System.Text;

namespace IdeaEvaluations.Model
{
    public class Idea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Assigned { get; set; }
    }
}

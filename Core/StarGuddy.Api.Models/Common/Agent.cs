using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Common
{
    public class Agent
    {
        public Guid Id { get; set; }

        public int SelectedValue { get; set; }

        public int Value { get; set; }

        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BelazApp.Models
{
    public class Parameter 
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public bool IsValid { get; set; }
    }
}

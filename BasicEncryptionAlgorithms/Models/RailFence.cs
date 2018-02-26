using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEncryptionAlgorithms.Models
{
    public class RailFence
    {
        public string Matrix { get; set; } = string.Empty;
        public string OutputText { get; set; } = string.Empty;
        public string InputText { get; set; } = string.Empty;

        [RegularExpression(@"\d+", ErrorMessage = "Only numbers are allowed.")]
        public string Key { get; set; } = string.Empty;
    }
}

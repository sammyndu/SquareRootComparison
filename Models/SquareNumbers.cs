using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SquareRootComparison.Models
{
    public class SquareNumbers
    {
        [Range(1,1000000)]
        public int FirstSquareNumber { get; set; }

        [Range(1,1000000)]
        public int SecondSquareNumber { get; set; }

    }
}

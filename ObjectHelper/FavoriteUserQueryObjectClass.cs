using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class FavoriteUserQueryObjectClass
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string FileName{ get; set; }
        public string QueryText { get; set; }
        public bool IsReleased { get; set; }
        public bool IsSystemCreated { get; set; }
    }
}

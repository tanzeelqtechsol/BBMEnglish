using CommonHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
  public   class PrinterSetupObject : EntityBase
    {
        public string Default { get; set; }
        public string Invoice { get; set; }
        public string POS { get; set; }
        public string Report { get; set; }
        public string Receipt { get; set; }
        public string Barcode { get; set; }
    }
}

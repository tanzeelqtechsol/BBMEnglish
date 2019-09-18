using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;

namespace ObjectHelper
{
    public struct Result
    {
        private Results result;
        private string description;
        private int contolTabIndex;
        private ResultType type;

        public Results results
        {
            get { return result; }
            set { result = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int ContolTabIndex
        {
            get { return contolTabIndex; }
            set { contolTabIndex = value; }
        }

        public ResultType Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}

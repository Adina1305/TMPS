using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    public class ExpSubType
    {
        public int ExpSubTypeID { get; set; }
        public int ExpenseTypeID { get; set; }
        public string ExpSubType_desc { get; set; }

        public ExpSubType(int subTypeId, int typeId, string subTypeName)
        {
            ExpSubTypeID = subTypeId;
            ExpenseTypeID = typeId;
            ExpSubType_desc = subTypeName;
        }
    }

}

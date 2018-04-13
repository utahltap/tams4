using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tams4a.Classes
{
    class ProjectVersion : IComparable<ProjectVersion>
    {
        public String Major { get; protected set; }
        public String Minor { get; protected set; }
        public String Sub { get; protected set; }

        // -1 => This before other
        // 0  =  Equal (or undefined)
        // 1  => This after other
        // note that since we've defined a default value, we shouldn't run into instances where 
        // display_weight is undefined or null, but just in case. ;) 
        public int CompareTo(ProjectVersion other)
        {
            try
            {
                int major = Convert.ToInt16(Major);
                int minor = Convert.ToInt16(Minor);
                int sub = Convert.ToInt16(Sub);
                int omajor = Convert.ToInt16(other.Major);
                int ominor = Convert.ToInt16(other.Minor);
                int osub = Convert.ToInt16(other.Sub);

                int returnint;

                returnint = CompareSub(major, omajor);
                if (returnint !=0) { return returnint; }

                returnint = CompareSub(minor, ominor);
                if (returnint != 0) { return returnint; }

                return CompareSub(sub, osub);
            }
            catch
            {
                return 0;
            }
        }

        protected int CompareSub(int thisone, int thatone)
        {
            if (thisone > thatone)
            {
                return -1;
            }
            else if (thisone < thatone)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

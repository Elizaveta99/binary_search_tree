using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_search_tree
{
    public interface IVisit_Search<T>
    {
        void visit(T data, ref T mx, ref T mn);
    }
}

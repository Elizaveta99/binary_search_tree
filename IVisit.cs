using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_search_tree
{
    public interface IVisit<T>
    {
        void visit(T data);
    }
}

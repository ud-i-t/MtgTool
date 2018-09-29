using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGTool
{
    static class Repository
    {
        private static Dictionary<string, object> _repos = new Dictionary<string, object>();

        public static object Get(Type type)
        {
            return _repos[type.Name];
        }

        public static void Set(Type type, object obj)
        {
            _repos.Add(type.Name, obj);
        }
    }
}

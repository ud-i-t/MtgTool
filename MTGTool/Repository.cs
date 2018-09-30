using MTGTool.Model.Actors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

        public static void Save()
        {
            var list = Get(typeof(ActorList)) as ActorList;

            if(!Directory.Exists($"{AppDomain.CurrentDomain.BaseDirectory}/actors/")){
                Directory.CreateDirectory($"{AppDomain.CurrentDomain.BaseDirectory}/actors/");
            }

            FileStream fs = new FileStream($"{AppDomain.CurrentDomain.BaseDirectory}/actors.bin",
                FileMode.Create,
                FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, list.ToList());
            fs.Close();
        }

        public static void Load()
        {
            FileStream fs = new FileStream($"{AppDomain.CurrentDomain.BaseDirectory}/actors.bin",
            FileMode.Open,
            FileAccess.Read);
            BinaryFormatter f = new BinaryFormatter();

            var list = f.Deserialize(fs) as List<IActor>;
            fs.Close();

            foreach(var actor in list)
            {
                actor.ReloadImage();
            }

            Set(typeof(ActorList), new ActorList(list));

            return;
        }
    }
}

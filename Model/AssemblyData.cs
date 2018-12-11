using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Model
{
    public class AssemblyData
    {
        public List<Type> types;
        List<DataNamespace> namespaces;
        List<DataNamespace> Namespaces
        {
            get => namespaces;
        }

        public List<DataNamespace> GetData(string path)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(path);
                types = assembly.GetTypes().ToList();

                namespaces = (
                    from type in types
                    group type by type.Namespace into namespces
                    select (namespces.Key, namespces.ToList()) into namespc
                    select new DataNamespace(namespc.Item1, namespc.Item2)
                ).ToList();
            }
            catch (Exception)
            {
                
                namespaces = new List<DataNamespace>();
            }
            
            return namespaces;
        }


    }

}

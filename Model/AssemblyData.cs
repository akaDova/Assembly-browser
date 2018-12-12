using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.ObjectModel;
using System.IO;

namespace Model
{
    public class AssemblyData : INamed
    {
        public List<Type> types;
        List<DataNamespace> namespaces;
        List<DataNamespace> Namespaces
        {
            get => namespaces;

        }

        public string Name
        {
            get;
            internal set;
        }

        PreparedData data;

        private IHierarchicalData PrepareData(IEnumerable<IData> data)
        {
            return new PreparedData()
            {
                ItemName = Name,
                Nodes = FillNestedNodes(data)
            };
        }

        private ObservableCollection<IHierarchicalData> FillNestedNodes(IEnumerable<IData> data)
        {
            var collection = new ObservableCollection<IHierarchicalData>();
            if (!(data is null))
            {
                foreach (IData dataItem in data)
                {
                    var preparedData = new PreparedData()
                    {
                        ItemName = dataItem.ItemName,
                        Nodes = FillNestedNodes(dataItem.Nodes)
                    };
                    collection.Add(preparedData);
                }
            }
            return collection;
        }

        public IHierarchicalData GetData(string path)
        {
            try
            {
                
                Assembly assembly = Assembly.LoadFrom(path);
                List<TypeInfo> types = assembly.DefinedTypes.ToList();
                Name = assembly.GetName().Name;
                namespaces = (
                    from type in types
                    group type by type.Namespace into namespces
                    where !(namespces.Key is null)
                    select (namespces.Key, namespces.ToList()) into namespc
                    select new DataNamespace(namespc.Item1, namespc.Item2)
                ).ToList();
            }
            catch (BadImageFormatException ex)
            {
                throw new FileLoadException();
            }
            catch (FileLoadException ex)
            {
                throw new FileLoadException();

            }
            catch (Exception ex)
            {
                
                namespaces = new List<DataNamespace>();
            }

            IHierarchicalData resultData = PrepareData(namespaces);

            return resultData;
        }

        




    }

}

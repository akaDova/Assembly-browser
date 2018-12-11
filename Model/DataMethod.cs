using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataMethod : ITyped, IData
    {
        public string Name
        {
            get;
        }

        // also known as signature
        public string OwnType
        {
            get;
        }

        public string ItemName
        {
            get => $"{OwnType} {Name}";
        }

        

        public IEnumerable<IData> Nodes => null;

        public DataMethod()
        {

        }

        public DataMethod(string name, string signature)
        {
            Name = name;
            OwnType = signature;
        }

        public DataMethod(MethodInfo method)
        {
            List<ParameterInfo> parameters = method.GetParameters().ToList();

            List<string> signature = (
                from parameter in parameters
                select (parameter.ParameterType.Name, parameter.Name) into paramSignature
                select $"{paramSignature.Item1} {paramSignature.Item2}" into paramSignatureText
                select paramSignatureText
             ).ToList();

            OwnType = $"({string.Join(", ", signature)}) => {method.ReturnType.Name}";

            Name = method.Name;

        }
    }
}

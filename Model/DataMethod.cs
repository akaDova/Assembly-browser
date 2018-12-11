using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataMethod : ITyped
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

            OwnType = $"{method.ReturnType.Name} ({string.Join(", ", signature)})";

            Name = method.Name;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class DataMethod : INamed
    {
        public string Name
        {
            get;
        }
        public string Signature
        {
            get;
        }

        public DataMethod()
        {

        }

        public DataMethod(string name, string signature)
        {
            Name = name;
            Signature = signature;
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

            Signature = $"{method.ReturnType.Name} ({string.Join(", ", signature)})";

            Name = method.Name;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataMethod : DataMember, ITyped, IData
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
            get;
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
            string genericArgs = "";
            List<string> signature = (
                from parameter in parameters
                select (GetTypeName(parameter.ParameterType), parameter.Name) into paramSignature
                select $"{paramSignature.Item1} {paramSignature.Item2}" into paramSignatureText
                select paramSignatureText
             ).ToList();

            if (method.IsGenericMethod)
            {
                List<string> args = (from arg in method.GetGenericArguments()
                 select GetTypeName(arg)).ToList();
                genericArgs = $"<{string.Join(",", args)}>";
                
            }
                
            OwnType = $"({string.Join(", ", signature)}) => {GetTypeName(method.ReturnType)}";
            ItemName = $"{GetTypeName(method.ReturnType)} {method.Name}{genericArgs}({string.Join(",", signature)})";

            Name = method.Name;

        }
    }
}

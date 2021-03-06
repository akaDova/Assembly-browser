﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataProperty : DataMember, ITyped, IData
    {
        public string Name
        {
            get;
        }
        public string OwnType
        {
            get;
        }

        public string ItemName
        {
            get => $"property {OwnType} {Name}";
        }

        public IEnumerable<IData> Nodes => null;

        public DataProperty()
        {

        }

        public DataProperty(string name, string type)
        {
            Name = name;
            OwnType = type;
        }

        public DataProperty(PropertyInfo property)
        {
            Name = property.Name;
            OwnType = GetTypeName(property.PropertyType);
        }
    }
}

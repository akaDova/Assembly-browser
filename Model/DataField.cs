﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataField : ITyped
    {
        public string Name
        {
            get;
        }
        public string OwnType
        {
            get;
        }

        public DataField()
        {

        }

        public DataField(string name, string type)
        {
            Name = name;
            OwnType = type;
        }

        public DataField(FieldInfo field) : this(field.Name, field.FieldType.Name)
        {
            Name = field.Name;
            OwnType = field.FieldType.Name;
        }
    }
}

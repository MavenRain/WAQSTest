//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

            using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using WCFAsyncQueryableServices.Entities;
using WCFAsyncQueryableServices.Service.Interfaces;
using WCFAsyncQueryableServices.Specifications;

namespace WebApplication1
{
    partial class Entity1
    {
        [DataContract(Namespace = "http://WAQSModel/Entities")]
        public partial class Entity1Specifications
        {
            [DataMember]
            public int NameLength
            {
                get;
                set;
            }

            [DataMember]
            public bool HasNameLength
            {
                get;
                set;
            }
        }

        [DataMember]
        public Entity1Specifications Specifications
        {
            get;
            set;
        }

        protected Entity1Specifications GetSpecifications()
        {
            return Specifications ?? (Specifications = GetSpecificationsEntity1());
        }

        protected virtual Entity1Specifications GetSpecificationsEntity1()
        {
            return new Entity1Specifications();
        }

        [Specifications]
        public int GetNameLength()
        {
            if (this.Name == null)
                return default (int);
            return this.Name.Length;
        }

        [Specifications]
        public int NameLength
        {
            get
            {
                return GetSpecifications().HasNameLength ? GetSpecifications().NameLength : GetNameLength();
            }

            set
            {
                GetSpecifications().NameLength = value;
                GetSpecifications().HasNameLength = true;
            }
        }
    }
}
            
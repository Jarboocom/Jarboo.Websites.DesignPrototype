﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Common
{
    public class Specification
    {
        public int Take { get; set; }
        public int Skip { get; set; }

        public override string ToString()
        {
            var type = GetType();

            var list = new List<string>();

            foreach (var prop in type.GetProperties())
            {
                var value = GetValue(prop.GetValue(this));

                if (String.IsNullOrEmpty(value))
                    continue;

                list.Add(String.Format("{0}={1}", prop.Name, value));
            }

            var res = String.Join("&", list.ToArray());
            return res;
        }

        private string GetValue(object value)
        {
            if (value == null)
            {
                return null;
            }

            var type = value.GetType();

            if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == typeof(List<>))
                {
                    return String.Join(",", (from object val in (value as IList) select GetValue(val)).ToArray());
                }
                else
                {
                    throw new Exception("Special Generic Type not implemented");
                }
            }
            else
            {
                if (type.IsEnum)
                {
                    return ((int)value).ToString();
                }

                return value.ToString();
            }
        }
    }
}

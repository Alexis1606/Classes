using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Parameter
    {
        public String name;
        public object value;
        public Parameter(String name, String value)
        {
            this.name = name;
            this.value = value;
        }
        public Parameter(String name, int value)
        {
            this.name = name;
            this.value = value;
        }
        public Parameter(String name, bool value)
        {
            this.name = name;
            this.value = value;
        }
        public Parameter(String name, float value)
        {
            this.name = name;
            this.value = value;
        }
        public Parameter(String name, double value)
        {
            this.name = name;
            this.value = value;
        }
        public Parameter(String name, char value)
        {
            this.name = name;
            this.value = value;
        }
        public Parameter(String name, DateTime value)
        {
            this.name = name;
            this.value = value;
        }
        public Parameter(String name, decimal value)
        {
            this.name = name;
            this.value = value;
        }
        public Parameter(String name, object value)
        {
            this.name = name;
            this.value = value;
        }
        public Parameter(String name, short value)
        {
            this.name = name;
            this.value = value;
        }
    }
}

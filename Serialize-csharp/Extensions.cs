using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvroTest
{
    partial class Object1
    {
        public override string ToString()
        {
            return $"Object1 [{this.intVal_1}, {this.floatVal}, {this.intVal_2}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            Object1 other = (Object1)obj;
            return
                other.intVal_1 == this.intVal_1 &&
                other.intVal_2 == this.intVal_2 &&
                other.floatVal == this.floatVal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    partial class Object2
    {
        public override string ToString()
        {
            return $"Object2 [{this.floatVal}, {this.someInteger}, {this.someLong}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            Object2 other = (Object2)obj;
            return
                other.floatVal == this.floatVal &&
                other.someInteger == this.someInteger &&
                other.someLong == this.someLong;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    partial class Object3
    {
        public override string ToString()
        {
            return $"Object3 [{this.floatVal}, {this.someInteger}, {this.someLong}, {(this.optionalInt == null ? "<null>" : this.optionalInt)}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            Object3 other = (Object3)obj;
            return
                other.floatVal == this.floatVal &&
                other.someInteger == this.someInteger &&
                other.someLong == this.someLong &&
                other.optionalInt == this.optionalInt;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    partial class Object4
    {
        public override string ToString()
        {
            return $"Object4 [{this.floatVal}, {this.someInteger}, {this.someLong}, {optionalInt}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            Object4 other = (Object4)obj;
            return
                other.floatVal == this.floatVal &&
                other.someInteger == this.someInteger &&
                other.someLong == this.someLong &&
                other.optionalInt == this.optionalInt;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

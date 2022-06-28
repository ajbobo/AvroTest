//<auto-generated />
namespace AvroTest
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro;

    /// <summary>
    /// Used to serialize and deserialize Avro record AvroTest.Object4.
    /// </summary>
    [DataContract(Namespace = "AvroTest")]
    public partial class Object4
    {
        private const string JsonSchema = @"{""type"":""record"",""name"":""AvroTest.Object4"",""fields"":[{""name"":""floatVal"",""type"":""float""},{""name"":""someInteger"",""type"":""int""},{""name"":""someLong"",""type"":""long""},{""name"":""optionalInt"",""type"":""int""}]}";

        /// <summary>
        /// Gets the schema.
        /// </summary>
        public static string Schema
        {
            get
            {
                return JsonSchema;
            }
        }
      
        /// <summary>
        /// Gets or sets the floatVal field.
        /// </summary>
        [DataMember]
        public float floatVal { get; set; }
              
        /// <summary>
        /// Gets or sets the someInteger field.
        /// </summary>
        [DataMember]
        public int someInteger { get; set; }
              
        /// <summary>
        /// Gets or sets the someLong field.
        /// </summary>
        [DataMember]
        public long someLong { get; set; }
              
        /// <summary>
        /// Gets or sets the optionalInt field.
        /// </summary>
        [DataMember]
        public int optionalInt { get; set; }
                
        /// <summary>
        /// Initializes a new instance of the <see cref="Object4"/> class.
        /// </summary>
        public Object4()
        {
            this.optionalInt = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Object4"/> class.
        /// </summary>
        /// <param name="floatVal">The floatVal.</param>
        /// <param name="someInteger">The someInteger.</param>
        /// <param name="someLong">The someLong.</param>
        /// <param name="optionalInt">The optionalInt.</param>
        public Object4(float floatVal, int someInteger, long someLong, int optionalInt)
        {
            this.floatVal = floatVal;
            this.someInteger = someInteger;
            this.someLong = someLong;
            this.optionalInt = optionalInt;
        }
    }
}

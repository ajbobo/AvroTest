//<auto-generated />
namespace AvroTest
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro;

    /// <summary>
    /// Used to serialize and deserialize Avro record AvroTest.Object1.
    /// </summary>
    [DataContract(Namespace = "AvroTest")]
    public partial class Object1
    {
        private const string JsonSchema = @"{""type"":""record"",""name"":""AvroTest.Object1"",""fields"":[{""name"":""intVal_1"",""type"":""int""},{""name"":""floatVal"",""type"":""float""},{""name"":""intVal_2"",""type"":""int""}]}";

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
        /// Gets or sets the intVal_1 field.
        /// </summary>
        [DataMember]
        public int intVal_1 { get; set; }
              
        /// <summary>
        /// Gets or sets the floatVal field.
        /// </summary>
        [DataMember]
        public float floatVal { get; set; }
              
        /// <summary>
        /// Gets or sets the intVal_2 field.
        /// </summary>
        [DataMember]
        public int intVal_2 { get; set; }
                
        /// <summary>
        /// Initializes a new instance of the <see cref="Object1"/> class.
        /// </summary>
        public Object1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Object1"/> class.
        /// </summary>
        /// <param name="intVal_1">The intVal_1.</param>
        /// <param name="floatVal">The floatVal.</param>
        /// <param name="intVal_2">The intVal_2.</param>
        public Object1(int intVal_1, float floatVal, int intVal_2)
        {
            this.intVal_1 = intVal_1;
            this.floatVal = floatVal;
            this.intVal_2 = intVal_2;
        }
    }
}

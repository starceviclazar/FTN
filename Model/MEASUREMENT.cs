//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MEASUREMENT
    {
        public int MEASUREMENT_ID { get; set; }
        public int RTU_ID { get; set; }
        public double MEASUREMENT_VALUE { get; set; }
        public System.DateTime MEASUREMENT_TIME { get; set; }
        public int MEASUREMENT_TYPE { get; set; }
    
        public virtual RTU RTU { get; set; }
    }
}
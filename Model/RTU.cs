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
    
    public partial class RTU
    {
        public RTU()
        {
            this.MEASUREMENTs = new HashSet<MEASUREMENT>();
        }
    
        public int RTU_ID { get; set; }
        public int LOCATION_ID { get; set; }
        public string NAME { get; set; }
        public int RTU_TYPE { get; set; }
    
        public virtual LOCATION LOCATION { get; set; }
        public virtual ICollection<MEASUREMENT> MEASUREMENTs { get; set; }
    }
}

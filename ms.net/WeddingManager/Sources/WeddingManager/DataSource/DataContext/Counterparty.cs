//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataSource.DataContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Counterparty
    {
        public Counterparty()
        {
            this.CounterpartyToWeddingProjects = new HashSet<CounterpartyToWeddingProject>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<int> CounterpartyRoleId { get; set; }
        public string CounterpartyRoleDescription { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    
        public virtual CounterpartyRole CounterpartyRole { get; set; }
        public virtual ICollection<CounterpartyToWeddingProject> CounterpartyToWeddingProjects { get; set; }
    }
}
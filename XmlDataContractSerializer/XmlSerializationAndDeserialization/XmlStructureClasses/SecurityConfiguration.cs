using System.Collections.Generic;
using System.Runtime.Serialization;

namespace XmlSerializationAndDeserialization.XmlStructureClasses
{
    [DataContract(Name = "SecurityConfiguration", Namespace = "")]
    public class SecurityConfiguration
    {
        [DataMember(Name = "MenuGroups", Order = 0)]
        public List<MenuGroup> MenuGroups { get; set; }

        public SecurityConfiguration()
        {
            MenuGroups = new List<MenuGroup>();
        }
    }

}
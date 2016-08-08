using System.Runtime.Serialization;

namespace XmlSerializationAndDeserialization.XmlStructureClasses
{
    [DataContract(Name = "MenuEntry", Namespace = "")]
    public class MenuEntry
    {
       
        [DataMember(Order = 0)]
        public string Title { get; set; }

        [DataMember(Order = 1)]
        public string Link { get; set; }

        [DataMember(Order = 2)]
        public AllowedGroupsList AllowedGroups { get; set; }

        public MenuEntry()
        {
            AllowedGroups = new AllowedGroupsList();
        }
    }
}
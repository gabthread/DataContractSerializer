using System.Collections.Generic;
using System.Runtime.Serialization;

namespace XmlSerializationAndDeserialization.XmlStructureClasses
{
    [CollectionDataContract(Name = "AllowedGroups", ItemName = "Group", Namespace = "")]
    public class AllowedGroupsList : List<string>
    {
    }
}
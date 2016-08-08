using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using XmlSerializationAndDeserialization;
using XmlSerializationAndDeserialization.XmlStructureClasses;


namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void XmlDeserializationTest()
        {
            //Arrange
            var pathFile = @"..\..\SecurityConfiguration.xml";
            var expectedOrdersAdGroups = new AllowedGroupsList
            {
                "AD.Group.1",
                "AD.Group.2"
            };

            var expectedCustomerAdGroups = new AllowedGroupsList
            {
                "AD.Group.4",
                "AD.Group.5",
                "AD.Group.6"
            };

            //Act
           var configuration = XmlSerializationHelper.Deserialize<SecurityConfiguration>(File.ReadAllText(pathFile));

            //Assert
            Assert.AreEqual("Orders", configuration.MenuGroups[0].Name);
            CollectionAssert.AreEqual(expectedOrdersAdGroups, configuration.MenuGroups[0].MenuEntries[0].AllowedGroups);

            Assert.AreEqual("Customers", configuration.MenuGroups[1].Name);
            CollectionAssert.AreEqual(expectedCustomerAdGroups, configuration.MenuGroups[1].MenuEntries[0].AllowedGroups);
        }

        [TestMethod]
        public void XmlSerializationTest()
        {
            //Arrange
            var configuration = new SecurityConfiguration()
            {
                MenuGroups = new List<MenuGroup>()
                {
                    new MenuGroup()
                    {
                        Name = "Orders",
                        MenuEntries = new List<MenuEntry>()
                        {
                            new MenuEntry()
                            {
                                Title = "New Order",
                                Link = "/NewOrder",
                                AllowedGroups = new AllowedGroupsList()
                                {
                                    "AD.Group.1",
                                    "AD.Group.2"
                                }
                            }
                        }
                    }
                }
            };

            string expectedString =
                @"<SecurityConfiguration xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><MenuGroups><Group><Name>Orders</Name><MenuEntries><MenuEntry><Title>New Order</Title><Link>/NewOrder</Link><AllowedGroups><Group>AD.Group.1</Group><Group>AD.Group.2</Group></AllowedGroups></MenuEntry></MenuEntries></Group></MenuGroups></SecurityConfiguration>";

            //Act
            var xmlString = XmlSerializationHelper.Serialize(configuration);

            //Assert
            Assert.AreEqual(expectedString,xmlString);

        }
    }
}

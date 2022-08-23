using Delivery_Repository;

namespace Delivery_Tests;

[TestClass]
public class Tests
{
    [TestMethod]
    public void SetItemName()
    {
        // Arrange
        DeliveryItem item = new DeliveryItem();

        item.itemName = "Sports Cards";

        // Act
        string expected = "Sports Cards";
        string actual = item.itemName;

        // Assert
        Assert.AreEqual(expected, actual);

    }
}
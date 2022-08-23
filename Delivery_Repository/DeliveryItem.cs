namespace Delivery_Repository;

public class DeliveryItem
{
    /*
    Order ID
    The order date
    The delivery date
    The status of the order
    The item Name
    The item quantity
    The customer id
    */

    public DeliveryItem()
    {
    }

    public DeliveryItem(int orderNum, string orderDate, string deliveryDate, DeliveryStatus deliveryStatus, string itemName, int itemQuantity, int customerID)
    {
        OrderNum = orderNum;
        OrderDate = orderDate;
        DeliveryDate = deliveryDate;
        DeliveryStatus = deliveryStatus;
        ItemName = itemName;
        ItemQuantity = itemQuantity;
        CustomerID = customerID;
    }

    public int OrderNum { get; set; }
    public string OrderDate { get; set; }
    public string DeliveryDate { get; set; }
    public DeliveryStatus DeliveryStatus { get; set; }
    public string ItemName { get; set; }
    public int ItemQuantity { get; set; }
    public int CustomerID { get; set; }

}

public enum DeliveryStatus { Scheduled = 1, EnRoute, Complete, Canceled }
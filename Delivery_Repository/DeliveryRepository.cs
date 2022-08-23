namespace Delivery_Repository;
public class DeliveryRepository
{
    protected readonly List<DeliveryItem> _delivery = new List<DeliveryItem>();

    public bool AddNewDelivery(DeliveryItem item)
    {
        int prevCount = _delivery.Count;

        _delivery.Add(item);

        return prevCount < _delivery.Count ? true : false;
    }

    public List<DeliveryItem> GetAllDeliveries()
    {
        return _delivery;
    }

    public bool UpdateDelivery(int orderNum, DeliveryItem newDelivery)
    {
        DeliveryItem oldDelivery = _delivery.Find(item => item.OrderNum == orderNum);

        if (oldDelivery != null)
        {
            oldDelivery.DeliveryDate = newDelivery.DeliveryDate != null ? newDelivery.DeliveryDate : oldDelivery.DeliveryDate;

            oldDelivery.DeliveryStatus = newDelivery.DeliveryStatus != 0 ? newDelivery.DeliveryStatus : oldDelivery.DeliveryStatus;

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeleteDelivery(int OrderNum)
    {
        DeliveryItem deliveryToDelete = _delivery.Find(item => item.OrderNum == OrderNum);

        bool deleteResult = _delivery.Remove(deliveryToDelete);

        return deleteResult;
    }
}

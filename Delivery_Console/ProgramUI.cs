using System.Net.WebSockets;
using System.Dynamic;
using Delivery_Repository;

public class ProgramUI
{
    DeliveryRepository _repo = new DeliveryRepository();

    public void Run()
    {
        Seed();
        Delivery();
    }

    private void Delivery()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();

            System.Console.WriteLine($"Please select from the following options:\n"
            + "1. Create new Delivery\n"
            + "2. View All Deliveries\n"
            + "3. Update Delivery\n"
            + "4. Delete Delivery\n"
            + "5. Exit");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateNewDelivery();
                    break;

                case "2":
                    ViewAllDeliveries();
                    break;

                case "3":
                    UpdateDelivery();
                    break;

                case "4":
                    DeleteDelivery();
                    break;

                case "5":
                    System.Console.WriteLine("Bye!");

                    keepRunning = false;
                    break;

                Default:
                    System.Console.WriteLine("Please select an option from the list.");
                    break;

            }
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void CreateNewDelivery()
    {
        Console.Clear();

        DeliveryItem newDelivery = new DeliveryItem();

        newDelivery.OrderNum = _repo.GetAllDeliveries().Count + 1;

        System.Console.WriteLine("Please enter an Order Number.");
        newDelivery.OrderNum = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Please enter an Order Date.");
        newDelivery.OrderDate = Console.ReadLine();

        System.Console.WriteLine("Please enter a Delivery Date.");
        newDelivery.DeliveryDate = Console.ReadLine();

        System.Console.WriteLine("Please enter a Delivery Status:\n"
        + "1. Scheduled\n"
        + "2. EnRoute\n"
        + "3. Complete\n"
        + "4. Canceled\n");
        string deliveryStatus = Console.ReadLine();
        int deliveryInt = int.Parse(deliveryStatus);
        newDelivery.DeliveryStatus = (DeliveryStatus)deliveryInt;

        System.Console.WriteLine("Please enter an Item Name.");
        newDelivery.ItemName = Console.ReadLine();

        System.Console.WriteLine("Please enter the Item Quantity.");
        newDelivery.ItemQuantity = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Please enter a Customer ID.");
        newDelivery.CustomerID = int.Parse(Console.ReadLine());

        bool addResult = _repo.AddNewDelivery(newDelivery);

        if (addResult)
        {
            Console.Clear();
            System.Console.WriteLine("Delivery successfully added!");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("There was an issues scheduling delivery.");
        }
    }

    private void ViewAllDeliveries()
    {
        Console.Clear();

        foreach (DeliveryItem delivery in _repo.GetAllDeliveries())
        {
            DisplayDelivery(delivery);
        }
    }

    private void UpdateDelivery()
    {
        Console.Clear();

        System.Console.WriteLine("Please enter the Order Number you would like to change.");

        int orderNum = int.Parse(Console.ReadLine());
        DeliveryItem newDelivery = new DeliveryItem();

        System.Console.WriteLine("Please enter a new delivery date for the order");
        newDelivery.DeliveryDate = Console.ReadLine();

        System.Console.WriteLine("Please update the status of the delivery based on the following list:\n"
        + "1. Scheduled\n"
        + "2. EnRoute\n"
        + "3. Complete\n"
        + "4. Canceled\n");
        string deliveryString = Console.ReadLine();
        int deliveryInt = deliveryString != "" ? int.Parse(deliveryString) : 0;
        newDelivery.DeliveryStatus = (DeliveryStatus)deliveryInt;

        bool updateSuccess = _repo.UpdateDelivery(orderNum, newDelivery);

        if (updateSuccess)
        {
            Console.Clear();

            System.Console.WriteLine("Update successful");
        }
        else
        {
            Console.Clear();

            System.Console.WriteLine("Update unsuccessful");
        }
    }

    private void DeleteDelivery()
    {
        Console.Clear();

        System.Console.WriteLine("Please enter the order number for the delivery you would like to delete:");
        int orderNum = int.Parse(Console.ReadLine());

        bool wasDeleted = _repo.DeleteDelivery(orderNum);

        if (wasDeleted)
        {
            System.Console.WriteLine("Content was successfully deleted");
        }
        else
        {
            System.Console.WriteLine("Can not delete content. Please ensure order number is correct.");
        }
    }

    private void DisplayDelivery(DeliveryItem item)
    {
        System.Console.WriteLine($"Order #: {item.OrderNum}\n"
        + $"Customer ID: {item.CustomerID}\n"
        + "--------------------\n"
        + $"Order Date: {item.OrderDate}\n"
        + $"Delivery Date: {item.DeliveryDate}\n"
        + $"Status of Delivery: {item.DeliveryStatus}\n"
        + $"Item Name: {item.ItemName}\n"
        + $"Item Quantity: {item.ItemQuantity}\n");
        System.Console.WriteLine();
        System.Console.WriteLine();
    }

    private void Seed()
    {
        DeliveryItem baseballCards = new DeliveryItem(_repo.GetAllDeliveries().Count + 1, "8/15/2022", "9/1/2022", DeliveryStatus.Scheduled, "Baseball Cards", 10, 100);
        _repo.AddNewDelivery(baseballCards);

        DeliveryItem footballCards = new DeliveryItem(_repo.GetAllDeliveries().Count + 1, "8/15/2022", "9/1/2022", DeliveryStatus.Scheduled, "Football Cards", 2, 101);
        _repo.AddNewDelivery(footballCards);

        DeliveryItem basketballCards = new DeliveryItem(_repo.GetAllDeliveries().Count + 1, "8/12/2022", "8/22/2022", DeliveryStatus.EnRoute, "Basketball Cards", 5, 102);
        _repo.AddNewDelivery(basketballCards);

        DeliveryItem soccerCards = new DeliveryItem(_repo.GetAllDeliveries().Count + 1, "7/19/2022", "N/A", DeliveryStatus.Canceled, "Soccer Cards", 3, 103);
        _repo.AddNewDelivery(soccerCards);
    }
}
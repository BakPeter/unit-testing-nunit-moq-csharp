namespace TestNinja.Services.Mocking;

public class OrderService : IOrderService
{
    private readonly IStorage _storage;

    public OrderService(IStorage storage)
    {
        _storage = storage;
    }

    public int PlaceOrder(Order order)
    {
        var orderId = _storage.Store(order);
            
        // Some other work

        return orderId; 
    }
}

public class Order
{
    private readonly int _id;

    public Order(int id)
    {
        _id = id;
    }

    public int Id => _id;
}

public interface IOrderService
{
    int PlaceOrder(Order order);
}
public interface IStorage
{
    int Store(object obj);
}

//public class OrderStorage : IStorage
//{
//    public Guid Store(object obj)
//    {
//        if (obj is not Order { } order) throw new ArgumentException();
//        return order.id;
//    }
//}
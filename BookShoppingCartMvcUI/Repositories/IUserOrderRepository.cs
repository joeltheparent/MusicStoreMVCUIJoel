namespace BookShoppingCartMvcUI.Repositories
{
    public interface IUserOrderRepository
    {
        //Task<IEnumerable<Order>> NewOrder();
        Task<IEnumerable<Order>> UserOrders();
    }
}
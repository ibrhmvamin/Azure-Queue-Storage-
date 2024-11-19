namespace Azure_Queue_Storage_Discount_Task.Services.Abstracts
{
    public interface IDiscountQueueService
    {
        Task SendMessageAsync(string message);
        Task<string> ReceiveMessageAsync();
    }
}

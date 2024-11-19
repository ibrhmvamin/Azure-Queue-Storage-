namespace Azure_Queue_Storage_Discount_Task.Services.Abstracts
{
    public interface IQueueService
    {
        Task SendMessageAsync(string message);
        Task<string> ReceiveMessageAsync();
    }
}

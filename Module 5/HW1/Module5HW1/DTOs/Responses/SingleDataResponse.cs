namespace Module5HW1.DTOs.Responses
{
    public class SingleDataResponse<T>
        where T : class
    {
        public T? Data { get; set; }
        public SupportDTO? Support { get; set; }
    }
}

namespace Web.Promo.Domain.Helpers
{
    public class RestHelper<T>
    {
        public string? Message { get; set; }
        public string ErrorCode { get; set; } = null!;
        public bool Success { get; set; } = false;
        public T? Data { get; set; }
    }
}

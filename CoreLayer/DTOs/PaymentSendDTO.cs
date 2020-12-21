namespace ClubIS.CoreLayer.DTOs
{
    public class PaymentSendDTO
    {
        public int ExecutorId { get; set; }
        public int SourceAccountId { get; set; }
        public int TargetAccountId { get; set; }
        public int CreditAmount { get; set; }
        public string Message { get; set; }
    }
}

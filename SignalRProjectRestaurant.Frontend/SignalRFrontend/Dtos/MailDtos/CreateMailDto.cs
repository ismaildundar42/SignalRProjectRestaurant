namespace SignalRFrontend.Dtos.MailDtos
{
    public class CreateMailDto
    {
        public string ReceiverMailAdress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}

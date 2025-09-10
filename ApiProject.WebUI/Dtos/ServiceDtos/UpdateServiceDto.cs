namespace ApiProject.WebUI.Dtos.ServiceDtos
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }

        public string ServiceDescription { get; set; }
        public string IconUrl { get; set; }
    }
}

namespace ApiProject.WebApi.Dtos.ContactDtos
{
    //dto lar result ön eki ile oluşturulur
    //dto da id ile getirme, listeleme, güncelleme ve ekleme işlemleri yapılır silme işlemi yapılmaz
    public class ResultContactDto
    {
        public int ContactId { get; set; }
        public string MapLocation { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpenHours { get; set; }
    }
}

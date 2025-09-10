namespace ApiProject.WebUI.Dtos.AboutDtos
{
    public class UpdateAboutDto
    {
        public int Aboutid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string VideoCoverImageURL { get; set; }
        public string VideoURL { get; set; }
        public string ReservetionNumber { get; set; }
    }
}

namespace EmailService.Models
{
    public class EmailTemplate
    {

        public int Id { get; set; }
        public string Template { get; set; }
        public string Subject { get; set; }
        public string TemplateBody { get; set; }

    }
}

using System.Text;

namespace EmailService
{
    public class CreateEmail
    {

        public static string GenerateEmail (string subject, string mailBody)
        {
            StringBuilder registrationBody = new StringBuilder();
            registrationBody.Append("<HTML>\n <HEAD>\n <TITLE>\n ");
            registrationBody.Append(subject);
            registrationBody.Append("</TITLE>\n </HEAD>\n <BODY>\n ");
            registrationBody.Append("<P>\n");
            registrationBody.Append(mailBody);
            registrationBody.Append("</P>\n </BODY >\n </HTML>\n ");
            return registrationBody.ToString();
        }

    }
}

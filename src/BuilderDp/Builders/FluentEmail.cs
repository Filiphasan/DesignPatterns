using System.Net.Mail;

namespace BuilderDp.Builders;

public class FluentEmail
{
    public string? From { get; private set; }
    public List<string> To { get; private set; } = [];
    public List<string> Cc { get; private set; } = [];
    public List<string> Bcc { get; private set; } = [];
    public string? Subject { get; private set; }
    public string? Body { get; private set; }
    public bool IsHtml { get; private set; }
    public List<Attachment> Attachments { get; private set; } = [];

    private FluentEmail() { }

    public async Task<string> SendAsync()
    {
        // Simulate sending email
        await Task.Delay(1000);
        return "Email sent";
    }

    public class Builder
    {
        private string? _from;
        private List<string> _to = [];
        private List<string> _cc = [];
        private List<string> _bcc = [];
        private string? _subject;
        private string? _body;
        private bool _isHtml;
        private List<Attachment> _attachments = [];

        public Builder From(string? from)
        {
            _from = from;
            return this;
        }
        
        public Builder To(string to)
        {
            _to.Add(to);
            return this;
        }
        
        public Builder Cc(string cc)
        {
            _cc.Add(cc);
            return this;
        }
        
        public Builder Bcc(string bcc)
        {
            _bcc.Add(bcc);
            return this;
        }
        
        public Builder Subject(string? subject)
        {
            _subject = subject;
            return this;
        }

        public Builder Body(string? body, bool isHtml = false)
        {
            _body = body;
            _isHtml = isHtml;
            return this;
        }

        public Builder Attach(Attachment attachment)
        {
            _attachments.Add(attachment);
            return this;
        }

        public FluentEmail Build()
        {
            return new FluentEmail
            {
                From = _from,
                To = _to,
                Cc = _cc,
                Bcc = _bcc,
                Subject = _subject,
                Body = _body,
                IsHtml = _isHtml,
                Attachments = _attachments
            };
        }
    }
}
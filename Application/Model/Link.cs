namespace Application.Model
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public bool IsCrawled { get; set; }

        public string? Time { get; set; }

        public bool InWebSite { get; set; }

        public bool InSitemap { get; set; }

        public Test Test { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return string.Equals(Url, ((Link)obj).Url);     
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(Url);
        }
    }
}
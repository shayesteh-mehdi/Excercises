namespace RemoveAll
{
    public class JobTitle
    {
        public int JobTitleId { get; set; }
        public string name { get; set; }

        public int PersonId { get; set; }
        public Person person { get; set; }
    }
}
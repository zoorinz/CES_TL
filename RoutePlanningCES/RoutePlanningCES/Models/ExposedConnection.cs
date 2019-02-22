namespace Models
{
    public class ExposedConnection
    {
        public int ID { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public int Time { get; set; }
        public Dimension dimensions { get; set; }
        public int weight { get; set; }
        public string parcelType { get; set; }
    }
}

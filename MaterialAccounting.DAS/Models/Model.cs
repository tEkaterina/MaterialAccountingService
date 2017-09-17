namespace MaterialAccounting.DAS.Models
{
    public abstract class Model
    {
        public long Id { get; set; }
        public bool Removed { get; internal set; }
    }
}

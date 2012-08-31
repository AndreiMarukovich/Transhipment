namespace Transhipment
{
    public interface IThing
    {
        string Type { get; }
        string AdditionalType { get; set; }
        string Description { get; set; }
        string Image { get; set; }
        string Name { get; set; }
        string Url { get; set; }

        string Stringify();
    }
}

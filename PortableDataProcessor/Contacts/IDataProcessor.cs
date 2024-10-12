namespace PortableDataProcessor.Contacts
{
    public interface IDataProcessor
    {
        string ProcessData(string csvFilePath, string jsonFilePath);
    }
}
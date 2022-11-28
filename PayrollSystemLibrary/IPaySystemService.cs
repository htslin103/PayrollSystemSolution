namespace PayrollSystem
{
    public interface IPaySystemService
    {
        (string taxid, string name, string address) GetCompanyDetail(int id);
        void SaveCompanyDetail(int id, string taxId, string name, string address);
    }
}
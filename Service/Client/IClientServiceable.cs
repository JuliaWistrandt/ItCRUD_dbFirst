
namespace ItAgency_bdCRUD.Service.Client;
using ItAgency_bdCRUD.Models;

public interface IClientServiceable
{
    public List<Client> GetAllClient();
    public Client GetByIdClient(int id);
    public void AddClient(Client client);
    public void UpdateClient(int id);
    public void DeleteClient(int id);
}


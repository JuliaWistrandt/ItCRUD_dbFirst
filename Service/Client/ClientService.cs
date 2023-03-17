using ItAgency_bdCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ItAgency_bdCRUD.Service.Client
{
    public class ClientService : IClientServiceable
    {
        private readonly ItAgencyContext _dbContext;

        public ClientService(ItAgencyContext dbContext)
        {
            _dbContext = dbContext;
        }

        void IClientServiceable.AddClient(Models.Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }

        void IClientServiceable.DeleteClient(int id)
        {
            _dbContext.Clients.Remove(_dbContext.Clients.Find(id));
            _dbContext.SaveChanges();
        }


        List<Models.Client> IClientServiceable.GetAllClient()
        {
            return _dbContext.Clients.ToList();
        }

        Models.Client IClientServiceable.GetByIdClient(int id)
        {
            return _dbContext.Clients.Find(id);
        }

        void IClientServiceable.UpdateClient(int id)
        {
            var client = _dbContext.Clients.Find(id);
            _dbContext.Clients.Update(client);
            _dbContext.SaveChanges();
        }
    }
}

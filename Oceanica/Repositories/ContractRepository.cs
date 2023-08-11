using OceanicaWebApp.Data;
using OceanicaWebApp.Models;
using OceanicaWebApp.Repositories.Abstract;

namespace OceanicaWebApp.Repositories;

public class ContractRepository : IRepository<Contract>
{
    public OceanicaContext Context;

    public ContractRepository(OceanicaContext context)
    {
        Context = context;
    }

    public ICollection<Contract> GetAll(int skip, int take)
    {
        return Context.Contracts.Skip(skip).Take(take).ToList();
    }

    public Contract GetById(int id)
    {
        return Context.Contracts.Find(id);
    }

    public Contract Insert(Contract entity)
    {
        Context.Contracts.Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public Contract Update(Contract entity)
    {
        var entityFound = Context.Contracts.Find(entity.Id);
        if (entityFound == null)
            return null;

        Context.Entry(entityFound).CurrentValues.SetValues(entity);

        Context.SaveChangesAsync();
        return entityFound;
    }

    public void DeleteById(int id)
    {
        var entity = GetById(id);
        Context.Contracts.Remove(entity);
    }
}

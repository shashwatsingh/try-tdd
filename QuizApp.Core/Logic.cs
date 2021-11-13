namespace QuizApp.Core;

public interface ITenantManager
{
    bool TryFindTenant(string ownerEmailAddress, out Tenant tenant);
}

public interface ITenantDb
{
    IEnumerable<Tenant> FindTenants();
}

public class TenantDb : ITenantDb 
{
    private readonly List<Tenant> tenants = new()
    {
        new Tenant
        {
            Owner = new User { Id = 1, Name = "A", EmailAddress = "a@test.com"},
        }
    };

    public IEnumerable<Tenant> FindTenants()
    {
        return tenants;
    }
}

public sealed class TenantManager : ITenantManager
{
    private readonly ITenantDb db;

    public TenantManager(ITenantDb db)
    {
        this.db = db;
    }
    public bool TryFindTenant(
        string ownerEmailAddress, 
        out Tenant tenant)
    {
        // loop over all known tenants
        // find the tenant which has the email maching the param
        // return true if found
        var found = db.FindTenants()
            .Where(t => t.Owner?.EmailAddress == ownerEmailAddress)
            .FirstOrDefault();

        if (found != null)
        {
            tenant = found;
            return true;
        }
        
        // return false if not
        tenant = Tenant.NullTenant;
        return false;
    }
}

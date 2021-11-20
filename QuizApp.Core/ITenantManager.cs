using Ardalis.GuardClauses;

namespace QuizApp.Core;

public interface ITenantManager
{
    bool TryFindTenant(string ownerEmailAddress, out Tenant tenant);
    void CreateTenant(CreateTenantDto vm);
}

public interface ITenantDb
{
    IEnumerable<Tenant> FindTenants();
    void AddTenant(Tenant tenant);
}

public class TenantDb : ITenantDb
{
    private readonly List<Tenant> tenants = new()
    {
        new Tenant
        {
            Owner = new User { Id = 1, Name = "A", EmailAddress = "a@test.com" },
        }
    };

    public void AddTenant(Tenant tenant)
    {
        tenants.Add(tenant);
    }

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
    public void CreateTenant(CreateTenantDto vm)
    {
        // validate the input
        // DTO constructor only works with valid inputs (required field, length, etc.)

        // validate that the owner doesn't exist already
        if (TryFindTenant(vm.EmailAddress, out _))
        {
            throw new TenantAlreadyExistsException("A tenant with this email address already exists", vm.EmailAddress);
        }

        // initialize the new tenant model
        // save to DB

        var tenant = new Tenant
        {
            Owner = new User
            {
                Name = vm.Name,
                EmailAddress = vm.EmailAddress
            },
            Participants = Enumerable.Empty<User>(),
            Quizzes = Enumerable.Empty<Quiz>(),
            Runs = Enumerable.Empty<QuizRun>(),
        };

        db.AddTenant(tenant);
    }
}

public sealed record CreateTenantDto
{
    public CreateTenantDto(
        string name,
        string emailAddress)
    {
        Guard.Against.NullOrWhiteSpace(name, nameof(name));
        Guard.Against.NullOrWhiteSpace(emailAddress, nameof(emailAddress));
        // TODO: validatate as email address

        Name = name;
        EmailAddress = emailAddress;
    }

    public string Name { get; }

    public string EmailAddress { get; }
}

public class TenantAlreadyExistsException : System.Exception
{
    public string EmailAddress { get; }
    public TenantAlreadyExistsException(string message, string emailAddress) : base(message)
    {
        EmailAddress = emailAddress;
    }
    public TenantAlreadyExistsException(string message, System.Exception inner, string emailAddress) : base(message, inner)
    {
        EmailAddress = emailAddress;
    }
}
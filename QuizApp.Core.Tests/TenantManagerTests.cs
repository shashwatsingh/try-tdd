using System.Collections.Generic;
using Xunit;

namespace QuizApp.Core.Tests;

public class TenantManagerTests
{
    [Fact]
    public void ShouldFindTenantForCorrectOwner()
    {
        ITenantManager manager = new TenantManager(new TestTenantDb());
        Assert.True(manager.TryFindTenant("a@test.com", out var tenant));
    }

    [Fact]
    public void ShouldNotFindTenantForIncorrectOwner()
    {
        ITenantManager manager = new TenantManager(new TestTenantDb());
        Assert.False(manager.TryFindTenant("invalid@test.com", out var tenant));
    }
}

// Stubbing class dependencies
internal class TestTenantDb : ITenantDb
{
    internal static readonly List<Tenant> Tenants = new()
    {
        new Tenant
        {
            Owner = new User { Id = 1, Name = "A", EmailAddress = "a@test.com"},
        }
    };

    public IEnumerable<Tenant> FindTenants()
    {
        return Tenants;
    }
}
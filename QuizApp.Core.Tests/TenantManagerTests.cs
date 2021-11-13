using System;
using System.Collections.Generic;
using Xunit;

namespace QuizApp.Core.Tests;

// SOLID principles

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
    [Fact]
    public void CreateTenant_ShouldThrowOnExistingOwner()
    {
        ITenantManager manager = new TenantManager(new TestTenantDb());
        var vm = new CreateTenantDto(name: "TEST 1", emailAddress: "a@test.com");

        Assert.Throws<Exception>(
            () => manager.CreateTenant(vm));
    }
}

// Stubbing class dependencies
internal class TestTenantDb : ITenantDb
{
    internal static readonly List<Tenant> Tenants = new()
    {
        new Tenant
        {
            Owner = new User { Id = 1, Name = "A", EmailAddress = "a@test.com" },
        }
    };

    public void AddTenant(Tenant tenant)
    {
        Tenants.Add(tenant);
    }

    public IEnumerable<Tenant> FindTenants()
    {
        return Tenants;
    }
}
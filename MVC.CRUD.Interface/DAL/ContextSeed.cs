﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MVC.CRUD.Interface.Models.Entities;
using System;


namespace MVC.CRUD.Interface.DAL;

public static class ContextSeed
{
    public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Roles
        if (!await roleManager.RoleExistsAsync("SuperAdmin"))
            await roleManager.CreateAsync(new IdentityRole(Models.Enums.Roles.SuperAdmin.ToString()));
        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new IdentityRole(Models.Enums.Roles.Admin.ToString()));
        if (!await roleManager.RoleExistsAsync("Moderator"))
            await roleManager.CreateAsync(new IdentityRole(Models.Enums.Roles.Moderator.ToString()));
        if (!await roleManager.RoleExistsAsync("Basic"))
            await roleManager.CreateAsync(new IdentityRole(Models.Enums.Roles.Basic.ToString()));
    }

    public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Default User
        var defaultUser = new User
        {
            UserName = "superadmin@gmail.com",
            Email = "superadmin@gmail.com",
            FirstName = "SuperAdmin",
            Surname = "superadminsurname",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };

        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "P@ssword123");
                await userManager.AddToRoleAsync(defaultUser, Models.Enums.Roles.Basic.ToString());
                await userManager.AddToRoleAsync(defaultUser, Models.Enums.Roles.Moderator.ToString());
                await userManager.AddToRoleAsync(defaultUser, Models.Enums.Roles.Admin.ToString());
                await userManager.AddToRoleAsync(defaultUser, Models.Enums.Roles.SuperAdmin.ToString());
            }

        }
    }

    public static async Task SeedClientsAsync(CRUDContext context)
    {
        //Seed Clients
        var existingClients = context.Clients.ToList();
        if (existingClients.IsNullOrEmpty())
        {
            var clients = new List<Client>
            {
                new Client
                {
                    Name = "LiquidMolly",
                    Package = "Standard",
                    Platform = "Windows 10",
                    Region = "Gauteng",
                },
                new Client
                {
                    Name = "Caltex",
                    Package = "Basic",
                    Platform = "Windows 7",
                    Region = "Mpumalanga",
                },
                new Client
                {
                    Name = "Shell",
                    Package = "Enterprise",
                    Platform = "Windows 11",
                    Region = "Gauteng",
                },
                new Client
                {
                    Name = "LUK",
                    Package = "Basic",
                    Platform = "Windows 8.1",
                    Region = "KZN",
                },
                new Client
                {
                    Name = "Goldwagen",
                    Package = "Enterprise",
                    Platform = "Windows 10",
                    Region = "Limpopo",
                },
                new Client
                {
                    Name = "Westvaal",
                    Package = "Basic",
                    Platform = "Windows 7",
                    Region = "Cape Town",
                },
                new Client
                {
                    Name = "BMW",
                    Package = "Enterprise",
                    Platform = "Windows 10",
                    Region = "Eastern Cape",
                },
                new Client
                {
                    Name = "Toyota",
                    Package = "Standard",
                    Platform = "Windows 17",
                    Region = "North West",
                },
                new Client
                {
                    Name = "Hyundai",
                    Package = "Basic",
                    Platform = "Windows 10",
                    Region = "Western Cape",
                },
                new Client
                {
                    Name = "Mitsubishi",
                    Package = "Basic",
                    Platform = "Windows 11",
                    Region = "Free State",
                },
                new Client
                {
                    Name = "Suzuki",
                    Package = "Enterprise",
                    Platform = "Windows 10",
                    Region = "Northern Cape",
                },
                new Client
                {
                    Name = "Volkswagen",
                    Package = "Basic",
                    Platform = "Windows 11",
                    Region = "Free State",
                },
                new Client
                {
                    Name = "Castrol",
                    Package = "Basic",
                    Platform = "Windows 7",
                    Region = "Limpopo",
                },
                new Client
                {
                    Name = "Nissan",
                    Package = "Enterprise",
                    Platform = "Windows 11",
                    Region = "KZN",
                },
                new Client
                {
                    Name = "Ford",
                    Package = "Basic",
                    Platform = "Windows 7",
                    Region = "Eastern Cape",
                }
            };
            clients.ForEach(client => context.Clients.AddAsync(client));
            await context.SaveChangesAsync(true);
        }
    }
}

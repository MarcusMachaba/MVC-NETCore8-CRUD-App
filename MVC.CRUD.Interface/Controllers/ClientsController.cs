using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.CRUD.Interface.Models.Entities;
using MVC.CRUD.Interface.Models.Enums;

namespace MVC.CRUD.Interface.Controllers;

public class ClientsController : Controller
{
    private readonly MVC.CRUD.Interface.ServiceHelpers.IClientService _clientsService;
    protected INotyfService _notyf;
    private readonly ILogger<ClientsController> _logger;

    public ClientsController(MVC.CRUD.Interface.ServiceHelpers.IClientService clientsService,
                          INotyfService notyf,
                          ILogger<ClientsController> logger)
    {
        _clientsService = clientsService;
        _notyf = notyf;
        _logger = logger;
    }

    //Create GET
    [Authorize(Roles = nameof(Roles.SuperAdmin) + "," + nameof(Roles.Basic) + "," + nameof(Roles.Admin))]
    public async Task<IActionResult> Create()
    {
        try
        {
            var client = new Client();
            return PartialView("_Create", client);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch client create view");
            throw;
        }
    }

    //Create POST
    [HttpPost, Authorize(Roles = nameof(Roles.SuperAdmin) + "," + nameof(Roles.Basic) + "," + nameof(Roles.Admin))]
    public async Task<IActionResult> Create(Client client)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var createdClient = await _clientsService.AddClientAsync(client);
                if (createdClient != null)
                {
                    _notyf.Success($"Client created successfully.");
                }
            }
            catch (Exception ex)
            {
                _notyf.Error($"Failed to create new client.");
                _logger.LogError(ex, "Failed to create new client");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
        return PartialView("_Create", client);
    }

    //ReadAll GET
    [Authorize]
    public async Task<IActionResult> Index()
    {
        try
        {
            var clients = await _clientsService.GetAllClientsAsync();

            return View(clients);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    //EditOne GET
    [Authorize(Roles = nameof(Roles.SuperAdmin) + "," + nameof(Roles.Basic) + "," + nameof(Roles.Admin))]
    public async Task<IActionResult> Edit(string id)
    {
        var client = await _clientsService.GetClientByIdAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return PartialView("_Edit", client);
    }

    //EditOne POST
    [HttpPost, Authorize(Roles = nameof(Roles.SuperAdmin) + "," + nameof(Roles.Basic) + "," + nameof(Roles.Admin))]
    public async Task<IActionResult> Edit(string id, Client client)
    {
        if (id != client.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _clientsService.UpdateClientAsync(client);
                _notyf.Success($"Client updated successfully.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await ClientExists(client.Id))
                {
                    _notyf.Warning($"Client Not Found.");
                    return NotFound();
                }
                else
                {
                    _notyf.Error($"Failed to update client.");
                    _logger.LogError(ex, "Failed to update client");
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return PartialView("_Edit", client);
    }


    //DeleteOne GET
    [Authorize(Roles = nameof(Roles.SuperAdmin) + "," + nameof(Roles.Admin))]
    public async Task<IActionResult> Delete(string id)
    {
        var client = await _clientsService.GetClientByIdAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return PartialView("_Delete", client);
    }


    //DeleteOne POST
    [HttpPost, ActionName("Delete"), Authorize(Roles = nameof(Roles.SuperAdmin) + "," + nameof(Roles.Admin))]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        await _clientsService.DeleteClientAsync(id);
        _notyf.Success($"Client deleted successfully.");
        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> ClientExists(string id)
    {
        var client = await _clientsService.GetClientByIdAsync(id);
        return client != null;
    }
}

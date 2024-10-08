using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.CRUD.Interface.Models.Entities;
using System;

namespace MVC.CRUD.Interface.Controllers;

[Authorize]
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
    public async Task<IActionResult> Create()
    {
        try
        {
            var client = new Client();
            return PartialView("_Create", client);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    //Create POST
    [HttpPost]
    public async Task<IActionResult> Create(Client client)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var createdClient = await _clientsService.AddClientAsync(client);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return PartialView("_Create", client);
    }

    //ReadAll GET
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
    [HttpPost]
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
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ClientExists(client.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return PartialView("_Edit", client);
    }


    //DeleteOne GET
    public async Task<IActionResult> Delete(string id)
    {
        var client = await _clientsService.GetClientByIdAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return PartialView("_Delete", client);
    }


    //EditOne POST
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        await _clientsService.DeleteClientAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> ClientExists(string id)
    {
        var client = await _clientsService.GetClientByIdAsync(id);
        return client != null;
    }

}

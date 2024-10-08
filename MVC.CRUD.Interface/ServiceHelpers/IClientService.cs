using AspNetCoreHero.ToastNotification.Abstractions;
using MVC.CRUD.Interface.DAL;
using MVC.CRUD.Interface.Models;
using MVC.CRUD.Interface.Models.Entities;

namespace MVC.CRUD.Interface.ServiceHelpers;

public interface IClientService
{
    Task<IEnumerable<Client>> GetAllClientsAsync();
    Task<Client> GetClientByIdAsync(string id);
    Task UpdateClientAsync(Client client);
    Task DeleteClientAsync(string id);
    Task<Client> AddClientAsync(Client client);
}

public class ClientService: IClientService
{
    private readonly IRepository<Client> _clientsRepository;
    private ILogger<ClientService> _logger;
    protected INotyfService _notyf;

    public ClientService(IRepository<Client> clientRepository,
                         ILogger<ClientService> logger)
    {
        _logger = logger;
        _clientsRepository = clientRepository; 
    }

    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        try
        {
            var allClients = await _clientsRepository.GetAllAsync();
            return allClients;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<Client> GetClientByIdAsync(string id)
    {
        try
        {
            var client = await _clientsRepository.GetByIdAsync(id);
            return client;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task UpdateClientAsync(Client client)
    {
        try
        {
            await _clientsRepository.UpdateAsync(client); 
            await _clientsRepository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task DeleteClientAsync(string id)
    {
        try
        {
            await _clientsRepository.DeleteAsync(id);
            await _clientsRepository.SaveAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Client> AddClientAsync(Client client)
    {
        try
        {
            await _clientsRepository.InsertAsync(client);
            await _clientsRepository.SaveAsync();
            return await _clientsRepository.GetByIdAsync(client.Id);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}

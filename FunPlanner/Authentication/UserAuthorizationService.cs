using Blazored.LocalStorage;
using FunPlanner.Models;
using FunPlannerShared.Controllers;
using FunPlannerShared.Data.Entities;

public class UserAuthorizationService
{
    private readonly ILocalStorageService localStorageService;
    private readonly IPersonController personController;

    public UserAuthorizationService(ILocalStorageService localStorageService, IPersonController personController)
    {
        this.localStorageService = localStorageService;
        this.personController = personController;
    }

    public async Task<Person> LoginUser(UserLoginDto employee)
    {
        var user = await personController.GetByName(employee.FirstName, employee.LastName);

        if (user != null)
        {
            await localStorageService.SetItemAsync("user", new UserStorageDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            });
            return user;
        }
        else return null;
    }
}
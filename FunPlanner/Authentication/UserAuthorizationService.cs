using Blazored.LocalStorage;
using FunPlanner.Models;
using FunPlannerShared.Controllers;
using FunPlannerShared.Data.Dtos;
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

    public async Task<PersonLoginDto?> LoginUser(UserLoginDto employee)
    {
        var user = await personController.GetByEmail(employee.Email);

        if(user?.Password != employee.Password)
            return null;

        if (user != null)
        {
            await localStorageService.SetItemAsync("user", new PersonLoginDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
            return user;
        }
        else return null;
    }

    public async Task LogoutUser()
    {
        //var user = await personController.GetByName(employee.FirstName, employee.LastName);

        //if (user != null)
        //{
            var userFromStorage = await localStorageService.GetItemAsync<UserStorageDto>("user");
            if(userFromStorage != null)
            {
                await localStorageService.RemoveItemAsync("user");
            }
        //}
    }
}
using Blazored.LocalStorage;
using FunPlanner.Models;
using FunPlannerShared.Controllers;
using FunPlannerShared.Data.Dtos;

public class UserAuthorizationService
{
    private readonly ILocalStorageService localStorageService;
    private readonly IPersonController personController;
    private readonly IAuthorizationController authorizationController;

    public UserAuthorizationService(ILocalStorageService localStorageService, IPersonController personController, IAuthorizationController authorizationController)
    {
        this.localStorageService = localStorageService;
        this.personController = personController;
        this.authorizationController = authorizationController;
    }

    public async Task<PersonLoginDto?> LoginUser(UserLoginDto employee)
    {
        var validationResult = await authorizationController.ValidateUser(employee.Email, employee.Password);

        if (validationResult.IsValidated == false)
            return null;

        var user = await personController.GetByEmail(employee.Email);

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
        var userFromStorage = await localStorageService.GetItemAsync<UserStorageDto>("user");
        if (userFromStorage != null)
        {
            await localStorageService.RemoveItemAsync("user");
        }
    }
}
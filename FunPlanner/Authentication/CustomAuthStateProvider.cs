using Blazored.LocalStorage;
using FunPlanner.Models;
using FunPlannerShared.Data.Dtos;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService localStorageService;
    public CustomAuthStateProvider(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        UserStorageDto userDto = await localStorageService.GetItemAsync<UserStorageDto>("user").AsTask();
        if (userDto != null)
        {
            identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, $"{userDto.FirstName} {userDto.LastName}"),
            }, "user");
        }
        var user = new ClaimsPrincipal(identity);

        return new AuthenticationState(user);
    }

    public void MarkUserAsAuthenticated(PersonLoginDto person)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, $"{person.FirstName} {person.LastName}"),
                //new Claim(ClaimTypes.Role, employee.Role.ToString())
        }, "apiauth_type");

        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public void MarkUserAsLoggedOut()
    {
        localStorageService.RemoveItemAsync("user");

        var identity = new ClaimsIdentity();

        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }
}
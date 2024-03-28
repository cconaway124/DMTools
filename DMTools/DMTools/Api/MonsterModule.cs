using DMTools.Database.Entities;
using DMTools.Database;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Carter;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using DMTools.Security.AuthenticationStateSyncer;
using Microsoft.AspNetCore.Components.Authorization;

namespace DMTools.Api;

public class MonsterModule : CarterModule
{
    public MonsterModule() : base("/api/v1/monster")
    {
        base.WithTags("Monsters");
        base.IncludeInOpenApi();

    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        // GET
        app.MapGet("/{id}", GetMonster);

        // POST
        app.MapPost("/create", CreateMonster);

        // PUT
        app.MapPut("/update", UpdateMonster);

        // DELETE
        app.MapDelete("/delete", DeleteMonster);
    }

    private async Task<Results<Ok<Monster>, BadRequest<string>, NotFound<string>>> GetMonster([FromServices] DmtoolsContext dmtoolsContext, int id)
    {
        Monster monster = await dmtoolsContext.Monster.FindAsync(id);

        if (monster == null)
        {
            return TypedResults.NotFound("The requested resource was not found.");
        }

        return TypedResults.Ok(monster);
    }

    private async Task<Results<Ok, BadRequest<string>, NotFound<string>>> CreateMonster([FromServices] DmtoolsContext dmtoolsContext, HttpContext context, [FromBody] Monster monster)
    {
        User user = dmtoolsContext.Users.Where(u => u.UserGuid == guid).FirstOrDefault();
        if (user is null)
        {
            return TypedResults.BadRequest("User is not logged in.");
        }

        if (monster == null)
        {
            return TypedResults.NotFound("The requested resource was not sent.");
        }

        dmtoolsContext.Monster.AddRange(monster);
        await dmtoolsContext.SaveChangesAsync();

        return TypedResults.Ok();
    }

    private async Task<Results<Ok, BadRequest<string>, NotFound<string>>> UpdateMonster([FromServices] DmtoolsContext dmtoolsContext, [FromServices] AuthenticationStateProvider auth, [FromBody] Monster monster)
    {
        var user = await auth.GetAuthenticationStateAsync();
        if (!user.User.Identity.IsAuthenticated)
        {
            return TypedResults.BadRequest("User is not logged in.");
        }

        if (monster == null)
        {
            return TypedResults.NotFound("The requested resource was not sent.");
        }

        dmtoolsContext.Monster.UpdateRange(monster);
        await dmtoolsContext.SaveChangesAsync();

        return TypedResults.Ok();
    }

    [HttpDelete("v1/monster/delete/{id}")]
    private async Task<Results<Ok, BadRequest<string>, NotFound<string>>> DeleteMonster([FromServices] DmtoolsContext dmtoolsContext, [FromServices] AuthenticationStateProvider auth, [FromQuery] int id)
    {
        var user = await auth.GetAuthenticationStateAsync();
        if (!user.User.Identity.IsAuthenticated)
        {
            return TypedResults.BadRequest("User is not logged in.");
        }

        Monster monster = await dmtoolsContext.Monster.FindAsync(id);

        if (monster == null)
        {
            return TypedResults.NotFound("The requested resource was not sent.");
        }

        dmtoolsContext.Monster.RemoveRange(monster);

        dmtoolsContext.Monster.UpdateRange(monster);
        await dmtoolsContext.SaveChangesAsync();

        return TypedResults.Ok();
    }
}

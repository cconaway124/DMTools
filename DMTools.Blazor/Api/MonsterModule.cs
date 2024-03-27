using DMTools.Database.Entities;
using DMTools.Database;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Carter;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace DMTools.Blazor.Api;

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

    private async Task<Results<Ok<Monster>, BadRequest<string>, NotFound<string>>> GetMonster(DmtoolsContext dmtoolsContext, int id)
    {
        Monster monster = await dmtoolsContext.Monster.FindAsync(id);

        if (monster == null)
        {
            return TypedResults.NotFound("The requested resource was not found.");
        }

        return TypedResults.Ok(monster);
    }

    private async Task<Results<Ok, BadRequest<string>, NotFound<string>>> CreateMonster(IHttpContextAccessor contextAccessor, DmtoolsContext dmtoolsContext, [FromBody] Monster monster)
    {
        string username = contextAccessor.HttpContext.Session.GetString("username") ?? string.Empty;
        string guid = contextAccessor.HttpContext.Session.GetString("guid") ?? string.Empty;
        if (Guid.TryParse(guid, out Guid g))
        {
            return TypedResults.BadRequest("User has malformed data.");
        }

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(guid))
        {
            return TypedResults.BadRequest("User is not logged in.");
        }

        User checkUser = dmtoolsContext.Users.Where(u => u.UserName == username && g == u.UserGuid).FirstOrDefault();
        if (checkUser == null)
        {
            return TypedResults.BadRequest("User does not match any resource.");
        }

        if (monster == null)
        {
            return TypedResults.NotFound("The requested resource was not sent.");
        }

        dmtoolsContext.Monster.AddRange(monster);
        await dmtoolsContext.SaveChangesAsync();

        return TypedResults.Ok();
    }

    private async Task<Results<Ok, BadRequest<string>, NotFound<string>>> UpdateMonster(IHttpContextAccessor contextAccessor, DmtoolsContext dmtoolsContext, [FromBody] Monster monster)
    {
        string username = contextAccessor.HttpContext.Session.GetString("username") ?? string.Empty;
        string guid = contextAccessor.HttpContext.Session.GetString("guid") ?? string.Empty;
        if (Guid.TryParse(guid, out Guid g))
        {
            return TypedResults.BadRequest("User has malformed data.");
        }

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(guid))
        {
            return TypedResults.BadRequest("User is not logged in.");
        }

        User checkUser = dmtoolsContext.Users.Where(u => u.UserName == username && g == u.UserGuid).FirstOrDefault();
        if (checkUser == null)
        {
            return TypedResults.BadRequest("User does not match any resource.");
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
    private async Task<Results<Ok, BadRequest<string>, NotFound<string>>> DeleteMonster(IHttpContextAccessor contextAccessor, DmtoolsContext dmtoolsContext, int id)
    {
        string username = contextAccessor.HttpContext.Session.GetString("username") ?? string.Empty;
        string guid = contextAccessor.HttpContext.Session.GetString("guid") ?? string.Empty;
        if (Guid.TryParse(guid, out Guid g))
        {
            return TypedResults.BadRequest("User has malformed data.");
        }

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(guid))
        {
            return TypedResults.BadRequest("User is not logged in.");
        }

        User checkUser = dmtoolsContext.Users.Where(u => u.UserName == username && g == u.UserGuid).FirstOrDefault();
        if (checkUser == null)
        {
            return TypedResults.BadRequest("User does not match any resource.");
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

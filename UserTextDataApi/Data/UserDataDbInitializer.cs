using Microsoft.EntityFrameworkCore;

namespace UserTextDataApi.Data;

public static class UserDataDbInitializer
{
    public static void Initialize(UserDataDbContext context)
    {
        if (context.UserData.Any())
        {
            return;
        }
        
        ExecuteWithIdentityInsertRemoval<UserData>(context, ctx =>
        {
            var users = new UserData[]
            {
                new UserData
                {
                    Id = 88421114, Texts =
                    {
                        new UserText("Hi1"),
                        new UserText("hi2")
                    }
                },
            };
            foreach (var user in users)
            {
                ctx.UserData.AddIfNotExists(user, user.Id);
            }
        });
    }

    //Required due to setting id by oneself
    private static void ExecuteWithIdentityInsertRemoval<TModel>(UserDataDbContext context, Action<UserDataDbContext> act) where TModel: class
    {
        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT " + typeof(TModel).Name + " ON;");
            context.SaveChanges();
            act(context);
            context.SaveChanges();
            transaction.Commit();
        }
        catch(Exception)
        {
            transaction.Rollback();
            throw;
        }
        finally
        {
            context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT " + typeof(TModel).Name + " OFF;");
            context.SaveChanges();
        }
    }
}
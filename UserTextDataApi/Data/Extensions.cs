using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;

namespace UserTextDataApi.Data;

public static class Extensions
{
    [Pure]
    public static bool Exists<T>(this DbSet<T> dbSet, params object[] keyValues) where T : class
    {
        return dbSet.Find(keyValues) != null;
    }

    public static void AddIfNotExists<T>(this DbSet<T> dbSet, T entity, params object[] keyValues) where T: class
    {
        if (!dbSet.Exists(keyValues))
            dbSet.Add(entity);
    }
}
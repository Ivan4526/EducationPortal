using System;

public class ValidationService
{
    public bool Validate<T>(T entity)
    {
        if (entity == null) return false;

        if (entity is User) { /*...*/ }

        if (entity is AdminUser) { /*...*/ }

        if (entity is Product) { /*...*/ }

        throw new NotSupportedException($"Entities of type '{typeof(T).Name}' are not supported");
    }
}

public class User {}

public class AdminUser {}

public class Product {}
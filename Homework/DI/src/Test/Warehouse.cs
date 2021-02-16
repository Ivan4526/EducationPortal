using System;
using System.Collections.Generic;

public abstract class Warehouse
{
    public IDictionary<string, object> Items = new Dictionary<string, object>();

    public abstract void AddItem(string name, object item);

    public abstract object GetItem(string name);

    public abstract void RemoveItem(string name);
}


public class InputOnlyWarehouse : Warehouse
{
    public override void AddItem(string name, object item)
    {
        if (string.IsNullOrWhiteSpace(name) || item == null) return;

        this.Items[name] = item;
    }

    public override object GetItem(string name) { throw new NotImplementedException(); }

    public override void RemoveItem(string name) { throw new NotImplementedException(); }
}
using System;
using UnityEngine;

public class FakeCriteria : ICriteria
{
    public string Id { get; set; }
    public bool IsMet { get; private set; }

    public event Action<ICriteria> OnCompleted;

    public FakeCriteria(string id)
    {
        Id = id;
        IsMet = false;
    }

    public void Initialize() { }

    public void Dispose() { }

    public void Evaluate(object eventData = null) { }

    public void Reset()
    {
        IsMet = false;
    }

    public void Trigger()
    {
        IsMet = true;
        OnCompleted?.Invoke(this);
    }
}

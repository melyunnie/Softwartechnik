using System;

public interface ICriteria : IDisposable
{
    string Id { get; }
    bool IsMet { get;  }

    event Action<ICriteria> OnCompleted;

    void Initialize();

    void Evaluate(object eventData = null);

    void Reset();

}

using System;

public abstract class BaseCriteria : ICriteria
{
    protected bool isCompleted;
    public abstract string Id { get; }
    public bool IsMet => isCompleted;

    public event Action<ICriteria> OnCompleted;


    public abstract void Initialize();
    public abstract void Dispose();
    public abstract void Reset();
    protected abstract bool CheckCondition();
   

    public void Evaluate(object eventData = null)
    {
        if (CheckCondition())
            Complete();
    }


    protected void Complete()
    {
        if (isCompleted)
            return;

        isCompleted = true;
        OnCompleted?.Invoke(this);
    }
}

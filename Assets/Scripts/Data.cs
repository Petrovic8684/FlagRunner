using UnityEngine;

public interface IDataPersistenceStrategy<T>
{
    void Save(string key, T value);
    T Load(string key, T defaultValue);
}

public class IntPlayerPrefsStrategy : IDataPersistenceStrategy<int>
{
    public void Save(string key, int value) => PlayerPrefs.SetInt(key, value);
    public int Load(string key, int defaultValue) => PlayerPrefs.GetInt(key, defaultValue);
}

public interface IPersistentData
{
    void Save();
    void Load();
    void Reset();
}

[System.Serializable]
public class PersistentData<T> : IPersistentData
{
    protected string key;
    protected T value;
    protected T initialValue;
    private IDataPersistenceStrategy<T> persistenceStrategy;

    public PersistentData(string key, T initialValue, IDataPersistenceStrategy<T> strategy)
    {
        this.key = key;
        this.initialValue = initialValue;
        this.value = initialValue;
        this.persistenceStrategy = strategy;
    }

    public T GetValue() => value;
    public void SetValue(T newValue) => value = newValue;

    public void Save() => persistenceStrategy.Save(key, value);
    public void Load() => value = persistenceStrategy.Load(key, initialValue);
    public void Reset() => value = initialValue;
}

public class ScoreData : PersistentData<int>
{
    public ScoreData() : base("Score", 0, new IntPlayerPrefsStrategy()) { }
}

public class LivesData : PersistentData<int>
{
    public LivesData() : base("Lives", 3, new IntPlayerPrefsStrategy()) { }
}

using UnityEngine;
using System.Collections.Generic;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    private List<IPersistentData> data = new();

    public ScoreData Score { get; private set; }
    public LivesData Lives { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Score = new ScoreData();
        Lives = new LivesData();

        data.Add(Score);
        data.Add(Lives);
    }

    public void ResetAll()
    {
        foreach (IPersistentData datum in data)
            datum.Reset();
    }
}
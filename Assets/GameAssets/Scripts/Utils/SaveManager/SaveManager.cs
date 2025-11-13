using System;
using System.Collections;
using System.Collections.Generic;
using Itens;
using UnityEngine;
using System.IO;
using Ebac.Singleton;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private SaveSetup _saveSetup;
    private string _path = Application.dataPath + "/save.txt";// + Json

    public int lastLevel;

    public Action<SaveSetup> FileLoaded;

    public SaveSetup Setup
    {
        get { return _saveSetup; }
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void CreateNewSave()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 0;
        _saveSetup.playername = "Player";
    }

    private void Start()
    {
        Invoke(nameof(Load), 1f);
        
    }

    #region SAVE
    [NaughtyAttributes.Button]
    private void Save()
    {
        string setupToJason = JsonUtility.ToJson(_saveSetup);
        Debug.Log(setupToJason);
        SaveFile(setupToJason);

    }

    public void SaveItens()
    {
        _saveSetup.coins = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.COIN).soInt.value;
        _saveSetup.healthPack = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.LIFE_PACK).soInt.value;
        _saveSetup.health = PlayerControllerTurning.Instance.healthBase._currentLife;
        Save();
    }

    public void SaveName(string name)
    {
        _saveSetup.playername = name;
        Save();
    }

    public void SaveLastlevel(int level)
    {
        _saveSetup.lastLevel = level;
        SaveItens();
        Save();
    }

    #endregion
    private void SaveFile(string Json)
    {
        
        // DataPath salva no próprio projeto
        // persistantDataPath salva em pasta de usuario
        Debug.Log(_path);
        File.WriteAllText(_path, Json);
        //string fileLoaded = "";
        //if (File.Exists(path)) fileLoaded = File.ReadAllText(path);
    }
    [NaughtyAttributes.Button]

    private void Load()
    {
        string fileLoaded = "";

        if (File.Exists(_path))
        {
            fileLoaded = File.ReadAllText(_path);
            _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
            lastLevel = _saveSetup.lastLevel;
        }
        else
        {
            CreateNewSave();
            Save();
        }

            FileLoaded.Invoke(_saveSetup);
    }

    [NaughtyAttributes.Button]
    private void SaveLevelOne()
    {
        SaveLastlevel(1);
    }

}

[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public string playername;
    public float coins;
    public float healthPack;
    public float health;
    public string cloth;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using DG.Tweening.Plugins.Core.PathCore;

public class SaveManager
{
    private string _path = "";
    public string PATH => _path;

    private readonly string _fileName = "SAVE_FILE";
    public string FILE_NAME => _fileName;

    public void Init()
    {
        _path = Application.dataPath + "/SAVE_DATA_FILE";
        if (!Directory.Exists(_path))
            Directory.CreateDirectory(_path);
    }

    public void SaveJson<T>(string createPath, string fileName, T value)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        string json = JsonUtility.ToJson(value, true);
        byte[] data = Encoding.UTF8.GetBytes(json);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    public void SaveJson<T>(T value)
    {
        SaveJson<T>(_path, _fileName, value);
    }

    public T LoadJsonFile<T>(string loadPath, string fileName) where T : new()
    {
        if (File.Exists(string.Format("{0}/{1}.json", loadPath, fileName)))
        {
            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
            byte[] data = new byte[fileStream.Length];
            fileStream.Read(data, 0, data.Length);
            fileStream.Close();
            string jsonData = Encoding.UTF8.GetString(data);
            return JsonUtility.FromJson<T>(jsonData);
        }
        SaveJson<T>(loadPath, fileName, new T());
        return LoadJsonFile<T>(loadPath, fileName);
    }

    public T LoadJsonFile<T>() where T : new()
    {
        return LoadJsonFile<T>(_path, _fileName);
    }

    public bool DeleteFile(string path, string fileName)
    {
        if (File.Exists(string.Format("{0}/{1}.json", path, fileName)))
        {
            File.Delete(string.Format("{0}/{1}.json", path, fileName));
            return true;
        }

        return false;
    }

    public bool DeleteFile()
    {
        return DeleteFile(_path, _fileName);
    }
}

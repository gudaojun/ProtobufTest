using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestGoogleBuffer;
using System.IO;
using System.Text;

public class ProtobufferTest : MonoBehaviour
{
    private string path;
    void Start()
    {
        path = Application.streamingAssetsPath;
        userInfo userInfo = new userInfo();
        userInfo.Name = "ะกอ๕";
        userInfo.Gold = 3000;
        userInfo.Level = 100;
        userInfo.Diamonds = 5;
        byte[] data = Protobuffer.Serialize(userInfo);
        Debug.Log("data length" + data.Length);
        if (!File.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        var str = Encoding.UTF8.GetString(data);
        File.WriteAllText(Path.Combine(path, "Data.txt"), str);
        var readData = File.ReadAllBytes(Path.Combine(path, "Data.txt"));
        userInfo info = Protobuffer.DeSerialize<userInfo>(readData);
        Debug.Log(info.Name);
        Debug.Log(info.Gold);
        Debug.Log(info.Level);
        Debug.Log(info.Diamonds);

    }
}

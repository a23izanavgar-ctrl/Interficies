using JetBrains.Annotations;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Skibidiprueba : MonoBehaviour
{
    const String saveGameFileName = "SaveGame.sav";
    const String saveGameBackupFileName = "SaveGame.sav_backup";


    void Start()
    {
        DeleteSaveGame();
        CreateSaveExample();
        SaveGameBackup();
        MoveGamebackupTobackUpFolder();
    }

    private void MoveGamebackupTobackUpFolder()
    {
        Debug.Log(Application.temporaryCachePath);

        if (File.Exists(GetPathToSaveGameFileBackup()))
        File.Move(GetPathToSaveGameFileBackup(), Application.temporaryCachePath + "/" + saveGameBackupFileName);
    }

    private void DeleteSaveGame()
    {
        AssertDirectories();
        if (File.Exists(GetPathToSaveGameFile()))
        {
            File.Delete(GetPathToSaveGameFile());
            Directory.Delete(GetPathToSaveGameFolder());
        }
        
    }

    private void SaveGameBackup()
    {
        if (File.Exists(GetPathToSaveGameFile()))
            File.Copy(GetPathToSaveGameFile(), GetPathToSaveGameFileBackup(), true);


    }

    private string GetPathToSaveGameFileBackup()
    {
        return GetPathToSaveGameFile() + "backup";
    }

    private void CreateSaveExample()
    {
        AssertDirectories();
        string path = GetPathToSaveGameFile();
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine("hola Mundo");

            }

        }
    }

    private void AssertDirectories()
    {
        //Si carpetra No existe, pimero creamos carpeta
        //Si la carpeta existe, creamos archivo directamente 
        if (!Directory.Exists(GetPathToSaveGameFolder()))
        {
            Directory.CreateDirectory(GetPathToSaveGameFolder());
            Debug.Log("se ha creado el directorio" + GetPathToSaveGameFolder());
        }
    }

    void DebugPath()
    {
        //pueden ser utiles
        Debug.Log(Application.dataPath); //Carpeta Assets

        //son utiles 100%
        Debug.Log(Application.persistentDataPath); //Carpeta super oculta, esta dentro de AppData (configuraciones y mas cosas)
        Debug.Log(Application.streamingAssetsPath); //Carpeta Streaming Assets (archivos que puedo meter hasta en una build, archivos que se pueden descargar y descargar con facilidad)

        //me interesan mas bien poco
        Debug.Log(Application.consoleLogPath); // 
        Debug.Log(Application.temporaryCachePath); // 
    }

    public string GetPathToSaveGameFolder()
    {
        return Application.persistentDataPath + "/SaveGames";
    }
    public string GetPathToSaveGameFile()
    {
        return GetPathToSaveGameFolder() + "/" + saveGameFileName;

    }

    bool saveGameFileExists()
    {
        return File.Exists(GetPathToSaveGameFile());
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}

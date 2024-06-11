using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Gombok : MonoBehaviour
{
    public GameObject panel;

    private string saveNev;
    private string utvonal;
    public GameObject jatekos;
    private static int saveDb;
    private int maxSave = 3;
    public void Exit()
    {
        Application.Quit();
    }
    public void Kezedes()
    {
        SceneManager.LoadScene("Jatek");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Continue() {
        Time.timeScale = 1f;
    }

    public void Save()
    {

        //Debug.Log("Bejött a savebe");
        Mentes saveAdat = new Mentes();
        saveAdat.pozx = jatekos.transform.position.x;
        saveAdat.pozy = jatekos.transform.position.y;
        saveAdat.pozz = jatekos.transform.position.z;
        saveAdat.forgasx = jatekos.transform.rotation.x;
        saveAdat.forgasy = jatekos.transform.rotation.y;
        saveAdat.forgasz = jatekos.transform.rotation.z;
        saveAdat.forgasw = jatekos.transform.rotation.w;
        
        if (!Directory.Exists(Application.dataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.dataPath + "/saves");
            //Debug.Log("Létrejött a mappa");
        }

        saveDb = Directory.GetFiles(Application.dataPath + "/saves").Length;
        if (saveDb>=maxSave)
        {
            
            int i = 0;
            DateTime legkisebbIdo = new DateTime(9999,12,31);
            while (i < maxSave)
            {
                string ideiglenesSaveNev = "save_" + (i);
                if (File.GetLastWriteTime(Application.dataPath + "/saves/" + ideiglenesSaveNev + ".save") < legkisebbIdo)
                {
                    legkisebbIdo = File.GetLastWriteTime(Application.dataPath + "/saves/" + ideiglenesSaveNev + ".save");
                    saveNev="save_" + (i);
                }
                i++;
            }

        }
        else
        {
            saveNev = "save_" + (saveDb);
        }
        utvonal = Application.dataPath + "/saves/" + saveNev + ".save";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(utvonal, FileMode.Create);
        bf.Serialize(fs,saveAdat);
        fs.Close();
        saveDb++;
    }

    public void Load()
    {
        if (utvonal==null)
        {
            saveDb = Directory.GetFiles(Application.dataPath + "/saves").Length;
            if (saveDb >= maxSave)
            {

                int i = 0;
                DateTime legnagyobbIdo = new DateTime(2000, 12, 31);
                while (i < maxSave)
                {
                    string ideiglenesSaveNev = "save_" + (i);
                    if (File.GetLastWriteTime(Application.dataPath + "/saves/" + ideiglenesSaveNev + ".save") > legnagyobbIdo)
                    {
                        legnagyobbIdo = File.GetLastWriteTime(Application.dataPath + "/saves/" + ideiglenesSaveNev + ".save");
                        saveNev = "save_" + (i);
                    }
                    i++;
                }
            }
            else
            {
                saveDb = Directory.GetFiles(Application.dataPath + "/saves").Length;
                saveDb--;
                saveNev = "save_" + (saveDb);
            }
            utvonal = Application.dataPath + "/saves/" + saveNev + ".save";
        }
        
        if (File.Exists(utvonal))
        {
            try
            {
                FileStream fs = new FileStream(utvonal,FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                Mentes mentes= bf.Deserialize(fs) as Mentes;
                fs.Close();
                jatekos.GetComponent<CharacterController>().enabled=false;
                jatekos.transform.localPosition = new Vector3(mentes.pozx,mentes.pozy,mentes.pozz);
                jatekos.transform.localRotation =
                    new Quaternion(mentes.forgasx,mentes.forgasy,mentes.forgasz,mentes.forgasw);
                jatekos.GetComponent<CharacterController>().enabled=true;
                Time.timeScale = 1f;
                //string[] adatok = mentes.Split(';');
                //for (int i = 0; i < adatok.Length; i++)
                //{
                //    int zarojel1 = adatok[i].IndexOf('(');
                //    int zarojel2 = adatok[i].IndexOf(')');
                //    adatok[i] = adatok[i].Remove(zarojel1, 1);
                //    adatok[i] = adatok[i].Remove(zarojel2 - 1, 1);
                //}
                //string[] olvasottPozicio=adatok[0].Split(',');
                //float[] poz = new float[olvasottPozicio.Length];
                //for (int i = 0; i < poz.Length; i++)
                //{
                //    poz[i]= float.Parse(olvasottPozicio[i]);
                //    //Debug.Log(poz[i]);
                //}


                //string[] fordulas = adatok[1].Split(',');
                //float[] ford =new float [fordulas.Length];
                //for (int i = 0; i < ford.Length; i++)
                //{
                //    //Debug.Log(fordulas[i]);
                //    ford[i] = float.Parse(fordulas[i]);
                //}
                //Time.timeScale = 1f;

            }
            catch (IOException)
            {
                Debug.LogError("Nem sikerült betölteni a fájlt. " + utvonal);
            }
        }
        else
        {
            Debug.Log("nincs path");
        }
    }
}

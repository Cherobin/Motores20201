using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{

    public TextAsset reader;

    public GameObject listObjects;
    public GameObject[] objectToCreate;

    // Start is called before the first frame update
    void Start()
    {
        // reader = Resources.Load<TextAsset>("personagens");

        if (reader == null)
        {
            Debug.LogError("reader is null");
        }

        if (listObjects == null)
        {
            Debug.LogError("listObjects is null");
        }

        if (objectToCreate == null)
        {
            Debug.LogError("objectToCreate is null");
        }

        readerCsv();
    }

    void readerCsv()
    {
        string[] data = reader.text.Split('\n');

        //pula primeira linha pq tem as infos do que se trato a coluna.
        for (int i = 1; i < data.Length; i++)
        {
            string[] values = data[i].Split(';');
            int id = 0;
            int.TryParse(values[0], out id);
            string name = values[1];
            string type = values[2];
            string color = values[3];
           // int posX = values[4];
           // int posY = values[5];
            //int posZ = values[6];
            //string typeColor = values[7];

            int auxType = 0;
            switch(type) {
                case "Sphere":
                    auxType = 0;
                    break;
                case "Cube":
                    auxType = 1;
                    break;
            }

          //  var newObject = Instantiate(objectToCreate[auxType], new Vector3(posX,posY, posZ), Quaternion.identity);
       //     newObject.transform.parent = listObjects.transform;
        //    newObject.name = name;

            
    }

    }
}

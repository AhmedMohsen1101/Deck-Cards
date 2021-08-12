using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

    
public class CreateDeckInRuntime : MonoBehaviour
{
    string path = "Assets/Resources/DeckcardJson.txt";
    private void Start()
    {
        Invoke(nameof(ReadJson), 0.1f);
    }
    public void ReadJson()
    {
        StreamReader reader = new StreamReader(path);
        //Debug.Log(reader.ReadToEnd());

        var deckCard = JsonUtility.FromJson<CardsDeck>(reader.ReadToEnd());
        AppMasterManager.Instance.cardsData.cardsDeck = deckCard;

        reader.Close();
    }
}

//public string[] type;
//[ContextMenu("Create Json")]
//public void CreateJsonFile()
//{
//    AppMasterManager.Instance.cardsData.cardsDeck.list.Clear();

//    for (int i = 0; i < type.Length; i++)
//    {
//        for (int k = 1; k <= 13; k++)
//        {
//            if (k <= 10)
//            {
//                AppMasterManager.Instance.cardsData.cardsDeck.list.Add(new Card(type[i] + "_" + k, k));
//            }
//            else if(k == 11)
//            {
//                AppMasterManager.Instance.cardsData.cardsDeck.list.Add(new Card(type[i] + "_" + "J", k));
//            }
//            else if (k == 12)
//            {
//                AppMasterManager.Instance.cardsData.cardsDeck.list.Add(new Card(type[i] + "_" + "Q", k));
//            }
//            else if (k == 13)
//            {
//                AppMasterManager.Instance.cardsData.cardsDeck.list.Add(new Card(type[i] + "_" + "K", k));
//            }
//        }
//    }

//    var json = JsonUtility.ToJson(AppMasterManager.Instance.cardsData.cardsDeck);
//    Debug.Log(json);


//}

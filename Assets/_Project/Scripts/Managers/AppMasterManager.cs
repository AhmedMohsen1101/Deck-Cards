using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AppMasterManager : MonoBehaviour
{
    public static AppMasterManager Instance;

    public CardsDeck_DataSO cardsData;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}

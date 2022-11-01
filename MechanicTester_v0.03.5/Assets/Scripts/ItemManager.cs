using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public int coinCount;

    public TextMeshProUGUI coinCountText;

    // Update is called once per frame
    public void Update()
    {
        coinCountText.text = "" + coinCount;
    }

    public void HandleCollectible(int collectibleValue)
    {
        coinCount += collectibleValue;
    }


}

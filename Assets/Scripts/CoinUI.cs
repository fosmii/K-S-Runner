using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public TMP_Text coinCountText;
    private int coinCount = 0;

    public void CoinUIUpdate(int coinScale)
    {
        coinCount += coinScale;
        coinCountText.text = $"{coinCount}";
    }
}

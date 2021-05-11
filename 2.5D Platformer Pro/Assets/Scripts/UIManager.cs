using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int _coinCount = 0;
    public Text _coinVisualText, _livesText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoins()
    {
        ++_coinCount;
        UpdateCoinVisual();
    }

    private void UpdateCoinVisual()
    {
        _coinVisualText.text = "Coins Collected: " + _coinCount;
    }

    public void UpdateLivesVisual(int lives)
    {
        _livesText.text = "Lives: " + lives;
    }
}

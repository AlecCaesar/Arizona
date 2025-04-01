using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletCount : MonoBehaviour
{
    public TextMeshProUGUI bulletText;
    public Player player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = player.bulletsLeft.ToString();
    }
}

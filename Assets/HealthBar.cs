using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    
    public GameObject healthPrefab;
    public Player player;
    public List<HealthBlock> blocks = new List<HealthBlock>();

    public Color onColor;
    public Color offColor;
    void Start()
    {
        for(int i =0; i<blocks.Count; i++){
            Destroy(blocks[i].gameObject);
        }

        blocks.Clear();

        for(int i =0; i<player.healthLeft; i++){
            GameObject newBlock = Instantiate(healthPrefab, transform);
            blocks.Add(newBlock. GetComponent<HealthBlock>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<blocks.Count; i++){
            if(i < player.healthLeft){
                blocks[i].SetHealthColor(onColor);
            }else{
                blocks[i].SetHealthColor(offColor);
            }
        }
    }
}

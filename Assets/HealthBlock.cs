using UnityEngine;
using UnityEngine.UI;

public class HealthBlock : MonoBehaviour
{
   public Image healthImage;

   public void SetHealthColor(Color color){
        healthImage.color = color;
   }
}

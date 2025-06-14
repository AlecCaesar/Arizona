using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed = 5f;
    private int index;
    public Animator animator;
    void Start()
    {
        textComponent.text =string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)){
            if(textComponent.text == lines[index]){
                NextLine();
            }
            else{
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }


    public void StartDialogue(){
        index = 0;
        animator.SetBool("IsOpen", true);
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine(){
        foreach(char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if(index < lines.Length - 1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else{
            //gameObject.SetActive(false);
            animator.SetBool("IsOpen", false);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageSwap : MonoBehaviour
{
    bool swapActive = false;
    Image otherImage;
    public Image spellTargetOne;
    public Image spellTargetTwo;
    Vector2 otherImagePos;
    float baseX;
    float baseY;
    // Start is called before the first frame update
    void Start()
    {
        otherImage = spellTargetOne;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")){
            if(spellTargetOne.Equals(otherImage)){
                otherImage = spellTargetTwo;
            }
            else{
                otherImage = spellTargetOne;
            }
            SwapImages();
        }

        if(swapActive == true){
            float targetDistance = Vector2.Distance(transform.position, otherImagePos);
            Vector3 targetVector = new Vector3(baseX + ((otherImage.transform.localScale.x - transform.localScale.x)/targetDistance), baseY + ((otherImage.transform.localScale.y - transform.localScale.y)/targetDistance), 1);
            transform.localScale = targetVector;
            transform.position = Vector2.MoveTowards(transform.position, otherImagePos, (float) 1);
            if(Vector2.Distance(transform.position, otherImagePos) == 0){
                swapActive = false;
            }
        }
    }

    public void SwapImages()
    {
        baseX = transform.localScale.x;
        baseY = transform.localScale.y;
        otherImagePos = otherImage.transform.position;
        swapActive = true;
    }
}

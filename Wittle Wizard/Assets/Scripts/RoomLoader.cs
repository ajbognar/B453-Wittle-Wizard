using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;

    [SerializeField] Transform EdgeTransform;

    [SerializeField] int SceneIndex;

    public Vector3 left = new Vector3(-9.25f, -1.18f, 0);

    public Vector3 right = new Vector3(9.25f, -1.18f, 0);

    [SerializeField] string exit = "left";


    // Start is called before the first frame update
    void Start()
    {
        /*if (SceneManager.GetActiveScene().buildIndex != 0) {
            GameObject wizard = GameObject.Find("wizard-big copy");
            if (exit.Equals("left")) {
                wizard.transform.position = right;
            }
            else if (exit.Equals("right")) {
                wizard.transform.position = left;
            }
        }*/
    }



    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag.Equals("Player")) {
            StartCoroutine(LoadLevel(SceneIndex, collider));
        }
    }
    IEnumerator LoadLevel(int levelIndex, Collider2D collider) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
        
    }
}

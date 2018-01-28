using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToEnding : MonoBehaviour
{
    public float delayBeforeTransition = 2.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
            IEnumerator coroutine = GoToEndScene();
            StartCoroutine(coroutine);
        }
    }

    IEnumerator GoToEndScene()
    {
        yield return new WaitForSeconds(delayBeforeTransition);
        SceneManager.LoadScene("Levels/ending");
    }

}

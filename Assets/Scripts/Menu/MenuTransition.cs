using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour
{

    //private bool isFaded = false;

    private float duration = 0.4f;
    private float hiddenPositionX = -100f;
    //private float hiddenPositionY = 0f;

    private Vector2 hiddenPos;
    private Vector2 showPos;

    private void Start()
    {
        hiddenPos = new Vector2(-100f, transform.position.y);
        showPos = new Vector2(transform.position.x, transform.position.y);
    }

    public void Fade(bool isFaded)
    {
        CanvasGroup canvGroup = GetComponent<CanvasGroup>();

        canvGroup.interactable = isFaded ? true : false;

        //if(canvGroup.gameObject.activeSelf)
        //{
        //    //On active le fade, (si isFaded = false, alors ca veut dire que alpha = 1 donc la fin du alpha sera 0)
        //    StartCoroutine(DoFade(canvGroup, canvGroup.alpha, isFaded ? 1 : 0, isFaded));

        //    canvGroup.gameObject.SetActive(false);
        //} else
        //{
        //    canvGroup.gameObject.SetActive(true);

        //    //On active le fade, (si isFaded = false, alors ca veut dire que alpha = 1 donc la fin du alpha sera 0)
        //    StartCoroutine(DoFade(canvGroup, canvGroup.alpha, isFaded ? 1 : 0, isFaded));
        //}

        //On active le fade, (si isFaded = false, alors ca veut dire que alpha = 1 donc la fin du alpha sera 0)
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, isFaded ? 1 : 0, isFaded));
        StartCoroutine(Translation(canvGroup, showPos, hiddenPos));


        //isFaded = !isFaded;
    }


    public IEnumerator DoFade(CanvasGroup canvGrp, float start, float end, bool isFaded)
    {
        float counter = 0f;

        while(counter < duration)
        {
            counter += Time.deltaTime;
            canvGrp.alpha = Mathf.Lerp(start, end, counter / duration);

            //if(duration == counter)
            //{
            //}

            //Vector2 showPosition = new Vector2(transform.position.x, transform.position.y);

            //Vector2 hiddenPostion = new Vector2(hiddenPositionX, transform.position.y);

            //if(transform.position.y == -100f)
            //{
            //    Translation(canvGrp, hiddenPos, showPos);
            //} else
            //{
            //    Translation(canvGrp, showPos, hiddenPos);
            //}

            //Translation(canvGrp, showPos, hiddenPos);

            yield return null;
        }
    }

    public IEnumerator Translation(CanvasGroup canvGroup, Vector2 actualPos, Vector2 nextPos)
    {

        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            
            //canvGrp.alpha = Mathf.Lerp(start, end, counter / duration);

            //if(duration == counter)
            //{
            //}

            //Vector2 showPosition = new Vector2(transform.position.x, transform.position.y);

            //Vector2 hiddenPostion = new Vector2(hiddenPositionX, transform.position.y);

            //if(transform.position.y == -100f)
            //{
            //    Translation(canvGrp, hiddenPos, showPos);
            //} else
            //{
            //    Translation(canvGrp, showPos, hiddenPos);
            //}

            transform.position = Vector2.Lerp(actualPos, nextPos, counter / duration);

            yield return null;
        }

    }

    //public void TranslationIn(CanvasGroup canvGroup)
    //{
    //    //transform.Translate(new Vector2(-50, canvGroup.transform.position.y));

    //    Vector2 actualPosition = new Vector2(transform.position.x, transform.position.y);

    //    Vector2 hiddenPostion = new Vector2(nextPositionX, nextPositionY);

    //    transform.position = Vector2.Lerp(actualPosition, hiddenPostion, duration);
    //}
}

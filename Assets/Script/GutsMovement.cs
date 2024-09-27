using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Execution;

//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;

public class GutsMovement : MonoBehaviour
{
    [SerializeField] public Tweener tweener;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Animator animator;
    //private Transform t;
    private Vector3[] points = new Vector3[4];


    

    int currentPointArray = 0; // has to be outside so it dont reset to 0 every time method is called
    // Start is called before the first frame update
    void Start()
    {
        points[0] = new Vector3(-9.78f, 8.95f);
        points[1] = new Vector3(0.14f, 8.95f);
        points[2] = new Vector3(0.14f, 1.05f);
        points[3] = new Vector3(-9.78f, 1.05f);


        //tweener.AddTween(transform, points[0], points[1], 2.5f);
        //audioSource = tweener.GetComponent<AudioSource>();
        nextPoint();

            audioSource.clip = audioClip; 

        
        
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (!tweener.TweenExists(transform))
        {


            nextPoint();

        } // check to only move if isn't already moving, otherwise the wrong order of sequence will play

        
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            } //fixed walking clip restarting every 2 second


    }

    void nextPoint()
    {

        Vector3 currentPoint = points[currentPointArray];
        
        int nextPointArray = currentPointArray + 1; 
        if (nextPointArray == points.Length)
        {
            nextPointArray = 0;
        }//reset the loop so when the last point is reached, next point will go back to initial point
        Vector3 nextPoint = points[nextPointArray];

        float speed = 4f;
        float length = Vector3.Distance(currentPoint, nextPoint);
        float time = length / speed;

        playDirection(currentPoint, nextPoint);

        tweener.AddTween(transform, currentPoint, nextPoint, time);
        currentPointArray++;

        if (currentPointArray == points.Length)
        {
            currentPointArray = 0;
        } //reset the loop so when the last point is reached, current will go back to initial point

        
    }

    void playDirection(Vector3 currentPoint, Vector3 nextPoint)
    {

        animator.ResetTrigger("GutsUp");
        animator.ResetTrigger("GutsLeft");
        animator.ResetTrigger("GutsDown");
        animator.ResetTrigger("GutsRight"); //fixed animation overlap
        if (nextPoint.y > currentPoint.y && nextPoint.x == currentPoint.x)
        {
            animator.SetTrigger("GutsUp");
        }else if(nextPoint.x < currentPoint.x && nextPoint.y == currentPoint.y)
        {
            animator.SetTrigger("GutsLeft");
        }else if(nextPoint.y < currentPoint.y && nextPoint.x == currentPoint.x)
        {
            animator.SetTrigger("GutsDown");
        }else if(nextPoint.x > currentPoint.x && nextPoint.y == currentPoint.y)
        {
            animator.SetTrigger("GutsRight");
        }

        //audioSource.Play();

        
    }
}
    





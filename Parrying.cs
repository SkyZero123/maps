using System.Collections;
using UnityEngine;

public class Parrying : MonoBehaviour
{
    public Animator animator;
    private bool isParrying = false;
    private bool isComingBack = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsParrying", false);
        animator.SetBool("IsNotParrying", true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isParrying && !isComingBack)
            {
                isParrying = true;
                animator.SetBool("IsParrying", true);
                animator.SetBool("IsNotParrying", false);
                StartCoroutine(NotParrying()); // Start the "Coming back" animation timer
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isParrying && !isComingBack)
            {
                isParrying = false; // Prevent starting the "Parrying" animation again
            }
        }
    }

    IEnumerator NotParrying()
    {
        isComingBack = true;
        yield return new WaitForSeconds(1); // Adjust based on "Coming back" animation length
        animator.SetBool("IsParrying", false);
        animator.SetBool("IsNotParrying", true);
        isComingBack = false;
    }
}





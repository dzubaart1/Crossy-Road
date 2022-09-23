using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

            if (Input.GetKeyDown(KeyCode.W))
            {
                MoveToVector(new Vector3(1, 0, 0));
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToVector(new Vector3(0, 0, 1));
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                MoveToVector(new Vector3(0, 0, -1));
            }
    }

    private void MoveToVector(Vector3 difference)
    {
        animator.SetTrigger("hop");
        transform.position = transform.position + difference;
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private TerrainGenerator terrainGen;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            float newZ = 0;
            if (transform.position.z % 1 != 0)
                newZ = Mathf.Round(transform.position.z);
            MoveToVector(new Vector3(1, 0, newZ));
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
        transform.position += difference;
        terrainGen.UpdateTerrains(transform.position);
    }
}
/*[SerializeField]
private TerrainGenerator terrainGen;

private Animator animator;
private void Start()
{
    animator = GetComponent<Animator>();
}
private void Update()
{
    if (Input.GetKeyDown(KeyCode.W))
    {
        float newZ = 0;
        if (transform.position.z % 1 != 0)
            newZ = Mathf.Round(transform.position.z);
        MoveToVector(new Vector3(1, 0, newZ));
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
    transform.position += difference;
    terrainGen.UpdateTerrains(transform.position);
}*/

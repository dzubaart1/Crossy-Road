using UnityEngine;
using Zenject;

namespace Cntrls
{
    public class PlayerCntrl : MonoBehaviour
    {
        private TerrainGenerator _terrainGen;

        private Animator _animator;

        [Inject]
        private void Construct(TerrainGenerator terrainGenerator)
        {
            _terrainGen = terrainGenerator;
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Vector3 v = new Vector3(1, 0, 0);
                if (CheckInfo(transform.right))
                    MoveToVector(v);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Vector3 v = new Vector3(0, 0, 1);
                if (CheckInfo(transform.forward))
                    MoveToVector(v);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Vector3 v = new Vector3(0, 0, -1);
                if (CheckInfo(-transform.forward))
                    MoveToVector(v);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Vector3 v = new Vector3(-1, 0, 0);
                if (CheckInfo(-transform.right))
                    MoveToVector(v);
            }
        }

        private bool CheckInfo(Vector3 checkPos)
        {
            RaycastHit hitGround;
            if (Physics.Raycast(transform.position, checkPos, out hitGround, 1f))
            {
                if (hitGround.collider.tag == "Tree")
                    return false;
            }
            return true;
        }

        private void MoveToVector(Vector3 difference)
        {
            _animator.SetTrigger("hop");
            transform.position += difference;
            transform.position = new Vector3(
                Mathf.Round(transform.position.x),
                Mathf.Round(transform.position.y),
                Mathf.Round(transform.position.z)
            );
            _terrainGen.UpdateTerrains(transform.position);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Enemy")
            {
                GameOver gameOver = new GameOver();
                return;
            }
            if (collision.collider.tag == "Boat")
            {
                transform.parent = collision.collider.transform;
                return;
            }
            transform.parent = null;
        }
    }
}
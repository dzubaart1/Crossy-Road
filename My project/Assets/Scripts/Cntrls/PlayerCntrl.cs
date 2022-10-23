using UnityEngine;
using Zenject;

namespace Cntrls
{
    public class PlayerCntrl : MonoBehaviour
    {
        private TerrainGenerator _terrainGen;
        private Animator _animator;
        private Border _border;

        [Inject]
        private void Construct(TerrainGenerator terrainGenerator, Border border)
        {
            _terrainGen = terrainGenerator;
            _border = border;
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            Vector3 res = new Vector3();
            if (Input.GetKeyDown(KeyCode.W))
                res = Vector3.right;
            else if (Input.GetKeyDown(KeyCode.A))
                res = Vector3.forward;
            else if (Input.GetKeyDown(KeyCode.D))
                res = Vector3.back;
            else if (Input.GetKeyDown(KeyCode.S))
                res = Vector3.left;

            if (CheckInfo(res) && res != Vector3.zero)
            {
                MoveToVector(res);
                _terrainGen.UpdateTerrains(transform.position);
            }
            

            if (transform.position.z > _border._upperBound || transform.position.z < _border._lowerBound || transform.position.y < 0)
            {
                new GameOver();
            }

            res = Vector3.zero;
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
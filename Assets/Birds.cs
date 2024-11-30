using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Birds : MonoBehaviour
{
    [SerializeField] private float launch_force = 500;

    Vector3 _initialp;
    float time_sitting;
    bool bird_launched;

    private void Awake()
    {
        _initialp = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _initialp);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        if (bird_launched & GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            time_sitting += Time.deltaTime;
        }

        if (transform.position.y > 10 | transform.position.y < -10 | transform.position.x > 10 | transform.position.y < -10 | time_sitting > 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }



    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;

    }




    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directiontointitial = _initialp - transform.position;
        
        GetComponent<Rigidbody2D>().AddForce(directiontointitial * launch_force);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        bird_launched = true;
        GetComponent<LineRenderer>().enabled = false;

    }



    private void OnMouseDrag()
    {
        Vector3 newP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newP.x, newP.y);
    }
}


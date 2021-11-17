using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    // Update is called once per frame
    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);

    }
}

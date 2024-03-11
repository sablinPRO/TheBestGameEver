using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball FireballPrefabs;
    public Transform fireballSourseTransform;
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(FireballPrefabs, fireballSourseTransform.position, fireballSourseTransform.rotation);
        }
    }
}

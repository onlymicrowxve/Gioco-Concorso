using UnityEngine;

public class PaintBullet : MonoBehaviour
{
    public GameObject paintSplatPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("ArmaDaTerra")) return;

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        GameObject splat = Instantiate(paintSplatPrefab, contact.point + contact.normal * 0.01f, Quaternion.LookRotation(contact.normal));
        Destroy(splat, 10f);
        Destroy(gameObject);
    }
}
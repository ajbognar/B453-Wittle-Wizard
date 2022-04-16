using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float offsetY;
    void Update()
    {
        Vector3 playerVector = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, -10);
        transform.position = Vector3.Lerp(transform.position, playerVector, 0.05f);
    }
}

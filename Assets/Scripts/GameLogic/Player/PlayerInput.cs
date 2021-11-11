using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private BallJumper _jumper;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumper.Jump();
        }
    }
}

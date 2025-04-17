using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 _moveVector;

    public Vector2 GetMoveVector()
    {
        _moveVector.x = Input.GetAxisRaw("Horizontal");
        _moveVector.y = Input.GetAxisRaw("Vertical");
        _moveVector.Normalize();
        return _moveVector;
    }

    public bool IsPrimaryAttackDown()
    {
        return Input.GetKeyDown(KeyCode.Z);
    }
    
    public bool IsPrimaryAttackUp()
    {
        return Input.GetKeyUp(KeyCode.Z);
    }
}

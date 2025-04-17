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

    public bool IsPrimaryKeyDown()
    {
        return Input.GetKeyDown(KeyCode.Z);
    }
    
    public bool IsPrimaryKeyUp()
    {
        return Input.GetKeyUp(KeyCode.Z);
    }
    
    public bool IsSecondaryKeyDown()
    {
        return Input.GetKeyDown(KeyCode.X);
    }
    
    public bool IsSecondaryKeyUp()
    {
        return Input.GetKeyUp(KeyCode.X);
    }
}

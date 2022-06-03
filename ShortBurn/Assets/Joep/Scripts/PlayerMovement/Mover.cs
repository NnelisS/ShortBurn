using UnityEngine;
using UnityEditor;

public class Mover : MonoBehaviour
{
    protected PlayerSO PlayerMovement;

    protected UnityEngine.CharacterController _charCont;

    protected bool _IsGrounded;
    
    private void Awake()
    {
        PlayerMovement = (PlayerSO)AssetDatabase.LoadAssetAtPath("Assets/Joep/Scriptable Objects/PlayerMovementSO.asset", typeof(PlayerSO));
        if (PlayerMovement == null)
            Debug.LogError("No PlayerSO has been found, Make one in the Assets/Joep/Scriptable Objects to resolve this error");

        _charCont = GetComponent<UnityEngine.CharacterController>();
    }

    private void Update()
    {
        GroundChecker();
    }

    /// <summary>
    /// Check if the player is grounded if not apply gravity
    /// </summary>
    protected virtual void GroundChecker()
    {

    }

    protected virtual void Jump()
    {
      
    }
}

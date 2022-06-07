using DVRSDK.Test;
using UnityEngine;

public class LookingGlassPortraitScript : MonoBehaviour
{
    [SerializeField]
    private DMMVRConnectUI dMMVRConnectUI;

    [SerializeField]
    private LookingGlass.Holoplay holoplay;

    [SerializeField]
    private Vector3 offsetRotation = new Vector3(0f, 180, 0f);

    [SerializeField]
    private bool portraitStyle = true;

    [SerializeField]
    private RuntimeAnimatorController animatorController;

    void Awake()
    {
        dMMVRConnectUI.OnAvatarLoadedAction += OnAvatarLoaded;
    }


    private void OnAvatarLoaded(GameObject model)
    {
        model.transform.rotation = Quaternion.Euler(offsetRotation);

        var animator = model.GetComponent<Animator>();

        var playerHeight = animator.GetBoneTransform(HumanBodyBones.Head).rotation.y + 0.2f;
        float cameraHeight;

        if (portraitStyle)
        {
            cameraHeight = playerHeight - 0.28f;
            holoplay.size = (playerHeight / 2) - 0.2f;
        }
        else
        {
            cameraHeight = playerHeight / 2;
            holoplay.size = (playerHeight / 2) + 0.25f;
        }

        holoplay.transform.position = new Vector3(holoplay.transform.position.x, cameraHeight, holoplay.transform.position.z);

        if (animatorController != null)
        {
            animator.runtimeAnimatorController = animatorController;
        }
    }
}

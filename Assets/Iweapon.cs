using UnityEngine.XR.Interaction.Toolkit;
public interface Iweapon
{
    void fire();

    void weapanimation();

    void weaponsoundShot();

    void weaponsoundReload();

    void setter(bool p);

    void settermag(XRBaseInteractable interactable);
}

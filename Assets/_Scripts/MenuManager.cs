using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    InputAction _menuAction;

    bool isMenuOpen = false;

    void Awake()
    {
        _menuAction = InputSystem.actions.FindAction("Menu");
        _menuAction.performed += MenuAction_performed;
    }

    async void MenuAction_performed(InputAction.CallbackContext context)
    {
        if (isMenuOpen == false)
        {
            Time.timeScale = 0;
            isMenuOpen = true;
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        }
        else
        {
            isMenuOpen = false;
            await SceneManager.UnloadSceneAsync("Menu");
            Time.timeScale = 1;
        }
    }

    private void OnDestroy()
    {
        _menuAction.performed -= MenuAction_performed;
    }
}

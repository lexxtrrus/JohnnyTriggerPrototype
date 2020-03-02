using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FacebookLogin : MonoBehaviour
{
    [SerializeField] private Button loginFacebookButton;

    private void Reset()
    {
        loginFacebookButton = GetComponent<Button>();
    }

    private void Awake()
    {
        loginFacebookButton.onClick.AddListener(TryToLogin);
    }

    private void TryToLogin()
    {
        var perms = new List<string>() { "public_profile", "email" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
    }

private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }
}

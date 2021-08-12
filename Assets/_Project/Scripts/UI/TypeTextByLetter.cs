using System.Collections;
using UnityEngine;

public class TypeTextByLetter : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text recordedText;
    [SerializeField] private TMPro.TMP_Text typeText;

    [SerializeField] private AudioSource audioSource;
   
    private void OnEnable()
    {
        if (audioSource != null)
            audioSource.Play();

        recordedText.enabled = false;

        StartCoroutine(TypeLetterByLetter());
    }
    private IEnumerator TypeLetterByLetter()
    {
        for (int j = 0; j < recordedText.text.Length; j++)
        {
            yield return new WaitForSeconds(0.15f);
            int alphabetindex = recordedText.text.IndexOf(recordedText.text[j]);

            if (alphabetindex == -1)
                yield return null;

            char coloredalpha = recordedText.text[alphabetindex];

            for (int i = 0; i <= recordedText.text.Length - 1; i++)
            {
                if (i == alphabetindex)
                {
                    typeText.text += coloredalpha;
                }
            }
        }
        audioSource.Stop();
        yield return new WaitForSeconds(1);
        SceneLoader.Instance.LoadScene(1);
    }
   
}
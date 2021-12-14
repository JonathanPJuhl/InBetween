using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Typewriter : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 50f;

    public void SetTypingSpeed(float speed)
    {
        typingSpeed = speed;
    }
    public bool IsRunning { get; private set; }

    private readonly List<Punct> punctuations = new List<Punct>()
    {
        new Punct(new HashSet<char>() {'.' , '!', '?'}, 0.6f),
        new Punct(new HashSet<char>() {',' , ';', ':'}, 0.3f)
    };

    private Coroutine typing;

    public void Run(string text, TMP_Text textobj)
    {
        typing =  StartCoroutine(TypeChars(text, textobj));
    }

    public void Stop()
    {
        StopCoroutine(typing);

        IsRunning = false;
    }

    public IEnumerator TypeChars(string text, TMP_Text textobj)
    {
        IsRunning = true;
        textobj.text = string.Empty;
        float time = 0;
        int charIndex = 0;

        while (charIndex < text.Length)
        {
            int lastCharInd = charIndex;

            time += Time.deltaTime * typingSpeed;
            charIndex = Mathf.FloorToInt(time);
            charIndex = Mathf.Clamp(charIndex, 0, text.Length);

            for (int i = lastCharInd; i < charIndex; i++)
            {
                bool lastInd = i >= text.Length - 1;


                textobj.text = text.Substring(0, i + 1);
                
                if(IsCharSymbol(text[i], out float wait) && !lastInd && !IsCharSymbol(text[i + 1], out _))
                {
                    yield return new WaitForSeconds(wait);
                }
            }

            

            yield return null;
        }
        IsRunning = false;
    }
    
    private bool IsCharSymbol(char c, out float wait)
    {
        foreach (Punct category in punctuations)
        {
            if (category.Punctuations.Contains(c))
            {
                wait = category.Wait;
                return true;
            }
        }

        wait = default;
        return false;
    }

    private readonly struct Punct
    {
        public readonly HashSet<char> Punctuations;
        public readonly float Wait;

        public Punct(HashSet<char> punctuations, float wait)
        {
            Punctuations = punctuations;
            Wait = wait;
        }
    }
}

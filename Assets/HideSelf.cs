using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSelf : MonoBehaviour
{
  public float timeout = 5f;
  // Start is called before the first frame update
  void OnEnable()
  {
    StartCoroutine(Hide());
  }

  // Update is called once per frame
  IEnumerator Hide()
  {
    yield return new WaitForSeconds(1f);
    gameObject.SetActive(false);
  }
}

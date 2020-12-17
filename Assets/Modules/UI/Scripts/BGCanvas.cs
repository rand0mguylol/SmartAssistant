using TMPro;
using System;
using UnityEngine;

[ExecuteInEditMode]
public class BGCanvas : MonoBehaviour
{
  public TextMeshProUGUI datetimeText;

  // Start is called before the first frame update
  void Start()
  {
    datetimeText.richText = true;
    UpdateDateTime();
  }

  // Update is called once per frame
  void Update()
  {
    UpdateDateTime();
  }

  void UpdateDateTime()
  {
    string day = DateTime.Now.ToString("dd");
    string mth = DateTime.Now.ToString("MMM");
    string yr = DateTime.Now.ToString("yyyy");

    string sec = DateTime.Now.ToString("ss");
    string min = DateTime.Now.ToString("mm");
    string hr = DateTime.Now.ToString("hh");

    datetimeText.text = $"{day}<sup>th</sup> <sub>of</sub> {mth} {yr}\n{hr}:{min}:{sec}";
  }
}

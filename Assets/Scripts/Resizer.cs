﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    public void ResizeButton()
    {
        transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
    }
}

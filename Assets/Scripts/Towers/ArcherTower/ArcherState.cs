using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public abstract class ArcherState : MonoBehaviour
{
    public abstract ArcherState RunCurrentState();
}

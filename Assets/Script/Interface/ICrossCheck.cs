using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICrossCheck
{
    List<Tile> CrossChecking(Transform mine);
}

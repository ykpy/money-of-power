import clr
clr.AddReferenceByPartialName('UnityEngine')
clr.AddReferenceByPartialName('UnityEngine.UI')
clr.AddReferenceByPartialName('UnityEditor')

# Unity2017対応
clr.AddReferenceByPartialName('UnityEngine.CoreModule')

from UnityEngine import *
from UnityEditor import *

import sys
sys.path.append(Application.dataPath + '/../Plugins')

def log(message):
    Debug.Log(message)

{0}

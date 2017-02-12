import clr
clr.AddReferenceByPartialName('UnityEngine')

import UnityEngine

import sys
sys.path.append(UnityEngine.Application.dataPath + '/../Lib')

import datetime

def print_message():
    UnityEngine.Debug.Log('Test message from python!')
    UnityEngine.Debug.Log(datetime.datetime.today())

print_message()

obj = UnityEngine.GameObject('from python')
obj.AddComponent[UnityEngine.AudioSource]()
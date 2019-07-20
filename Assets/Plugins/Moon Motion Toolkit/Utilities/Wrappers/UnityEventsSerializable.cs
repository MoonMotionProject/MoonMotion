using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UnityEventIntSerializable : UnityEvent<int> {}

[Serializable]
public class UnityEventFloatSerializable : UnityEvent<float> {}

[Serializable]
public class UnityEventStringSerializable : UnityEvent<string> {}

[Serializable]
public class UnityEventBoolSerializable : UnityEvent<bool> {}

[Serializable]
public class UnityEventVector3Serializable : UnityEvent<Vector3> {}

[Serializable]
public class UnityEventVector2Serializable : UnityEvent<Vector2> {}

[Serializable]
public class UnityEventGameObjectSerializable : UnityEvent<GameObject> {}

[Serializable]
public class UnityEventQuaternionSerializable : UnityEvent<Quaternion> {}

[Serializable]
public class UnityEventTransformSerializable : UnityEvent<Transform> {}

[Serializable]
public class UnityEventColorSerializable : UnityEvent<Color> {}

[Serializable]
public class UnityEventTexture2DSerializable : UnityEvent<Texture2D> {}

[Serializable]
public class UnityEventAudioClipSerializable : UnityEvent<AudioClip> {}
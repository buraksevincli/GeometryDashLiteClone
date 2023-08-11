using UnityEngine;

namespace GameFolders.Scripts.Concretes.Helpers
{
    public static class VectorHelper
    {
       public static Vector2 Up { get; }
       public static Vector2 Zero { get; }
       public static Vector2 Right { get; }

       static VectorHelper()
       {
           Up = Vector2.up;
           Zero = Vector2.zero;
           Right = Vector2.right;
       }
    }
}

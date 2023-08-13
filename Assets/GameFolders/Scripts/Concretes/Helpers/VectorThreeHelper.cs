using UnityEngine;

namespace GameFolders.Scripts.Concretes.Helpers
{
    public static class VectorThreeHelper
    {
        public static Vector3 Zero { get; }
        public static Vector3 Back { get; }
        
        static VectorThreeHelper()
        {
            Zero = Vector3.zero;
            Back = Vector3.back;
        }
    }
}

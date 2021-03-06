using System.Runtime.InteropServices;

namespace DocCN.Utility
{
    public static class Bridge
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        public static extern void Initialize();

        [DllImport("__Internal")]
        public static extern void ChangeCursor(string cursor);

        [DllImport("__Internal")]
        public static extern void LocationPush(string url);

        [DllImport("__Internal")]
        public static extern void LocationBack();

        [DllImport("__Internal")]
        public static extern void LocationReplace(string url);
        
        [DllImport("__Internal")]
        public static extern void HrefTo(string url);
        
        [DllImport("__Internal")]
        public static extern void Download(string url, string filename);
        
        [DllImport("__Internal")]
        public static extern void CopyText(string text);
#else
        public static void Initialize()
        {
        }

        public static void ChangeCursor(string cursor)
        {
        }

        public static void LocationPush(string url)
        {
        }

        public static void LocationBack()
        {
        }

        public static void LocationReplace(string url)
        {
        }

        public static void HrefTo(string url)
        {
        }

        public static void Download(string url, string filename)
        {
        }

        public static void CopyText(string text)
        {
        }
#endif
    }
}
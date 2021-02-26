using Microsoft.Xna.Framework.Content;
using System;
using System.IO;
using System.IO.Compression;

namespace Amorous.Mod
{
    /// <summary>
    /// Content manager pointing to Content-Mods
    /// </summary>
    public class ModContentManager : ContentManager
    {
        // Token: 0x0600051C RID: 1308 RVA: 0x0001953C File Offset: 0x0001773C
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider">Service Provider</param>
        /// <param name="rootDirectory">Root directory except fuck you because it's set manually anyway</param>
        public ModContentManager(IServiceProvider serviceProvider, string rootDirectory) : base(serviceProvider, rootDirectory)
        {
            RootDirectory = "Content-Mods";
        }

        //TODO: Remove compression or add a way to use either compressed or uncompressed files

        /// <summary>
        /// Overriding OpenStream function to decompress any and all assets that are being loaded
        /// </summary>
        /// <remarks>
        /// May or may not throw an exception if the file isn't actually compressed
        /// </remarks>
        /// <param name="assetName">Name of the asset to load</param>
        /// <returns>Stream</returns>
        protected override Stream OpenStream(string assetName)
        {
            try
            {
                return new GZipStream(base.OpenStream(assetName), CompressionMode.Decompress);
            }
            catch
            {
                return base.OpenStream(assetName);
            }
        }
    }
}

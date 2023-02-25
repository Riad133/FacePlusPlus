using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace FacePlusPlus.Utiles
{
    public class DataCompressor
    {
        public static string Decompress(string input)
        {
            // if (IsTooSmall(input)) return input;
            var compressed = Convert.FromBase64String(input);
            var decompressed = Decompress(compressed);
            return Encoding.UTF8.GetString(decompressed);
        }

        public static string Compress(string input)
        {
            // if (IsTooSmall(input)) return input;
            var encoded = Encoding.UTF8.GetBytes(input);
            var compressed = Compress(encoded);
            return Convert.ToBase64String(compressed);
        }
        
        /**
         * this might cause problem for cases where the compressed version is less than 1kb;
         * the way around takes extra complexity so that was simply avoided as the reward will be too insignificant.
         */
        private static bool IsTooSmall(string input)
        {
            var original = 10 + 2 * input.Length;
            return original < 1000;
        }

        private static byte[] Decompress(byte[] input)
        {
            using var source = new MemoryStream(input);
            var lengthBytes = new byte[4];
            source.Read(lengthBytes, 0, 4);

            var length = BitConverter.ToInt32(lengthBytes, 0);
            using var decompressionStream = new GZipStream(source,
                CompressionMode.Decompress);
            var result = new byte[length];
            decompressionStream.Read(result, 0, length);
            return result;
        }

        private static byte[] Compress(byte[] input)
        {
            using var result = new MemoryStream();
            var lengthBytes = BitConverter.GetBytes(input.Length);
            result.Write(lengthBytes, 0, 4);

            using (var compressionStream = new GZipStream(result,
                CompressionMode.Compress))
            {
                compressionStream.Write(input, 0, input.Length);
                compressionStream.Flush();
            }

            return result.ToArray();
        }
    }
}
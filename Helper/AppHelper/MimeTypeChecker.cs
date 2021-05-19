using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace mcq_backend.Helper.AppHelper
{
    public class MimeTypesChecker
    {
        static Dictionary<string, byte[]> fileHeader = new Dictionary<string, byte[]>()
        {
            {"JPG", new byte[] {0xFF, 0xD8, 0xFF}},
            {"JPEG", new byte[] {0xFF, 0xD8, 0xFF}},
            {"PNG", new byte[] {0x89, 0x50, 0x4E, 0x47}},
            {"TIF", new byte[] {0x49, 0x49, 0x2A, 0x00}},
            {"GIF", new byte[] {0x47, 0x49, 0x46, 0x38}},
            {"PDF", new byte[] {0x25, 0x50, 0x44, 0x46}},
            {"DOCX", new byte[] {0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00}},
        };

        public static (bool,string) CheckFileContent(IFormFile file)
        {
            byte[] header;
            string fileType = "";
            var fileExt = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1).ToUpper();
            byte[] tmp = fileHeader[fileExt];
            header = new byte[tmp.Length];
            var fileStream = file.OpenReadStream();
            fileStream.Read(header, 0, header.Length);
            var result = CompareArray(tmp, header);
            if (!result)
            {
                fileType = fileHeader.FirstOrDefault(x => x.Value.SequenceEqual(header)).Key;
            }
            return (result, fileType);
        }
        private static bool CompareArray(IReadOnlyList<byte> a1, IReadOnlyList<byte> a2)
        {
            if (a1.Count != a2.Count)
                return false;

            return !a1.Where((a1Byte, i) => a1Byte != a2[i]).Any();
        }
    }
}
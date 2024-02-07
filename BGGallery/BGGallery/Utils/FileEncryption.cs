using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BGGallery.Utils
{
    public class FileEncryption
    {
        private static string key = "kqhkiG9w0BAkqhkiG9w0BAkqhkiG9145";

        public static void EncryptFile(string inputFile, string outputFile)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.Mode = CipherMode.CFB; // 使用适当的加密模式
                aesAlg.Padding = PaddingMode.PKCS7; // 使用适当的填充方式

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                using (CryptoStream csEncrypt = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                {
                    // 写入IV
                    fsOutput.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                    // 加密文件内容
                    int bytesRead;
                    byte[] buffer = new byte[4096];
                    while ((bytesRead = fsInput.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        csEncrypt.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        public static void DecryptFile(string inputFile, string outputFile)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.Mode = CipherMode.CFB; // 使用适当的加密模式
                aesAlg.Padding = PaddingMode.PKCS7; // 使用适当的填充方式

                byte[] iv = new byte[aesAlg.IV.Length];
                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
                {
                    // 读取IV
                    fsInput.Read(iv, 0, iv.Length);

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, iv);

                    using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                    using (CryptoStream csDecrypt = new CryptoStream(fsOutput, decryptor, CryptoStreamMode.Write))
                    {
                        // 解密文件内容
                        int bytesRead;
                        byte[] buffer = new byte[4096];
                        while ((bytesRead = fsInput.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            csDecrypt.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }
    }
}

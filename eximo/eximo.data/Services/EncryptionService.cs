using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace eximo.data.Services
{
    public class EncryptionService : IEncryptionService
    {
        //TODO this will need to be stored in a more secure place
        private static RijndaelManaged _encryptProvider;
        public static byte[] salt = Encoding.ASCII.GetBytes("61981F23D8836E91");
        public static Rfc2898DeriveBytes key = new Rfc2898DeriveBytes("25D0239DC0FA9D2BE006A18911B0EF9FD21C95D33C36C2603F8380E9660F09AB", salt);

        public EncryptionService()
        {
            //TODO this will need to be stored in a more secure place
            _encryptProvider = new RijndaelManaged();
            _encryptProvider.BlockSize = 128;
            _encryptProvider.KeySize = 256;
            _encryptProvider.Key = key.GetBytes(_encryptProvider.KeySize / 8);
            _encryptProvider.IV = key.GetBytes(_encryptProvider.BlockSize / 8);
            _encryptProvider.Padding = PaddingMode.PKCS7;

        }


        public string Decrypt<T>(byte[] value)
        {
            string roundtrip = DecryptStringFromBytes(value, _encryptProvider.Key, _encryptProvider.IV);
            return roundtrip;
        }

        public byte[] Encrypt<T>(T value)
        {
            byte[] encrypted = EncryptStringToBytes(value, _encryptProvider.Key, _encryptProvider.IV);
            return encrypted;
        }

        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        static byte[] EncryptStringToBytes<T>(T plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }
    }
}
